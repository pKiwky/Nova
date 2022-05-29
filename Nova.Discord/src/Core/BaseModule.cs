using DSharpPlus;
using DSharpPlus.EventArgs;
using Nova.Discord.Models;
using Serilog;

namespace Nova.Discord.Core {

    public abstract class BaseModule {
        public virtual string ModuleName { get; set; } = "Unnamed";
        public static readonly List<BaseModule> Modules = new List<BaseModule>();

        public static void LoadModules() {
            var modulesAssembly = typeof(BaseModule)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(BaseModule)) && !t.IsAbstract);

            ILogger logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            foreach (var assembly in modulesAssembly) {
                var module = (BaseModule) Activator.CreateInstance(assembly, logger);

                Modules.Add(module);
                module.OnModuleLoaded();
            }
        }

        /// <summary>
        /// Get module by type.
        /// </summary>
        /// <typeparam name="T">Module type.</typeparam>
        /// <returns></returns>
        public static T? GetModule<T>() where T : BaseModule {
            foreach (var module in Modules) {
                if (module.GetType() == typeof(T)) {
                    return (T) Convert.ChangeType(module, typeof(T));
                }
            }

            return default(T);
        }

        /// <summary>
        /// Called when module is loaded.
        /// </summary>
        /// <returns></returns>
        public virtual Task OnModuleLoaded() {
            return Task.CompletedTask;
        }

        /// <summary>
        /// The ready event is dispatched when a client has completed the initial handshake with the gateway for current shard.
        /// </summary>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnReady(DiscordClient client, ReadyEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// When a user is initially connecting, to lazily load and backfill information for all unavailable guilds sent in the Ready event. 
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildAvailable(NovaGuild novaGuild, DiscordClient client, GuildCreateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild becomes or was already unavailable due to an outage, or when the user leaves or is removed from a guild.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildUnavailable(NovaGuild novaGuild, DiscordClient client, GuildDeleteEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// When the current user joins a new Guild.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildCreated(NovaGuild novaGuild, DiscordClient client, GuildCreateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild becomes or was already unavailable due to an outage, or when the user leaves or is removed from a guild.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildDeleted(NovaGuild novaGuild, DiscordClient client, GuildDeleteEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild is updated.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildUpdated(NovaGuild novaGuild, DiscordClient client, GuildUpdateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a user is banned from a guild.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildBanAdded(NovaGuild novaGuild, DiscordClient client, GuildBanAddEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a user is unbanned from a guild.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildBanRemoved(NovaGuild novaGuild, DiscordClient client, GuildBanRemoveEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Fired when all guilds finish streaming from Discord.
        /// </summary>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildDownloadCompleted(DiscordClient client, GuildDownloadCompletedEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild's emojis have been updated.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildEmojisUpdated(NovaGuild novaGuild, DiscordClient client, GuildEmojisUpdateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild integration is updated.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildIntegrationsUpdated(NovaGuild novaGuild, DiscordClient client, GuildIntegrationsUpdateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a new user joins a guild.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildMemberAdded(NovaGuild novaGuild, DiscordClient client, GuildMemberAddEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a user is removed from a guild (leave/kick/ban).
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildMemberRemoved(NovaGuild novaGuild, DiscordClient client, GuildMemberRemoveEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent in response to Guild Request Members.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildMembersChunked(NovaGuild novaGuild, DiscordClient client, GuildMembersChunkEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild member is updated. This will also fire when the user object of a guild member changes.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildMemberUpdated(NovaGuild novaGuild, DiscordClient client, GuildMemberUpdateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild role is created.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildRoleCreated(NovaGuild novaGuild, DiscordClient client, GuildRoleCreateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild role is deleted.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildRoleDeleted(NovaGuild novaGuild, DiscordClient client, GuildRoleDeleteEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild role is updated.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildRoleUpdated(NovaGuild novaGuild, DiscordClient client, GuildRoleUpdateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a guild's stickers have been updated.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnGuildStickersUpdated(NovaGuild novaGuild, DiscordClient client, GuildStickersUpdateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a message is created..
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnMessageCreated(NovaGuild novaGuild, DiscordClient client, MessageCreateEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a message is updated.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnMessageDeleted(NovaGuild novaGuild, DiscordClient client, MessageDeleteEventArgs args) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sent when a message is deleted.
        /// </summary>
        /// <param name="novaGuild">NovaGuild for this guild.</param>
        /// <param name="client">Instance of client from shard.</param>
        /// <param name="args">Events args.</param>
        /// <returns></returns>
        public virtual Task OnMessageUpdated(NovaGuild novaGuild, DiscordClient client, MessageUpdateEventArgs args) {
            return Task.CompletedTask;
        }
    }

}