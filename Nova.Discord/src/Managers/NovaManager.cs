using System.Collections.Concurrent;
using Nova.Discord.Models;
using Nova.Shared.Patterns;

namespace Nova.Discord.Managers {

    public class NovaManager : Singleton<NovaManager> {
        public ConcurrentDictionary<Snowflake, NovaGuild> Guilds;

        public NovaManager() {
            Guilds = new();
        }
    }

}