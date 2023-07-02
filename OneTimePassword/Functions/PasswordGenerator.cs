using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePassword.Functions
{
    public class PasswordGenerator
    {
        public int PasswordLength { get; set; } = 6;
        public string[] AllowedCharacters { get; set; } = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
        
        internal string GeneratePassword()
        {
            Random random= new Random();
            string characterToAdd = string.Empty;
            string otPassword = string.Empty;

            for (int i = 0; i < PasswordLength; i++)
            {
                characterToAdd = AllowedCharacters[random.Next(0, AllowedCharacters.Length)];
                otPassword += characterToAdd;
            }

            return otPassword;
        }
    }
}
