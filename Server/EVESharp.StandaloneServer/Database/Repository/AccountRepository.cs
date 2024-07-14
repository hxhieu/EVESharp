using EVESharp.Database.Entity;
using EVESharp.Database.Entity.Context;
using System.Text;

namespace EVESharp.StandaloneServer.Database.Repository
{
    internal interface IAccountRepository : IGenericRepository<Account>
    {
    }

    internal class AccountRepository (EveSharpDbContext dbContext) : GenericRepository<Account> (dbContext), IAccountRepository
    {

    }

    internal static class AccountRepositoryExtensions
    {
        public static string ToHex (this string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            StringBuilder sb = new(bytes.Length * 2);

            foreach (byte b in bytes)
            {
                sb.AppendFormat ("{0:X2}", b);
            }

            return sb.ToString ();
        }

        public static string ToStringFromHex (this string hexInput)
        {
            byte[] bytes = new byte[hexInput.Length / 2];

            for (int i = 0; i < hexInput.Length; i += 2)
            {
                bytes [i / 2] = Convert.ToByte (hexInput.Substring (i, 2), 16);
            }

            return Encoding.UTF8.GetString (bytes);
        }

        public static bool Login (this Account account, string password)
        {
            if (account.PasswordSalt == null || account.PasswordV2 == null)
            {
                return false;
            }
            var inputHash = BCrypt.Net.BCrypt.HashPassword(
                password,
                account.PasswordSalt.ToStringFromHex())
            .ToHex();
            return account.PasswordV2 == inputHash;
        }
    }
}
