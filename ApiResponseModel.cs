using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Codenation_DesafioReactNative
{
    public class ApiResponseModel
    {
        public int numero_casas { get; set; }
        public string token { get; set; }
        public string cifrado { get; set; }
        public string decifrado { get; set; }
        public string resumo_criptografico { get; set; }

        public ApiResponseModel() { }

        public string Salvar(string repostaDoDesafio)
        {
            var directoryPath = "C://Git//Codenation-DesafioReactNative//arquivos-do-desafio";
            var fileName = $"answer.json";

            File.WriteAllText(string.Format("{0}//{1}", directoryPath, fileName), repostaDoDesafio);

            return fileName;
        }
    }
}
