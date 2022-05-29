using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Nova.Discord.Core;
using Nova.Discord.Models;
using Nova.Shared.Utility;

namespace Nova.Discord.Modules {

    public class AutomodModule : BaseModule {
        public override string ModuleName { get; set; } = Constants.SETTING_AUTOMOD_NAME;

        public override async Task OnMessageCreated(NovaGuild novaGuild, DiscordClient client, MessageCreateEventArgs args) {
            if (BadWords(novaGuild, args)) {
                await args.Message.DeleteAsync();

                string response = novaGuild.GetSetting<string>(Constants.SETTING_AUTOMOD_BAD_WORDS_RESPONSE);
                if (response != null) {
                    DiscordMessage responseMessage = await args.Channel.SendMessageAsync(FormatResponse(response));
                    new SetInterval(() => {
                        responseMessage.DeleteAsync();
                    }, Constants.DELAY_DELETE_RESPONSE_AUTOMOD).Run();
                }
            }
            else if (AllCaps(novaGuild, args)) {
                await args.Message.DeleteAsync();

                string response = novaGuild.GetSetting<string>(Constants.SETTING_AUTOMOD_ALLCAPS_RESPONSE);
                if (response != null) {
                    DiscordMessage responseMessage = await args.Channel.SendMessageAsync(FormatResponse(response));
                    new SetInterval(() => {
                        responseMessage.DeleteAsync();
                    }, Constants.DELAY_DELETE_RESPONSE_AUTOMOD).Run();
                }
            }
            else if (HasLink(novaGuild, args)) {
                await args.Message.DeleteAsync();

                string response = novaGuild.GetSetting<string>(Constants.SETTING_AUTOMOD_LINKS_RESPONSE);
                if (response != null) {
                    DiscordMessage responseMessage = await args.Channel.SendMessageAsync(FormatResponse(response));
                    new SetInterval(() => {
                        responseMessage.DeleteAsync();
                    }, Constants.DELAY_DELETE_RESPONSE_AUTOMOD).Run();
                }
            }
        }

        private DiscordEmbedBuilder FormatResponse(string message) {
            return new DiscordEmbedBuilder() {
                Description = message,
                Color = DiscordColor.IndianRed
            };
        }

        // TODO: Speed comp
        private bool BadWords(NovaGuild novaGuild, MessageCreateEventArgs args) {
            bool enabled = novaGuild.GetSetting<bool>(Constants.SETTING_AUTOMOD_BAD_WORDS_ENABLED);
            string badwords = novaGuild.GetSetting<string>(Constants.SETTING_AUTOMOD_BAD_WORDS);

            if (enabled == false || badwords == null || args.Message.Content.Length <= 3) {
                return false;
            }

            return badwords.Split(",")
                .ToList().Exists(x => args.Message.Content.Contains(x));
        }

        // TODO: Speed comp
        private bool AllCaps(NovaGuild novaGuild, MessageCreateEventArgs args) {
            bool enabled = novaGuild.GetSetting<bool>(Constants.SETTING_AUTOMOD_ALLCAPS_ENABLE);

            if (enabled == false || args.Message.Content.Length <= 3) {
                return false;
            }

            return !args.Message.Content.ToList().Exists(x => char.IsLower(x) == true);
        }

        // TODO: Better way
        private bool HasLink(NovaGuild novaGuild, MessageCreateEventArgs args) {
            bool enabled = novaGuild.GetSetting<bool>(Constants.SETTING_AUTOMOD_LINKS_ENABLED);

            if (enabled == false) {
                return false;
            }

            if (args.Message.Content.Contains("https://") || args.Message.Content.Contains("http://")) {
                return true;
            }

            return false;
        }
    }

}