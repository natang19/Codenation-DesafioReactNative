using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft;

namespace Codenation_DesafioReactNative
{
    public class ApiInfrastructure
    {
        private HttpClient HTTP = new HttpClient();

        public string ObterDadosDoDesafio(string meuTokenDeAutenticacao)
        {
            try
            {
                var url = "https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=" + meuTokenDeAutenticacao;

                var response = HTTP.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Consumo da API realizada com sucesso.");

                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    var msg = $"Ocorreu um erro ao consumir a API. \nErro: {response.Content.ReadAsStringAsync()}";

                    Console.WriteLine(msg);

                    return string.Empty;
                }
            }
            catch (Exception erro)
            {
                throw new Exception($"A chamada da API falhou: {erro}.");
            }
        }

        public void SubmeterRespostaDoDesafio(string fileName, string meuTokenDeAutenticacao)
        {
            var url = "https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=" + meuTokenDeAutenticacao;
            var caminhoDoArquivo = $"C://Git//Codenation-DesafioReactNative//arquivos-do-desafio//{fileName}";

            try
            {
                using var stream = File.OpenRead(@caminhoDoArquivo);
                using var content = new MultipartFormDataContent()
                {
                    { new StreamContent(stream), "answer", fileName }
                };

                content.Headers.ContentEncoding.Add("utf-8");

                var response = HTTP.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Submissão do arquivo: " + response.StatusCode + "\nNota: " + response.Content.ReadAsStringAsync());
                }
                else
                {
                    Console.WriteLine($"Erro ao submeter do arquivo: " + response.Content.ReadAsStringAsync());
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
