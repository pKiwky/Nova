using DSharpPlus;
using DSharpPlus.EventArgs;
using Nova.Discord.Core;
using Nova.Discord.Interfaces;
using Nova.Discord.Managers;
using Nova.Discord.Models;

namespace Nova.Discord.Events {

    public class MessageReactionRemoved : IEvent<MessageReactionRemoveEventArgs> {
        public Task Run(DiscordClient client, MessageReactionRemoveEventArgs args) {
            if (NovaManager.Instance().Guilds.TryGetValue(args.Guild.Id, out NovaGuild novaGuild) == false) {
                return Task.CompletedTask;
            }

            foreach (var module in BaseModule.Modules) {
                if (novaGuild.GetSetting<bool>(module.ModuleName) == false) {
                    continue;
                }

                module?.OnMessageReactionRemoved(novaGuild, client, args);
            }

            return Task.CompletedTask;
        }
    }

}