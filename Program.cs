using System;
using System.Security.Cryptography;
using System.Web.Security;

namespace CodeQLAlertTrigger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World - Insecure edition!");

            Console.Write("Enter your username: ");
            var user = Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            Console.WriteLine("\nChecking access....");
            
            var secureComponent = new SecureAccess();
            var result = secureComponent.Login(user,password);

            if (result == AccessLevel.None)
            {
                Console.WriteLine("Access denied.");
                return;
            }
            
            Console.WriteLine($"Access Level: {result}");
            

        }
    }

    string GeneratePassword()
    {
        // https://codeql.github.com/codeql-query-help/csharp/cs-insecure-randomness/
        // BAD: Password is generated using a cryptographically insecure RNG
        Random gen = new Random();
        string password = "mypassword" + gen.Next();
        return password;
    }
}
