using System;
using System.Net.Http;

namespace Codenation_DesafioReactNative
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando Desafio Codenation - React Native...");

            var tokenDeAutenticacao = "42e01223c7f4cfe2362081e3c0d05e1974020ae6";

            try
            {
                ApiInfrastructure API = new ApiInfrastructure();

                var respostaDaChamada = API.ObterDadosDoDesafio(tokenDeAutenticacao);

                var apiRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponseModel>(respostaDaChamada);

                var respostaDodesafio = CriptografiaDeJulioCesar.DescriptografarTexto(apiRequest.cifrado.ToLower(), apiRequest.numero_casas);

                var resumoEmSha1 = Sha1.ObterResumoEmSha1(respostaDodesafio);

                apiRequest.decifrado = respostaDodesafio;
                apiRequest.resumo_criptografico = resumoEmSha1;

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(apiRequest);

                var nomeDoArquivo = apiRequest.Salvar(json);

                API.SubmeterRespostaDoDesafio(nomeDoArquivo, tokenDeAutenticacao);
            }
            catch(Exception erro)
            {
                Console.WriteLine(erro.Message);
            }
        }
    }
}
