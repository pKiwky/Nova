using DSharpPlus;
using DSharpPlus.EventArgs;
using Nova.Discord.Core;
using Nova.Discord.Interfaces;
using Nova.Discord.Managers;
using Nova.Discord.Models;

namespace Nova.Discord.Events {

    public class GuildDownloadCompleted : IEvent<GuildDownloadCompletedEventArgs> {
        public Task Run(DiscordClient client, GuildDownloadCompletedEventArgs args) {
            foreach (var module in BaseModule.Modules) {
                module?.OnGuildDownloadCompleted(client, args);
            }

            return Task.CompletedTask;
        }
    }

}