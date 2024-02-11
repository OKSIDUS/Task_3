using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System.Text;

namespace Task_3
{
    internal class HMACCalculator
    {
        private readonly string _key;
        private HMac? hmac = new(new Sha256Digest());
        private byte[]? hmacResult;

        public HMACCalculator(string key)
        {
            _key = key;
        }

        public void CalculateHMAC(string message)
        {
            hmac = new(new Sha256Digest());
            hmac!.Init(new KeyParameter(Encoding.UTF8.GetBytes(_key)));

            hmacResult = new byte[hmac.GetMacSize()];

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            hmac.BlockUpdate(messageBytes, 0, messageBytes.Length);
            hmac.DoFinal(hmacResult, 0);

            
        }

        public void PrintHMAC()
        {
            Console.WriteLine("HMAC: " + BitConverter.ToString(hmacResult!).Replace("-", ""));
        }
    }
}
