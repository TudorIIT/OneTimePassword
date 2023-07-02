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

        public static bool checkPasswordTime(Password password, double TimeToWait = 30) 
        {
            while (DateTime.Compare(password.GeneratedTime.AddSeconds(TimeToWait), DateTime.Now) > 0)
            {
                Thread.Sleep(500);
            }
            
            password.SetValidityToFalse();
            return true;

        }
    }
}
