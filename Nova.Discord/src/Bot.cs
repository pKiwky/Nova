global using Snowflake = System.UInt64;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Nova.Discord.Core;
using Nova.Discord.Data;
using Nova.Discord.Events;
using Nova.Discord.Managers;
using Nova.Discord.Models;

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
            _shardedClient.GuildAvailable += OnGuildAvailableInit;

            LoadEvents();
            BaseModule.LoadModules();

            await _shardedClient.StartAsync();
            await Task.Delay(-1);
        }

        private async Task OnGuildAvailableInit(DiscordClient client, GuildCreateEventArgs args) {
            var novaGuild = new NovaGuild();

            novaGuild.Settings = await DBSettings.LoadSettings(args.Guild.Id);

            NovaManager.Instance().Guilds.TryAdd(args.Guild.Id, novaGuild);
            await Task.CompletedTask;
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
            _shardedClient.MessageReactionAdded += new MessageReactionAdded().Run;
            _shardedClient.MessageReactionRemoved += new MessageReactionRemoved().Run;
            _shardedClient.MessageReactionsCleared += new MessageReactionsCleared().Run;
            _shardedClient.MessagesBulkDeleted += new MessagesBulkDeleted().Run;
            _shardedClient.MessageReactionRemovedEmoji += new MessageReactionRemovedEmoji().Run;

            _shardedClient.ChannelCreated += new ChannelCreated().Run;
            _shardedClient.ChannelDeleted += new ChannelDeleted().Run;
            _shardedClient.ChannelUpdated += new ChannelUpdated().Run;
            _shardedClient.ChannelPinsUpdated += new ChannelPinsUpdated().Run;
            _shardedClient.DmChannelDeleted += new DmChannelDeleted().Run;

            // _shardedClient.IntegrationCreated += ...
            // _shardedClient.IntegrationDeleted += ...
            // _shardedClient.IntegrationUpdated += ...
            // _shardedClient.InteractionCreated += ...
        }
    }

}