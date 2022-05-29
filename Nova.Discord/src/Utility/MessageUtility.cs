using System.Text.RegularExpressions;
using DSharpPlus.Entities;

namespace Nova.Discord.Utility {

    public static class MessageUtility {
        public const string MEMBER_USERNAME = "{member:username}";
        public const string MEMBER_DISCRIMINATOR = "{member:discriminator}";

        public const string SERVER_NAME = "{server:name}";

        public static void Format(ref string message, DiscordMember? member = null, DiscordGuild? guild = null) {
            if (member != null) {
                message = Regex.Replace(message, MEMBER_USERNAME, member.Username);
                message = Regex.Replace(message, MEMBER_DISCRIMINATOR, member.Discriminator);
            }

            if (guild != null) {
                message = Regex.Replace(message, SERVER_NAME, guild.Name);
            }
        }
    }

}