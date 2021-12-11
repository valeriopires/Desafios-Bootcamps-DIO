/*
->Proposta
Validador de senhas seguindo alguns requisitos.

Requisitos para o cadastro de senhas:
* A senha deve conter, no mínimo, uma letra maiúscula, uma letra minúscula e um número;
* A mesma não pode ter nenhum caractere de pontuação, acentuação ou espaço;
* Além disso, a senha pode ter de 6 a 32 caracteres.

->Entrada

A entrada contém vários casos de teste de acordo com a decisão do usuário. Cada linha tem uma string S, correspondente a senha que é inserida pelo usuário no momento do cadastro.

->Saída

A saída contém uma linha, que pode ser “Senha valida.”, caso a senha tenha cada item dos requisitos solicitados anteriormente, ou “Senha invalida.”, se um ou mais requisitos não forem atendidos.

*/

using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace App.ValidaSenhas
{
    class Solucao
    {
        static void Main(string [] args)    
        {   
            int numeroDeCasosTestes = int.Parse(Console.ReadLine());
            List<string> listDeSenhas = new List<string>();

            if(numeroDeCasosTestes > 0){
                for(int i = 0; i < numeroDeCasosTestes; i++){
                    string strSenha = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(strSenha)) return;

                    listDeSenhas.Add(strSenha);
                }
                Console.WriteLine();

                foreach(string senha in listDeSenhas)
                   Console.WriteLine("Senha {0}!", ValidarSenha(senha) ? "válida": "inválida");         
            } 

            Console.ReadKey();     
        }    
        static bool ValidarSenha(string passWord)    
        {    
            int requisitosValidos = 0;  
            if(passWord.Length < 6 || passWord.Length > 32){
                return false;
            } 

            if(passWord != passWord.RemoveAccents()){
                return false;
            } 

            foreach(char c in passWord) //Busca em todo o array de strings por uma ocorrência de letra minúscula do alfabeto de a-z  
            {    
                if (c >= 'a' && c <= 'z')    
                {    
                    requisitosValidos++;    
                    break;    
                }     
            }     
            foreach(char c in passWord) //Busca em todo o array de strings por uma ocorrência de letra maiúscula do alfabeto de A-Z  
            {    
                if (c >= 'A' && c <= 'Z')    
                {    
                    requisitosValidos++;    
                    break;    
                }     
            }     
            if (requisitosValidos == 1) return false;     
            foreach(char c in passWord) //Busca em todo o array de strings por uma ocorrência de número entre 0 e 9  
            {    
                if (c >= '0' && c <= '9')    
                {    
                    requisitosValidos++;    
                    break;    
                }     
            } 

            if (requisitosValidos == 2) return false; 
            if (requisitosValidos == 3){
                char[] charNaoPermitido = {'.', ',', ';', ':', '^', '~', '?', '!', ' ', '´', '`'};
                if(passWord.IndexOfAny(charNaoPermitido) > -1) return false;
            }
  
            return true;    
        } 
    }

    public static class Helper
    {
        public static string RemoveAccents(this string text){   
            StringBuilder sbReturn = new StringBuilder();   
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText){   
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);   
            }   
            return sbReturn.ToString();   
        } 
    }

}
