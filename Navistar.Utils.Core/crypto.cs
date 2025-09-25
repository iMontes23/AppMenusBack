using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Navistar.Utils.Core
{
    public class crypto
    {
        private static string stringKey;

        private static string stringIV;

        private static byte[] MakeKeyByteArray()
        {
            if ((stringKey.Length < 8))
            {
                stringKey = stringKey.PadRight(8);
            }
            else if ((stringKey.Length > 8))
            {
                stringKey = stringKey.Substring(0, 8);
            }

            return Encoding.UTF8.GetBytes(stringKey);
        }

        private static byte[] MakeIVByteArray()
        {
            if ((stringIV.Length < 8))
            {
                stringIV = stringIV.PadRight(8);
            }
            else if ((stringIV.Length > 8))
            {
                stringIV = stringIV.Substring(0, 8);
            }

            return Encoding.UTF8.GetBytes(stringIV);
        }

        public static string CifrarCadena(string CadenaOriginal, string llave = "12345678", string vectorI = "ESTEESEL")
        {
            stringKey = llave;
            stringIV = vectorI;
            MemoryStream memStream = null;
            try
            {
                // CadenaOriginal = CadenaOriginal.Replace("+", "@@12")
                if ((!(stringKey == null)
                            && !(stringIV == null)))
                {
                    byte[] textoPlano = Encoding.UTF8.GetBytes(CadenaOriginal);
                    memStream = new MemoryStream((CadenaOriginal.Length * 2));
                    byte[] vkey = crypto.MakeKeyByteArray();
                    byte[] vIV = crypto.MakeIVByteArray();
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    ICryptoTransform transform = des.CreateEncryptor(vkey, vIV);
                    CryptoStream cs = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                    cs.Write(textoPlano, 0, textoPlano.Length);
                    cs.Close();
                }
                else
                {
                    throw new Exception("Error al inicializar la clave y el vector");
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return Convert.ToBase64String(memStream.ToArray());
        }

        public static string DescifrarCadena(string CadenaCifrada, string llave = "12345678", string vectorI = "ESTEESEL")
        {
            stringKey = llave;
            stringIV = vectorI;
            MemoryStream memStream = null;
            try
            {
                if ((!(stringKey == null)
                            && !(stringIV == null)))
                {
                    byte[] textoCifrado = Convert.FromBase64String(CadenaCifrada);
                    memStream = new MemoryStream(CadenaCifrada.Length);
                    byte[] vkey = crypto.MakeKeyByteArray();
                    byte[] vIV = crypto.MakeIVByteArray();
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    ICryptoTransform transform = des.CreateDecryptor(vkey, vIV);
                    CryptoStream cs = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                    cs.Write(textoCifrado, 0, textoCifrado.Length);
                    cs.Close();
                }
                else
                {
                    throw new Exception("Error al inicializar la clave y el vector.");
                }

            }
            catch (Exception ex)
            {

            }


            try
            {
                return Encoding.UTF8.GetString(memStream.ToArray());
            }
            catch (System.Exception End2)
            {

            }
            return "";
        }
    }
}
