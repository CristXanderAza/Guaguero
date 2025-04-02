using Guaguero.Domain.Base;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace Guaguero.Domain.Entities.Users
{
    public class Credential
    {
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        private Credential(string email, string password)
        {
            Email = email;
            PasswordHash = Hash(password);
        }

        public Credential() { }

        public static Result<Credential> Create(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, EmailPattern))
                return  Result<Credential>.Fail("Email is invalid");
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return  Result<Credential>.Fail("Password is invalid");
            return  Result<Credential>.Success(new Credential(email, password));
        }

        public bool Authenticate(string password)
            => PasswordHash.Equals(Hash(password));

        public static string Hash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convertir a string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}
