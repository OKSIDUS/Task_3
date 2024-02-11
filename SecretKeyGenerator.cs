using System.Security.Cryptography;

namespace Task_3
{
    internal class SecretKeyGenerator
    {
        
        private const int KeySize = 256;
        private string _key = string.Empty;

        public string GenerateSecretKey()
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[KeySize / 8];
                generator.GetBytes(bytes);

                _key = BitConverter.ToString(bytes).Replace("-", "");
                return _key;
            }
        }

        public void PrintSecretKey()
        {
            Console.WriteLine(_key);
        }
    }
}
