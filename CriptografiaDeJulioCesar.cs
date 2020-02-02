using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation_DesafioReactNative
{
    public static class CriptografiaDeJulioCesar
    {
        private static char[] AlfabetoArray = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q','r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        private static string TextoCriptografado;
        private static int QuantidadeDeCasas = 0;

        public static string DescriptografarTexto(string textoCriptografado, int quantidadeDeCasas) 
        {
            TextoCriptografado = textoCriptografado;
            QuantidadeDeCasas = quantidadeDeCasas;

            var textoDescriptografado = new List<char>();

            foreach (var letra in TextoCriptografado)
            {
                var posicaoDaLetraSubstituta = 0;
                char novaLetra;

                var posicaoDaLetra = Array.IndexOf(AlfabetoArray, letra);

                if(posicaoDaLetra != -1)
                {
                    posicaoDaLetraSubstituta = ObterPosicaoDaLetraSubstituta(posicaoDaLetra);

                    novaLetra = AlfabetoArray[posicaoDaLetraSubstituta];
                }
                else
                {
                    novaLetra = letra;
                }

                textoDescriptografado.Add(novaLetra);
            }

            return string.Join(null, textoDescriptografado);
        }

        private static int ObterPosicaoDaLetraSubstituta(int posicaoDaLetra)
        {
            var indiceFinalDoArrayDoAlfabeto = AlfabetoArray.Length;
            var posicaoDaLetraSubstituta = posicaoDaLetra - QuantidadeDeCasas;
            
            if (posicaoDaLetraSubstituta < 0)
            {
                posicaoDaLetraSubstituta = indiceFinalDoArrayDoAlfabeto - (posicaoDaLetraSubstituta*-1);
            }

            return posicaoDaLetraSubstituta;
        }
    }
}
