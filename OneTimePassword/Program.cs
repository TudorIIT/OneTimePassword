using OneTimePassword.DataModels;
using OneTimePassword.Functions;
using System.Globalization;

namespace OneTimePassword
{ 
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Type your user ID: ");
            var userID = Console.ReadLine();

            Console.Write("Type the date (format DD/MM/YYYY): ");
            var dateString = Console.ReadLine();

            while (!DateOnly.TryParse(dateString, new CultureInfo("en-GB"), DateTimeStyles.None, out DateOnly date))
            {
                Console.Write("Invalid Date Format. Please re-enter the Date: ");
                dateString = Console.ReadLine();
            }

            DateOnly userDate = DateOnly.Parse(dateString, new CultureInfo("en-GB"), DateTimeStyles.None);

            PasswordGenerator passwordGenerator = new PasswordGenerator();

            Password password = new Password(userID, userDate, passwordGenerator.GeneratePassword());
            Console.WriteLine(password.otPassword);

            var tasks = new List<Task>() {PasswordTimeChecks.checkPasswordTime(password), FakeLogin.Login(password) };

            await Task.WhenAll(tasks);
        }
    }
}
