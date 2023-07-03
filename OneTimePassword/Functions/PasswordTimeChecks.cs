using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneTimePassword;
using OneTimePassword.DataModels;

namespace OneTimePassword.Functions
{
    internal class PasswordTimeChecks
    {
        //private Password password { get; set; }
        //public PasswordTimeChecks(Password password) { this.password = password; }

        public static async Task<bool> checkPasswordTime(Password password, double TimeToWait = 30)
        {
            await Task.Run(() =>
            {
                while (DateTime.Compare(password.GeneratedTime.AddSeconds(TimeToWait), DateTime.Now) > 0)
                {
                    Task.Delay(500);

                    if (!password.validity)
                    {
                        return true;
                    }
                }
                password.SetValidityToFalse();
                return true;
            });

            return true;
        }
    }
}
