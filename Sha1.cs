using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation_DesafioReactNative
{
    public static class Sha1
    {
        public static string ObterResumoEmSha1(string textoDescriptografado)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(textoDescriptografado);
               
                System.Security.Cryptography.SHA1CryptoServiceProvider cryptoTransformSHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                
                string resumoEmSha1 = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "").ToLower();
                
                return resumoEmSha1;
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao obter o resumo em Sha1: {erro.Message}");
            }
        }
    }
}
