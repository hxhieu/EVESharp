using EVESharp.Database.Entity;
using EVESharp.Database.Entity.Context;
using EVESharp.StandaloneServer.Database.Repository;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace EVESharp.StandaloneServer.Database.Extensions
{
    internal interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account?> Login (string username, string password);
    }

    internal class AccountRepository (EveSharpDbContext dbContext) : GenericRepository<Account> (dbContext), IAccountRepository
    {
        public static string Sha1 (byte [] inputBytes)
        {
            // Convert byte array to hexadecimal string
            StringBuilder hexBuilder = new(inputBytes.Length * 2);
            foreach (byte b in inputBytes)
            {
                hexBuilder.AppendFormat ("{0:x2}", b);
            }
            string hexString = hexBuilder.ToString();

            // Convert hexadecimal string back to byte array
            byte[] hexBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < hexBytes.Length; i++)
            {
                hexBytes [i] = Convert.ToByte (hexString.Substring (i * 2, 2), 16);
            }

            // Compute SHA-1 hash
            byte [] hashBytes = SHA1.HashData (hexBytes);

            // Convert hash byte array to hexadecimal string
            StringBuilder hashHexBuilder = new(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashHexBuilder.AppendFormat ("{0:x2}", b);
            }
            return hashHexBuilder.ToString ();
        }

        public async Task<Account?> Login (string username, string password)
        {
            var account = await GetFirstAsync (x =>
                x.AccountName.ToLower () == username.ToLower ()
            );

            if (account != null)
            {
                var inputPasswordHash = Sha1(Encoding.UTF8.GetBytes(password));
                var storedPasswordHash = Sha1(account.Password);

                // Example input data
                string input = "abcd_1234";

                // Step 1: Convert input string to byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Step 2: Convert byte array to hexadecimal string
                StringBuilder hexBuilder = new StringBuilder(inputBytes.Length * 2);
                foreach (byte b in inputBytes)
                {
                    hexBuilder.AppendFormat ("{0:x2}", b);
                }
                string hexString = hexBuilder.ToString();

                // Step 3: Convert hexadecimal string back to byte array
                byte[] hexBytes = new byte[hexString.Length / 2];
                for (int i = 0; i < hexBytes.Length; i++)
                {
                    hexBytes [i] = Convert.ToByte (hexString.Substring (i * 2, 2), 16);
                }

                // Step 4: Compute SHA-1 hash
                using (SHA1 sha1 = SHA1.Create ())
                {
                    byte[] hashBytes = sha1.ComputeHash(hexBytes);

                    // Step 5: Convert hash byte array to hexadecimal string
                    StringBuilder hashHexBuilder = new StringBuilder(hashBytes.Length * 2);
                    foreach (byte b in hashBytes)
                    {
                        hashHexBuilder.AppendFormat ("{0:x2}", b);
                    }
                    string hashHexString = hashHexBuilder.ToString();
                }
                return inputPasswordHash == storedPasswordHash ? account : null;
            }

            return null;
        }
    }
}
