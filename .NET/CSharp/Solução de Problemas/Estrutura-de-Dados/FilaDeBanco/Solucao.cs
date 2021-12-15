/*
>>>Desafio<<<

O banco que você trabalha sempre tem problemas para organizar as filas de atendimento dos clientes.

Após uma reunião com a gerência ficou decidido que os clientes ao chegar na agência receberão uma senha numérica em seu aparelho de celular via sms e que a ordem da fila será dada não pela ordem de chegada, mas sim pelo número recebido via sms. A ordem de atendimento será decrescente: aqueles que receberam número maior deverão ser atendidos primeiro. 

Então, dada a ordem de chegada dos clientes reordene a fila de acordo com o número recebido via sms, e diga quantos clientes não precisaram trocar de lugar nessa reordenação.

->Entrada

A primeira linha contém um inteiro N, indicando o número de casos de teste a seguir.

Cada caso de teste inicia com um inteiro M (1 ≤ M ≤ 1000), indicando o número de clientes.Em seguida haverá M inteiros distintos Pi (1 ≤ Pi ≤ 1000), onde o i-ésimo inteiro indica o número recebido via sms do i-ésimo cliente.

Os inteiros acima são dados em ordem de chegada, ou seja, o primeiro inteiro diz respeito ao primeiro cliente a chegar na fila, o segundo inteiro diz respeito ao segundo cliente, e assim sucessivamente.

->Saída

Para cada caso de teste imprima uma linha, contendo um inteiro, indicando o número de clientes que não precisaram trocar de lugar mesmo após a fila ser reordenada. 
*/

using System;
using System.Collections.Generic;

namespace FilaDeBanco
{
    class Solucao
    {
        static void Main(string[] args)
        {
            int nroCasosDeTeste = int.Parse(Console.ReadLine()), caso = 0; 
  
            while(caso < nroCasosDeTeste){
                if(caso > 1000) return;

                int nroClientesNaFila = int.Parse(Console.ReadLine()); 
                string[] clientes = Console.ReadLine().Split(' ');
                List<int> clientesNaFila = new List<int>();

                foreach (var cliente in clientes){
                    if(clientes.Length > 1000 || clientes.Length > nroClientesNaFila) return;
                    
                    clientesNaFila.Add(int.Parse(cliente));
                }

                int naoSofreramMudancaNaFila = 0;
                for(int i = 0; i < clientesNaFila.Count; i++){
                    if(clientesNaFila.Count > 1000) return;

                    int contador = i;
                    while(contador < clientesNaFila.Count){
                        if(clientesNaFila[i] < clientesNaFila[contador]){
                            var tempValorMenorPosicaoAtual = clientesNaFila[i];   
                            var tempValorMaiorPosicaoPosterior = clientesNaFila[contador];
                            
                            clientesNaFila[i] = tempValorMaiorPosicaoPosterior;  
                            clientesNaFila[contador] =  tempValorMenorPosicaoAtual; 
                        } 
                        contador++;
                    } 
                    
                    if(int.Parse(clientes[i]) == clientesNaFila[i]){
                        naoSofreramMudancaNaFila++;
                    } 
                }

                Console.WriteLine(naoSofreramMudancaNaFila);
                
                caso++;
            }
        }
    }
}
