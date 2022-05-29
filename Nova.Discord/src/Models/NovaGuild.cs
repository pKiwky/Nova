using System.Collections.Concurrent;

namespace Nova.Discord.Models {

    public class NovaGuild {
        public ConcurrentDictionary<string, object> Settings;

        public NovaGuild() {
            Settings = new();
        }

        /// <summary>
        /// Get setting from guild cache.
        /// </summary>
        /// <param name="key">Key of setting from cache.</param>
        /// <param name="defaultValue">Value of setting or null if key does not exist in cache.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T? GetSetting<T>(string key, object? defaultValue = null) {
            if (Settings.TryGetValue(key, out object? value)) {
                return (T) Convert.ChangeType(value, typeof(T));
            }

            if (defaultValue == null) {
                return default(T);
            }

            return (T) defaultValue;
        }
    }

}