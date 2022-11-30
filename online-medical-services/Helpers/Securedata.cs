using System.Security.Cryptography;
using System.Text;

namespace online_medical_services.Helpers
{
    public class Securedata
    {
        public string hashPassword(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                var hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
