using OneTimePassword.DataModels;
using OneTimePassword.Functions;
using System.Text.RegularExpressions;

namespace OTPTests
{
    [TestClass]
    public class OTPTests
    {
        [TestMethod]
        public void PassGeneratorTest()
        {
            //Arrenge
            PasswordGenerator passwordGenerator = new PasswordGenerator();

            //Act
            var password = passwordGenerator.GeneratePassword();

            //Assert
            bool actual = false;
            if ((password.Length == passwordGenerator.PasswordLength) && (password.IndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }) != -1))
            {
                actual = true;
            }
            Assert.IsTrue(actual, "The password does not have the specified length or contains forbidden characters.");
        }
    }
}