using System;

namespace GPPlayerDataStorage.Scripts
{
    /// <summary>
    /// Абстрактная фабрика для работы с данными игрока.
    /// Определяет делегаты для получения и установки значений различных типов.
    /// </summary>
    public abstract class PlayerDataIntegrationFactory
    {
        /// <summary>
        /// Возвращает делегат для получения значения типа <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <returns>Делегат для получения значения.</returns>
        public abstract Func<string, T> GetGetter<T>();

        /// <summary>
        /// Возвращает делегат для установки значения типа <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <returns>Делегат для установки значения.</returns>
        public abstract Action<string, T> GetSetter<T>();

        /// <summary>
        /// Синхронизирует данные.
        /// </summary>
        public abstract Action GetSyncAction();
    }
}