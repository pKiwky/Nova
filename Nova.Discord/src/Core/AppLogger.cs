using Nova.Shared.Patterns;
using Serilog;

namespace Nova.Discord.Core {

    public class AppLogger : Singleton<AppLogger> {
        public ILogger Logger;

        public AppLogger() {
            Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();
        }
    }

}