using System;
using System.Collections.Generic;

using GamePush;

namespace GPPlayerDataStorage.Scripts
{
    /// <summary>
    /// Реализация фабрики для интеграции с API GP_Player.
    /// </summary>
    public class GPPlayerIntegrationFactory : PlayerDataIntegrationFactory
    {
        // Добавляем конкретные типы данных как статические поля с делегатами.
        private static readonly Dictionary<Type, Delegate> Getters = new()
                                                                     {
                                                                         { typeof(bool), (Func<string, bool>)GP_Player.GetBool },
                                                                         { typeof(float), (Func<string, float>)GP_Player.GetFloat },
                                                                         { typeof(int), (Func<string, int>)GP_Player.GetInt },
                                                                         { typeof(string), (Func<string, string>)GP_Player.GetString }
                                                                     };

        private static readonly Dictionary<Type, Delegate> Setters = new()
                                                                     {
                                                                         { typeof(bool), (Action<string, bool>)GP_Player.Set },
                                                                         { typeof(float), (Action<string, float>)GP_Player.Set },
                                                                         { typeof(int), (Action<string, int>)GP_Player.Set },
                                                                         { typeof(string), (Action<string, string>)GP_Player.Set }
                                                                     };

        /// <inheritdoc />
        public override Func<string, T> GetGetter<T>()
        {
            if (!Getters.TryGetValue(typeof(T), out Delegate getter))
            {
                throw new NotSupportedException($"Type {typeof(T)} is not supported by GP_Player.");
            }

            return (Func<string, T>)getter;
        }

        /// <inheritdoc />
        public override Action<string, T> GetSetter<T>()
        {
            if (!Setters.TryGetValue(typeof(T), out Delegate setter))
            {
                throw new NotSupportedException($"Type {typeof(T)} is not supported by GP_Player.");
            }

            return (Action<string, T>)setter;
        }

        /// <inheritdoc />
        public override Action GetSyncAction()
        {
            return () => GP_Player.Sync();
        }
    }
}