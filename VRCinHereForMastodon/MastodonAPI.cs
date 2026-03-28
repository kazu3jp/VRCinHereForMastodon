using System.Diagnostics;
using System.Text;
using RestSharp;

namespace VRCinHereForMastodon
{
    internal class MastodonAPI
    {
        public const int InstanceTypeError = -1;
        public const int InstanceTypeLogout = 0;
        public const int InstanceTypePublic = 1;
        public const int InstanceTypeFriendsPlus = 2;
        public const int InstanceTypeFriendsOnly = 3;
        public const int InstanceTypeGroupPublic = 4;
        public const int InstanceTypeGroupPlus = 5;
        public const int InstanceTypeGroup = 6;
        public const int InstanceTypeInvitePlus = 7;
        public const int InstanceTypePrivate = 8;
        public const int InstanceTypePostTest = 9;

        private static bool PrevHidden = false;

        private class InstanceConfig
        {
            public string Label { get; set; } = "";
            public string? SettingKey { get; set; }
            public string? URLSettingKey { get; set; }
            public bool RequireWorldName { get; set; } = true;
        }

        private static readonly Dictionary<int, InstanceConfig> InstanceConfigs = new()
        {
            { InstanceTypePublic, new() { Label = "Public", SettingKey = "TootPublicJoin", URLSettingKey = "TootPublicJoinURL", RequireWorldName = true } },
            { InstanceTypeFriendsPlus, new() { Label = "Friend+", SettingKey = "TootFriendsPlusJoin", URLSettingKey = "TootFriendsPlusJoinURL", RequireWorldName = true } },
            { InstanceTypeFriendsOnly, new() { Label = "FriendOnly", SettingKey = "TootFriendsOnlyJoin", URLSettingKey = "TootFriendsOnlyJoinURL", RequireWorldName = true } },
            { InstanceTypeGroupPublic, new() { Label = "Group Public", SettingKey = "TootGroupPublicJoin", URLSettingKey = "TootGroupPublicJoinURL", RequireWorldName = true } },
            { InstanceTypeGroupPlus, new() { Label = "Group+", SettingKey = "TootGroupPlusJoin", URLSettingKey = "TootGroupPlusJoinURL", RequireWorldName = true } },
            { InstanceTypeGroup, new() { Label = "Group", SettingKey = "TootGroupJoin", URLSettingKey = null, RequireWorldName = false } },
            { InstanceTypeInvitePlus, new() { Label = "Invite+", SettingKey = "TootInvitePlusJoin", URLSettingKey = null, RequireWorldName = false } },
            { InstanceTypePrivate, new() { Label = "Private", SettingKey = "TootPrivateJoin", URLSettingKey = null, RequireWorldName = false } },
        };

        public static void SendToot(string WorldID, string WorldName, string InstanceID, int InstanceType)
        {
            if (Form1.SilentMode) return;
            if (Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.NotTootSpecifyWorldJoin) return;

            Debug.WriteLine($"WorldID -> {WorldID}");
            Debug.WriteLine($"WorldName -> {WorldName}");
            Debug.WriteLine($"InstanceID -> {InstanceID}");
            Debug.WriteLine($"InstanceType -> {InstanceType}");

            var NoteText = BuildNoteText(WorldID, WorldName, InstanceID, InstanceType);
            if (string.IsNullOrEmpty(NoteText))
                return;

            PostToMastodon(NoteText);
        }

        private static string BuildNoteText(string WorldID, string WorldName, string InstanceID, int InstanceType)
        {
            return InstanceType switch
            {
                InstanceTypePublic => BuildWorldJoinText(WorldID, WorldName, InstanceID, InstanceType),
                InstanceTypeFriendsPlus => BuildWorldJoinText(WorldID, WorldName, InstanceID, InstanceType),
                InstanceTypeFriendsOnly => BuildWorldJoinText(WorldID, WorldName, InstanceID, InstanceType),
                InstanceTypeGroupPublic => BuildWorldJoinText(WorldID, WorldName, InstanceID, InstanceType),
                InstanceTypeGroupPlus => BuildWorldJoinText(WorldID, WorldName, InstanceID, InstanceType),
                InstanceTypeGroup => BuildWorldJoinText(WorldID, WorldName, InstanceID, InstanceType),
                InstanceTypeInvitePlus => BuildWorldJoinText(WorldID, WorldName, InstanceID, InstanceType),
                InstanceTypePrivate => BuildWorldJoinText(WorldID, WorldName, InstanceID, InstanceType),
                InstanceTypeLogout => BuildLogoutText(),
                InstanceTypeError => BuildErrorText(),
                InstanceTypePostTest => BuildPostTestText(),
                _ => ""
            };
        }

        private static string BuildWorldJoinText(string WorldID, string WorldName, string InstanceID, int InstanceType)
        {
            if (!InstanceConfigs.TryGetValue(InstanceType, out var config))
                return "";

            if (!GetSetting(config.SettingKey))
                return "";

            var text = new StringBuilder();
            text.Append(Properties.Settings.Default.TootText);
            text.Append($"\n[{config.Label}]");

            var shouldHideWorldName = ShouldHideWorldName(WorldID, InstanceType);

            if (shouldHideWorldName)
            {
                if (PrevHidden)
                    return "";

                PrevHidden = true;
                text.Append(" --- ワールド名非表示 ---");
            }
            else
            {
                PrevHidden = false;
                AppendWorldInfo(text, WorldID, WorldName, InstanceID, config);
            }

            AppendHashtag(text);
            return text.ToString();
        }

        private static bool ShouldHideWorldName(string WorldID, int InstanceType)
        {
            if (Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName)
                return true;

            return InstanceType switch
            {
                InstanceTypeGroup => !Properties.Settings.Default.TootGroupJoinWorldName,
                InstanceTypeInvitePlus => !Properties.Settings.Default.TootInvitePlusJoinWorldName,
                InstanceTypePrivate => !Properties.Settings.Default.TootPrivateJoinWorldName,
                _ => false
            };
        }

        private static void AppendWorldInfo(StringBuilder text, string WorldID, string WorldName, string InstanceID, InstanceConfig config)
        {
            if (!config.RequireWorldName)
            {
                text.Append(WorldName);
                return;
            }

            var useURL = config.URLSettingKey != null && GetSetting(config.URLSettingKey);

            if (useURL)
            {
                text.Append($"{WorldName}\nhttps://vrchat.com/home/launch?worldId={WorldID}&instanceId={InstanceID}");
            }
            else
            {
                text.Append(WorldName);
            }
        }

        private static string BuildLogoutText()
        {
            if (!Properties.Settings.Default.TootLogout)
                return "";

            PrevHidden = false;
            var text = new StringBuilder("VRChatからログアウトしました。");
            AppendHashtag(text);
            return text.ToString();
        }

        private static string BuildErrorText()
        {
            if (!Properties.Settings.Default.TootError)
                return "";

            PrevHidden = false;
            var text = new StringBuilder("VRChatがクラッシュしました。");
            AppendHashtag(text);
            return text.ToString();
        }

        private static string BuildPostTestText()
        {
            var text = new StringBuilder();
            text.Append(Properties.Settings.Default.TootText);
            text.Append("\n[TEST]");
            text.Append("[投稿テスト](https://hello.vrchat.com/)");
            AppendHashtag(text);
            return text.ToString();
        }

        private static void AppendHashtag(StringBuilder text)
        {
            if (Properties.Settings.Default.TootDateTime)
            {
                text.Append("\n");
                text.Append(DateTime.Now.ToString("HH時mm分ss秒"));
            }
        }

        private static bool GetSetting(string? settingKey)
        {
            if (settingKey == null)
                return true;

            return settingKey switch
            {
                "TootPublicJoin" => Properties.Settings.Default.TootPublicJoin,
                "TootFriendsPlusJoin" => Properties.Settings.Default.TootFriendsPlusJoin,
                "TootFriendsOnlyJoin" => Properties.Settings.Default.TootFriendsOnlyJoin,
                "TootGroupPublicJoin" => Properties.Settings.Default.TootGroupPublicJoin,
                "TootGroupPlusJoin" => Properties.Settings.Default.TootGroupPlusJoin,
                "TootGroupJoin" => Properties.Settings.Default.TootGroupJoin,
                "TootInvitePlusJoin" => Properties.Settings.Default.TootInvitePlusJoin,
                "TootPrivateJoin" => Properties.Settings.Default.TootPrivateJoin,
                "TootPublicJoinURL" => Properties.Settings.Default.TootPublicJoinURL,
                "TootFriendsPlusJoinURL" => Properties.Settings.Default.TootFriendsPlusJoinURL,
                "TootFriendsOnlyJoinURL" => Properties.Settings.Default.TootFriendsOnlyJoinURL,
                "TootGroupPublicJoinURL" => Properties.Settings.Default.TootGroupPublicJoinURL,
                "TootGroupPlusJoinURL" => Properties.Settings.Default.TootGroupPlusJoinURL,
                _ => false
            };
        }

        private static void PostToMastodon(string noteText)
        {
            Debug.WriteLine(noteText);

            try
            {
                var endpoint = "https://" + Properties.Settings.Default.ServerDomain;
                var client = new RestClient(endpoint);
                var request = new RestRequest("/api/v1/statuses", Method.Post);

                request.AddHeader("Authorization", "Bearer " + Common.Decrypt(Properties.Settings.Default.APIKey));
                request.AddParameter("status", noteText);
                request.AddParameter("visibility", GetVisibility());

                var response = client.Execute(request);
                Debug.WriteLine(response.Content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error posting to Mastodon: {ex.Message}");
            }
        }

        private static string GetVisibility()
        {
            return Properties.Settings.Default.TootPublishType switch
            {
                0 => "public",
                1 => "unlisted",
                2 => "private",
                _ => "unlisted"
            };
        }
    }
}
