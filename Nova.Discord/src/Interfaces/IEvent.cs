using DSharpPlus;

namespace Nova.Discord.Interfaces {

    public interface IEvent<T> where T : class {
        public Task Run(DiscordClient client, T args);
    }

}