using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        static bool PrevHidden = false; //前回投稿がワールド名非表示であったか保持(ワールド名非表示投稿の連続を防ぐため)
        public static void SendToot(string WorldID, string WorldName, string InstanceID, int InstanceType)
        {
            if (Form1.SilentMode) return; //投稿一時停止
            if (Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.NotTootSpecifyWorldJoin) return; //指定ワールドに合致、かつ指定ワールドはノートしない場合

            Debug.WriteLine("WorldID -> " + WorldID);
            Debug.WriteLine("WorldName -> " + WorldName);
            Debug.WriteLine("InstanceID -> " + InstanceID);
            Debug.WriteLine("InstanceType -> " + InstanceType);

            var NoteText = "";
            if (InstanceType == InstanceTypePublic)
            {
                if (!Properties.Settings.Default.TootPublicJoin) return;
                NoteText += Properties.Settings.Default.TootText + "\n[Public]";
                if (Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName)
                {
                    if (PrevHidden)
                    {
                        return;
                    }
                    PrevHidden = true;
                    NoteText += " --- ワールド名非表示 ---";
                    
                }
                else
                {
                    PrevHidden = false;
                    if (Properties.Settings.Default.TootPublicJoinURL)
                    {
                        NoteText += $"[{WorldName}](https://vrchat.com/home/launch?worldId={WorldID}&instanceId={InstanceID}) (リンクからJoin可能)";
                        //NoteText += "\nこのインスタンスへJoin → https://vrchat.com/home/launch?worldId=" + WorldID + "&instanceId=" + InstanceID;
                    }
                    else
                    {
                        NoteText += WorldName;
                    }
                }
            }
            else if (InstanceType == InstanceTypeFriendsPlus)
            {
                if (!Properties.Settings.Default.TootFriendsPlusJoin) return;
                NoteText += Properties.Settings.Default.TootText + "\n[Friend+]";
                if (Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName)
                {
                    if (PrevHidden)
                    {
                        return;
                    }
                    PrevHidden = true;
                    NoteText += " --- ワールド名非表示 ---";
                }
                else
                {
                    PrevHidden = false;
                    if (Properties.Settings.Default.TootFriendsPlusJoinURL)
                    {
                        NoteText += $"[{WorldName}](https://vrchat.com/home/launch?worldId={WorldID}&instanceId={InstanceID}) (リンクからJoin可能)";
                        //NoteText += "\nこのインスタンスへJoin → https://vrchat.com/home/launch?worldId=" + WorldID + "&instanceId=" + InstanceID;
                    }
                    else
                    {
                        NoteText += WorldName;
                    }
                }
            }
            else if (InstanceType == InstanceTypeFriendsOnly)
            {
                if (!Properties.Settings.Default.TootFriendsOnlyJoin) return;
                NoteText += Properties.Settings.Default.TootText + "\n[FriendOnly]";
                if (Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName)
                {
                    if (PrevHidden)
                    {
                        return;
                    }
                    PrevHidden = true;
                    NoteText += " --- ワールド名非表示 ---";
                }
                else
                {
                    PrevHidden = false;
                    if (Properties.Settings.Default.TootFriendsOnlyJoinURL)
                    {
                        NoteText += $"[{WorldName}](https://vrchat.com/home/launch?worldId={WorldID}&instanceId={InstanceID}) (リンクからJoin可能)";
                        //NoteText += "\nこのインスタンスへJoin → https://vrchat.com/home/launch?worldId=" + WorldID + "&instanceId=" + InstanceID;
                    }
                    else
                    {
                        NoteText += WorldName;
                    }
                }
            }
            else if (InstanceType == InstanceTypeGroupPublic)
            {
                if (!Properties.Settings.Default.TootGroupPublicJoin) return;
                NoteText += Properties.Settings.Default.TootText + "\n[Group Public]";
                if (Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName)
                {
                    if (PrevHidden)
                    {
                        return;
                    }
                    PrevHidden = true;
                    NoteText += " --- ワールド名非表示 ---";
                }
                else
                {
                    PrevHidden = false;
                    if (Properties.Settings.Default.TootGroupPublicJoinURL)
                    {
                        NoteText += $"[{WorldName}](https://vrchat.com/home/launch?worldId={WorldID}&instanceId={InstanceID}) (リンクからJoin可能)";
                    }
                    else
                    {
                        NoteText += WorldName;
                    }
                }
            }
            else if (InstanceType == InstanceTypeGroupPlus)
            {
                if (!Properties.Settings.Default.TootGroupPlusJoin) return;
                NoteText += Properties.Settings.Default.TootText + "\n[Group+]";
                if (Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName)
                {
                    if (PrevHidden)
                    {
                        return;
                    }
                    PrevHidden = true;
                    NoteText += " --- ワールド名非表示 ---";
                }
                else
                {
                    PrevHidden = false;
                    NoteText += WorldName;
                    if (Properties.Settings.Default.TootGroupPlusJoinURL)
                    {
                        NoteText += $"[{WorldName}](https://vrchat.com/home/launch?worldId={WorldID}&instanceId={InstanceID}) (リンクからJoin可能)";
                        //NoteText += "\nこのインスタンスへJoin → https://vrchat.com/home/launch?worldId=" + WorldID + "&instanceId=" + InstanceID;
                    }
                    else
                    {
                        NoteText += WorldName;
                    }
                }
            }
            else if (InstanceType == InstanceTypeGroup)
            {
                if (!Properties.Settings.Default.TootGroupJoin) return;
                NoteText += Properties.Settings.Default.TootText + "\n[Group]";
                if ((Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName) || !Properties.Settings.Default.TootGroupJoinWorldName)
                {
                    if (PrevHidden)
                    {
                        return;
                    }
                    PrevHidden = true;
                    NoteText += " --- ワールド名非表示 ---";
                }
                else
                {
                    PrevHidden = false;
                    NoteText += WorldName;
                }
            }
            else if (InstanceType == InstanceTypeInvitePlus)
            {
                if (!Properties.Settings.Default.TootInvitePlusJoin) return;
                NoteText += Properties.Settings.Default.TootText + "\n[Invite+]";
                if ((Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName) || !Properties.Settings.Default.TootInvitePlusJoinWorldName)
                {
                    if (PrevHidden)
                    {
                        return;
                    }
                    PrevHidden = true;
                    NoteText += " --- ワールド名非表示 ---";
                }
                else
                {
                    PrevHidden = false;
                    NoteText += WorldName;
                }
            }
            else if (InstanceType == InstanceTypePrivate)
            {
                if (!Properties.Settings.Default.TootPrivateJoin) return;
                NoteText += Properties.Settings.Default.TootText + "\n[Private]";
                if ((Common.IsSpecifyWorld(WorldID) && Properties.Settings.Default.MaskSpecifyWorldName) || !Properties.Settings.Default.TootPrivateJoinWorldName)
                {
                    if (PrevHidden)
                    {
                        return;
                    }
                    PrevHidden = true;
                    NoteText += " --- ワールド名非表示 ---";
                }
                else
                {
                    PrevHidden = false;
                    NoteText += WorldName;
                }
            }
            else if (InstanceType == InstanceTypeLogout)
            {
                if (!Properties.Settings.Default.TootLogout) return;

                PrevHidden = false;
                NoteText += "VRChatからログアウトしました。";
            }
            else if (InstanceType == InstanceTypeError)
            {
                if (!Properties.Settings.Default.TootError) return;

                PrevHidden = false;
                NoteText += "VRChatからエラー落ちしました。";
            }
            else if (InstanceType == InstanceTypePostTest)
            {
                NoteText += Properties.Settings.Default.TootText + "\n[TEST]";
                NoteText += "[投稿テスト](https://hello.vrchat.com/) (~~リンクからJoin可能~~ ←投稿テストのためダミーURL)";
            }

            NoteText += "\n#VRCinHere";
            if (Properties.Settings.Default.TootDateTime)
            {
                NoteText += " " + DateTime.Now.ToLongTimeString();
            }
            Debug.WriteLine(NoteText);

            var Endpoint = "https://" + Properties.Settings.Default.ServerDomain;
            var RestClient = new RestClient(Endpoint);
            var Request = new RestRequest("/api/v1/statuses", Method.Post);
            Request.AddHeader("Authorization", "Bearer " + Common.Decrypt(Properties.Settings.Default.APIKey));
            Request.AddParameter("status", NoteText);
            
            if (Properties.Settings.Default.TootPublishType == 0) { Request.AddParameter("visibility", "public"); }
            else if (Properties.Settings.Default.TootPublishType == 1) { Request.AddParameter("visibility", "unlisted"); }
            else if (Properties.Settings.Default.TootPublishType == 2) { Request.AddParameter("visibility", "private"); }
            else { Request.AddParameter("visibility", "unlisted"); }
            try
            {
                var Response = RestClient.Execute(Request);
                Debug.WriteLine(Response.Content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
