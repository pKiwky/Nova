using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using Nova.Discord.Core;
using Nova.Discord.Extensions;
using Nova.Discord.Models;
using Nova.Discord.Utility;

namespace Nova.Discord.Modules {

    public class WelcomeModule : BaseModule {
        public override string ModuleName { get; set; } = Constants.SETTING_WELCOME_MODULE;

        public override async Task OnGuildMemberAdded(NovaGuild novaGuild, DiscordClient client, GuildMemberAddEventArgs args) {
            string type = novaGuild.GetSetting<string>(Constants.SETTING_WELCOME_TYPE);
            DiscordChannel? channel = args.Guild.NGetChannel(novaGuild.GetSetting<ulong>(Constants.SETTING_WELCOME_JOIN_CHANNEL));

            if (channel == null) {
                return;
            }

            switch (type) {
                case "MESSAGE": {
                    string message = novaGuild.GetSetting<string>(Constants.SETTING_WELCOME_JOIN_MESSAGE);
                    MessageUtility.Format(ref message, args.Member, args.Guild);

                    await channel.SendMessageAsync(message);
                    break;
                }
                case "EMBED": {
                    string embedMessage = novaGuild.GetSetting<string>(Constants.SETTING_WELCOME_JOIN_EMBED);
                    MessageUtility.Format(ref embedMessage, args.Member, args.Guild);

                    DiscordEmbed? embed = JsonConvert.DeserializeObject<DiscordEmbed>(embedMessage);

                    if (embed != null) {
                        await channel.SendMessageAsync(embed);
                    }

                    break;
                }
            }
        }
    }

}