global using Snowflake = System.UInt64;
using DSharpPlus;
using Nova.Discord.Core;
using Nova.Discord.Events;

namespace Nova.Discord {

    public class Bot {
        private static DiscordShardedClient _shardedClient;

        public static DiscordShardedClient Get() => _shardedClient;

        public Bot(string token) {
            _shardedClient = new DiscordShardedClient(new DiscordConfiguration() {
                Intents = DiscordIntents.All,
                Token = token,
                AutoReconnect = true,
                TokenType = TokenType.Bot
            });
        }

        public async Task Run() {
            LoadEvents();
            BaseModule.LoadModules();

            await _shardedClient.StartAsync();
            await Task.Delay(-1);
        }

        private void LoadEvents() {
            _shardedClient.Ready += new Ready().Run;

            _shardedClient.GuildAvailable += new GuildAvailable().Run;
            _shardedClient.GuildUnavailable += new GuildUnavailable().Run;
            _shardedClient.GuildCreated += new GuildCreated().Run;
            _shardedClient.GuildDeleted += new GuildDeleted().Run;
            _shardedClient.GuildUpdated += new GuildUpdated().Run;
            _shardedClient.GuildBanAdded += new GuildBanAdded().Run;
            _shardedClient.GuildBanRemoved += new GuildBanRemoved().Run;
            _shardedClient.GuildDownloadCompleted += new GuildDownloadCompleted().Run;
            _shardedClient.GuildEmojisUpdated += new GuildEmojisUpdated().Run;
            _shardedClient.GuildIntegrationsUpdated += new GuildIntegrationsUpdated().Run;
            _shardedClient.GuildMemberAdded += new GuildMemberAdded().Run;
            _shardedClient.GuildMemberRemoved += new GuildMemberRemoved().Run;
            _shardedClient.GuildMembersChunked += new GuildMembersChunked().Run;
            _shardedClient.GuildMemberUpdated += new GuildMemberUpdated().Run;
            _shardedClient.GuildRoleCreated += new GuildRoleCreated().Run;
            _shardedClient.GuildRoleDeleted += new GuildRoleDeleted().Run;
            _shardedClient.GuildRoleUpdated += new GuildRoleUpdated().Run;
            _shardedClient.GuildStickersUpdated += new GuildStickersUpdated().Run;

            _shardedClient.MessageCreated += new MessageCreated().Run;
            _shardedClient.MessageDeleted += new MessageDeleted().Run;
            _shardedClient.MessageUpdated += new MessageUpdated().Run;
            // _shardedClient.MessageReactionAdded += ...
            // _shardedClient.MessageReactionRemoved += ...
            // _shardedClient.MessageReactionsCleared += ...
            // _shardedClient.MessagesBulkDeleted += ...
            // _shardedClient.MessageReactionRemovedEmoji += ...

            // _shardedClient.ChannelCreated += ...
            // _shardedClient.ChannelDeleted += ...
            // _shardedClient.ChannelUpdated += ...            
            // _shardedClient.ChannelPinsUpdated += ...
            // _shardedClient.DmChannelDeleted += ...

            // _shardedClient.IntegrationCreated += ...
            // _shardedClient.IntegrationDeleted += ...
            // _shardedClient.IntegrationUpdated += ...
            // _shardedClient.InteractionCreated += ...
        }
    }

}