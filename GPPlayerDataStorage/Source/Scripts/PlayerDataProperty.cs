using System;

using Unity.Properties;

namespace GPPlayerDataStorage.Scripts
{
    /// <summary>
    /// Обобщённый класс для представления свойства данных игрока.
    /// </summary>
    /// <typeparam name="T">Тип значения свойства.</typeparam>
    public class PlayerDataProperty<T>
    {
        private string _key;

        private T _value;

        private readonly Func<string, T> _getter;   // Делегат для получения значения
        private readonly Action<string, T> _setter; // Делегат для установки значения
        private readonly Action _syncAction;        // Делегат синхронизации

        /// <summary>
        /// Значение свойства. При изменении оно обновляется в интеграции и синхронизируется.
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _setter(_key, _value);
                _syncAction();
            }
        }

        /// <summary>
        /// Создаёт свойство данных игрока, используя делегаты для действий.
        /// </summary>
        /// <param name="key">Ключ для идентификации свойства.</param>
        /// <param name="getter">Метод для получения значения.</param>
        /// <param name="setter">Метод для установки значения.</param>
        /// <param name="syncAction">Метод для выполнения синхронизации.</param>
        public PlayerDataProperty(string key,
                                  Func<string, T> getter,
                                  Action<string, T> setter,
                                  Action syncAction)
        {
            _key = key;
            _getter = getter ?? throw new ArgumentNullException(nameof(getter));
            _setter = setter ?? throw new ArgumentNullException(nameof(setter));
            _syncAction = syncAction ?? throw new ArgumentNullException(nameof(syncAction));


            _value = _getter(_key);
        }

        /// <summary>
        /// Неявное преобразование свойства к типу <typeparamref name="T"/>.
        /// </summary>
        /// <param name="property">Экземпляр свойства.</param>
        public static implicit operator T(PlayerDataProperty<T> property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            return property._value;
        }
    }
}