using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Arvores
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            int i = 0, num;
            string line;
            
            //pega os numeros do arquivo txt e passa para uma lista de inteiros
            StreamReader file = new StreamReader(@"Num.txt");
            while ((line = file.ReadLine()) != null)
            {
                num = Convert.ToInt32(line);
                nums.Add(num);
                i++;
            }
            file.Close();

            //no q inicializa a arvore, raiz
             No arvore = null;  

            //monta a arvore 
            arvore = No.balanceio(arvore, nums);
           

            //cria arquivo de saida
            StreamWriter saida = new StreamWriter(@"saida.txt");
            
            //Printa a arvore no arquivo de saida e console
            saida.WriteLine("Exercicio 1)Balancear Arvore:");
            Console.WriteLine("Exercicio 1)Balancear Arvore:");
            No.imprimi(arvore, saida);
            saida.WriteLine();

            saida.WriteLine("Exercicio 2/ Desafio Busca,insercao e remocao:");
            Console.WriteLine("Exercicio 2/ Desafio Busca,insercao e remocao:");
            saida.WriteLine();
            //verifica se um numero esta(true) ou nao (false) na arvore
            Console.WriteLine("\n\n\nPesquisar numero");
            bool busca;
            saida.Write("Busca:");
            busca = No.Busca(arvore, Convert.ToInt32(Console.ReadLine()));
            if (busca == true)
            {
                Console.WriteLine("ACHOU");
                saida.WriteLine("ACHOU\n");
            }
            else
            {
                Console.WriteLine("NÂO ACHOU");
                saida.WriteLine("NAO ACHOU\n");
            }
            saida.WriteLine();

            //Insercao
            Console.WriteLine("Insercao:");
            saida.WriteLine("Insercao:");
            arvore = No.Insere(arvore,30);
            No.imprimi(arvore, saida);
            saida.WriteLine();

            //Remoção folha
            Console.WriteLine("Remoção:");
            saida.WriteLine("Remocao:");
            arvore = No.Remover(arvore, nums[0]);
            No.imprimi(arvore, saida);
            saida.WriteLine();

            //Remoção interna
            Console.WriteLine("Remoção:");
            saida.WriteLine("Remocao:");
            arvore = No.Remover(arvore, nums[nums.Count/2]);
            No.imprimi(arvore, saida);
            saida.WriteLine();

            saida.Close();
            Console.ReadLine();
            
        }
    
    }
}
