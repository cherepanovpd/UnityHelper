using System;

namespace GPPlayerDataStorage.Scripts
{
    /// <summary>
    /// Фабрика для создания свойств игрока, использующих указанную интеграцию.
    /// </summary>
    public static class PlayerDataPropertyFactory
    {
        /// <summary>
        /// Создаёт свойство данных игрока для указанного типа <typeparamref name="T"/> и интеграции.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ свойства.</param>
        /// <param name="integration">Фабрика интеграции для работы с данными игрока.</param>
        /// <returns>Экземпляр свойства данных игрока.</returns>
        public static PlayerDataProperty<T> Create<T>(string key, PlayerDataIntegrationFactory integration)
        {
            if (integration == null)
                throw new ArgumentNullException(nameof(integration));

            return new PlayerDataProperty<T>(
                                             key,
                                             integration.GetGetter<T>(),
                                             integration.GetSetter<T>(),
                                             integration.GetSyncAction());
        }
    }
}