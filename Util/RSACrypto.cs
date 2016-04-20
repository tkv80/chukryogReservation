using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace CampingReservation.Util
{
    public sealed class RsaCrypto
    {
        public String RsaEncrypt(String input, RSAEntity entity)
        {
            input = Byte2Hex(Hex2Byte(input));
            if (String.IsNullOrEmpty(input)) return null;

            try
            {
                byte[] inbuf = Encoding.UTF8.GetBytes(input);

                //Create a new instance of RSACryptoServiceProvider.
                var rsa = new RSACryptoServiceProvider();

                //Import the RSA Key information. This only needs
                //toinclude the public key information.
                var objRsaPars = new RSAParameters
                {
                    Modulus = entity.Modulus,
                    Exponent = entity.Exponent
                };

                rsa.ImportParameters(objRsaPars);

                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return Convert.ToBase64String(rsa.Encrypt(inbuf, false));
            }
                //Catch and display a CryptographicException 
            catch (CryptographicException e)
            {
                //return null;
                throw e;
            }
        }

        public String RsaDecrypt(String input, RSAEntity entity)
        {
            if (String.IsNullOrEmpty(input)) return null;

            try
            {
                byte[] keybuf = Convert.FromBase64String(input);

                //Create a new instance of RSACryptoServiceProvider.
                var RSA = new RSACryptoServiceProvider();

                //Import the RSA Key information. This only needs
                //toinclude the public key information.
                var objRsaPars = new RSAParameters();

                objRsaPars.Modulus = entity.Modulus;
                objRsaPars.Exponent = entity.Exponent;
                objRsaPars.P = entity.P;
                objRsaPars.Q = entity.Q;
                objRsaPars.DP = entity.DP;
                objRsaPars.DQ = entity.DQ;
                objRsaPars.InverseQ = entity.InverseQ;
                objRsaPars.D = entity.D;

                RSA.ImportParameters(objRsaPars);

                //Decrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return Encoding.UTF8.GetString(RSA.Decrypt(keybuf, false));
            }
                //Catch and display a CryptographicException  
            catch (CryptographicException e)
            {
                //return null;
                throw e;
            }
        }

        public RSAEntity GenerateKey(String rsaXml, bool bDecrypt)
        {
            //byte[] keybuf = Convert.FromBase64String(key);
            //string rsaXml = (new UTF8Encoding()).GetString(keybuf);

            XElement keyXml = XElement.Parse(rsaXml);

            if (bDecrypt)
                return new RSAEntity
                {
                    Modulus = Convert.FromBase64String(keyXml.Element("Modulus").Value),
                    Exponent = Convert.FromBase64String(keyXml.Element("Exponent").Value),
                    P = Convert.FromBase64String(keyXml.Element("P").Value),
                    Q = Convert.FromBase64String(keyXml.Element("Q").Value),
                    DP = Convert.FromBase64String(keyXml.Element("DP").Value),
                    DQ = Convert.FromBase64String(keyXml.Element("DQ").Value),
                    InverseQ = Convert.FromBase64String(keyXml.Element("InverseQ").Value),
                    D = Convert.FromBase64String(keyXml.Element("D").Value)
                };
            return new RSAEntity
            {
                Modulus = Hex2Byte(Byte2Hex(Convert.FromBase64String(keyXml.Element("Modulus").Value))),
                Exponent = Hex2Byte(Byte2Hex(Convert.FromBase64String(keyXml.Element("Exponent").Value)))
            };
        }

        private static string Byte2Hex(byte[] bytes)
        {
            string hex = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    hex += bytes[i].ToString("X2");
                }
            }
            return hex;
        }

        private static byte[] Hex2Byte(string hex)
        {
            var bytes = new byte[hex.Length/2];
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    bytes[i] = Convert.ToByte(hex.Substring(i*2, 2), 16);
                }
                catch
                {
                    throw new ArgumentException(
                        "hex is not a valid hex number!", "hex");
                }
            }
            return bytes;
        }
    }

    public class RSAEntity
    {
        public byte[] Modulus { get; set; }
        public byte[] Exponent { get; set; }
        public byte[] P { get; set; }
        public byte[] Q { get; set; }
        public byte[] DP { get; set; }
        public byte[] DQ { get; set; }
        public byte[] InverseQ { get; set; }
        public byte[] D { get; set; }
    }
}