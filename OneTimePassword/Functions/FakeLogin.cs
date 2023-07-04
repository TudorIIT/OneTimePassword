using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneTimePassword.DataModels;

namespace OneTimePassword.Functions
{
    public class FakeLogin
    {
        public static async Task Login(Password password)
        {
            string userid = String.Empty;
            string pass = String.Empty;

            Console.Write("Your UserID: ");
            await Task.Run(() => userid = Console.ReadLine());

            while (userid != password.userID)
            {
                Console.Write("The UserID does not match. Please re-enter: ");
                await Task.Run(() => userid = Console.ReadLine());
            }

            Console.Write("Enter the OTP: ");
            await Task.Run(() => pass = Console.ReadLine());

            while (pass != password.otPassword)
            {
                Console.Write("The password is not valid. Please re-enter: ");
                await Task.Run(() => pass = Console.ReadLine());
            }

            if (!password.validity)
            {
                Console.WriteLine("Password is expired!");
            }

            if (pass == password.otPassword && password.validity)
            {
                Console.WriteLine("Great! You enetered a valid password.");
                password.SetValidityToFalse();
            }
                

        }
    }
}
