using DSharpPlus.Entities;

namespace Nova.Discord.Extensions {

    public static class GuildExtension {
        /// <summary>
        /// Try to get channel by id or null.
        /// </summary>
        /// <param name="guild">Guild object class.</param>
        /// <param name="channelId">Id of channel to search.</param>
        /// <returns></returns>
        public static DiscordChannel? NGetChannel(this DiscordGuild guild, ulong channelId) {
            DiscordChannel? channel = null;

            try {
                channel = guild.GetChannel(channelId);
            }
            catch { }

            return channel;
        }
    }

}