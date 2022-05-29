using DSharpPlus;
using DSharpPlus.EventArgs;
using Nova.Discord.Core;
using Nova.Discord.Interfaces;
using Nova.Discord.Managers;
using Nova.Discord.Models;

namespace Nova.Discord.Events {

    public class DmChannelDeleted : IEvent<DmChannelDeleteEventArgs> {
        public Task Run(DiscordClient client, DmChannelDeleteEventArgs args) {
            if (NovaManager.Instance().Guilds.TryGetValue(args.Channel.Guild.Id, out NovaGuild novaGuild) == false) {
                return Task.CompletedTask;
            }

            foreach (var module in BaseModule.Modules) {
                if (novaGuild.GetSetting<bool>(module.ModuleName) == false) {
                    continue;
                }

                module?.OnDmChannelDeleted(novaGuild, client, args);
            }

            return Task.CompletedTask;
        }
    }

}