using System.Security.Cryptography;
using System.Text;

namespace Pharmacy.Business.Mvc.PasswordHash
{
    public static class PasswordUtility
    {
        public static string MD5Passworder(string textPassword)
        {
            // MD5CryptoServiceProvider sınıfının bir örneğini oluşturduk.
            MD5CryptoServiceProvider md5 = new();
            //Parametre olarak gelen veriyi byte dizisine dönüştürdük.
            byte[] byteSerie = Encoding.UTF8.GetBytes(textPassword);
            //dizinin hash'ini hesaplattık.
            byteSerie = md5.ComputeHash(byteSerie);
            //Hashlenmiş verileri depolamak için StringBuilder nesnesi oluşturduk.
            StringBuilder stringBuilder = new();
            //Her byte'i dizi içerisinden alarak string türüne dönüştürdük.
            foreach (byte bs in byteSerie)
            {
                stringBuilder.Append(bs.ToString("x2").ToLower());
            }
            //hexadecimal(onaltılık) stringi geri döndürdük.
            return stringBuilder.ToString();
        }

        public static void HMACSHA512Passworder(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;//hmac.Key=128 characters
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));//hmac.Key=68 characters
            }
        }
        public static bool VerifyHMACSHA512Password(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}