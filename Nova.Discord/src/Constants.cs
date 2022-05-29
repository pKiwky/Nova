namespace Nova.Discord {

    public static class Constants {
        #region AUTOMOD_MODULE

        public const int DELAY_DELETE_RESPONSE_AUTOMOD = 2000;
        public const string SETTING_AUTOMOD_NAME = "AutomodModule";

        public const string SETTING_AUTOMOD_BAD_WORDS_ENABLED = "Automod::BadWords::Enabled";
        public const string SETTING_AUTOMOD_BAD_WORDS_RESPONSE = "Automod::BadWords::Response";
        public const string SETTING_AUTOMOD_BAD_WORDS = "Automod::BadWords";

        public const string SETTING_AUTOMOD_ALLCAPS_ENABLE = "Automod::AllCaps::Enabled";
        public const string SETTING_AUTOMOD_ALLCAPS_RESPONSE = "Automod::AllCaps::Response";

        public const string SETTING_AUTOMOD_LINKS_ENABLED = "Automod::Links::Enabled";
        public const string SETTING_AUTOMOD_LINKS_RESPONSE = "Automod::Links::Response";

        #endregion

        #region WELCOME_MODULE

        public const string SETTING_WELCOME_MODULE = "WelcomeModule";
        public const string SETTING_WELCOME_TYPE = "Welcome::Type";

        public const string SETTING_WELCOME_ENABLED = "Welcome::Join::Enabled";
        public const string SETTING_WELCOME_JOIN_CHANNEL = "Welcome::Join::Channel";
        public const string SETTING_WELCOME_JOIN_MESSAGE = "Welcome::Join::Message";
        public const string SETTING_WELCOME_JOIN_EMBED = "Welcome::Join::Embed";

        #endregion
    }

}