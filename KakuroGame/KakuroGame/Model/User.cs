using System;
using SQLite;
using System.Security.Cryptography;
using System.Text;

namespace KakuroGame.Model
{
	public class User
	{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Username { get; set; }
        [MaxLength(10)]
        public string Password { get; set; }




        public static string HashPassword(string password) {

            using (MD5 md5 = MD5.Create()) {

                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++) {

                    stringBuilder.Append(hashBytes[i].ToString("x2"));

                }

                return stringBuilder.ToString();
            }

        }

        public static bool VerifyPassword(string password, string previousPassword)
        {
            string inputPassword = HashPassword(password);
            return inputPassword == previousPassword;
        }


    }
}
