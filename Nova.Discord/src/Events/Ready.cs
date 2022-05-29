using DSharpPlus;
using DSharpPlus.EventArgs;
using Nova.Discord.Core;
using Nova.Discord.Interfaces;

namespace Nova.Discord.Events {

    public class Ready : IEvent<ReadyEventArgs> {
        public Task Run(DiscordClient client, ReadyEventArgs args) {
            foreach (var module in BaseModule.Modules) {
                module?.OnReady(client, args);
            }

            return Task.CompletedTask;
        }
    }

}