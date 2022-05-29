using System.ComponentModel.Design;
using Nova.Discord.Core;
using Nova.Discord.Managers;
using Nova.MySQL;
using Serilog;

namespace Nova.Discord.Data {

    public static class DBSettings {
        public static async Task<Dictionary<string, object>?> LoadSettings(ulong guildId) {
            var query = await Database.Instance().Query("SELECT `key`, `value` FROM `settings` WHERE `guild_id` = {0}", guildId);

            if (query == null) {
                return null;
            }

            var result = new Dictionary<string, object>();
            foreach (var row in query.GetRows()) {
                string key = row.GetValue<string>("key");
                string value = row.GetValue<string>("value");

                result.TryAdd(key, value);
                AppLogger.Instance().Logger.Debug("GuildId: {guildId}: Key: {key} - Value: {value}", guildId, key, value);
            }

            return result;
        }
    }

}