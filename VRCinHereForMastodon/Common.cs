using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VRCinHereForMastodon
{
    internal class Common
    {
        public static string Encrypt(string planeText)
        {
            var planeByte = Encoding.ASCII.GetBytes(planeText);
            var encryptedByte = ProtectedData.Protect(planeByte, null, DataProtectionScope.CurrentUser);
            var encrypted64Text = Convert.ToBase64String(encryptedByte);
            return encrypted64Text;
        }

        public static string Decrypt(string encrypt64Text)
        {
            var encryptedByte = Convert.FromBase64String(encrypt64Text);
            var planeByte = ProtectedData.Unprotect(encryptedByte, null, DataProtectionScope.CurrentUser);
            var planeText = Encoding.ASCII.GetString(planeByte);
            return planeText;
        }

        public static bool IsSpecifyWorld(string WorldID)
        {
            if (Properties.Settings.Default.SpecifyWorldList is not null)
            {
                var SpecifyWorldList = Properties.Settings.Default.SpecifyWorldList;
                foreach (var SpecifyWorld in SpecifyWorldList)
                {
                    var tmpRow = SpecifyWorld.Split('\t');
                    if (tmpRow[0] == WorldID)
                    {
                        if (tmpRow[2] == "1")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
    }
}
