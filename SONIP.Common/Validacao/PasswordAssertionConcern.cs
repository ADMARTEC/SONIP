using SONIP.Common.Resource.Erros;
using System.Text;

namespace SONIP.Common.Validacao
{
    public class PasswordAssertionConcern
    {
        public static void AssertIsValid(string password)
        {
            AssertionConcern.AssertArgumentNotNull(password, Base.TagSenhaInvalida);
        }

        public static string Encrypt(string password)
        {
            // O valor dentro das "" representa uma adicão na password para causar mais dificuldade na complexidade da password
            password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            System.Text.StringBuilder sbString = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)            
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}
