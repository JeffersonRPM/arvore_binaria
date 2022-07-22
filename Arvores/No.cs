using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Arvores
{
    public class No
    {
        public int valor;
        private No esquerda;
        private No direita;

        public No(int valor)
        {
            this.valor = valor;
            this.esquerda = null;
            this.direita = null;
        }

        public static void imprimi(No arvore,StreamWriter saida = null)
        {
            /* if(saida!=null) saida.WriteLine(arvore.valor);

             Console.WriteLine(arvore.valor);
             if (arvore.esquerda != null)
             {
                 imprimi(arvore.esquerda,saida);
             }
             if(arvore.direita != null)
             {
                 imprimi(arvore.direita,saida);
             }
             */
            List<int> vet = new List<int>();
            PassaPraVet(arvore,vet);
            vet.Sort();
            foreach(int z in vet)
            {
                Console.WriteLine(z);
                saida.WriteLine(z);
            }
        }

        public static No ConstroiArvore(No novo , No arvore)
        {
            if (arvore == null)
            {
                arvore = novo;
            }
            else
            {
                if (novo.valor < arvore.valor)
                {
                    if(arvore.esquerda == null)
                    {
                        arvore.esquerda = novo;
                    }
                    else
                    {
                        ConstroiArvore(novo, arvore.esquerda);
                    }
                }
                else
                {
                    if(arvore.direita == null)
                    {
                        arvore.direita = novo;
                    }
                    else
                    {
                        ConstroiArvore(novo, arvore.direita);
                    }
                }
            }
            return arvore;
        }

        public static bool Busca(No arvore, int valor)
        {
            bool achar = false;
            if(arvore == null) //nao achou
            {
                achar = false;
            }
            else
            {
                if(arvore.valor == valor) //achou o no
                {
                    achar = true;
                }
                else if (arvore.valor > valor)
                {
                    achar = Busca(arvore.esquerda, valor);
                }
                else
                {
                    achar = Busca(arvore.direita, valor);
                }
            }
            return achar;
        }

       public static No insereBalanceado(List<int> nums, int left, int right, No arvore)
        {
            int middle = (left + right) / 2;
            No no = new No(nums[middle]);
            if (No.Busca(arvore, no.valor) == false)
            {
                arvore = No.ConstroiArvore(no, arvore);
            }

            if (middle > left && middle != right)
            {
                // Console.WriteLine("direita {0} lines.", nums[middle]);
                insereBalanceado(nums, left, middle - 1, arvore);

            }
            if (middle < right && middle != left)
            {
                // Console.WriteLine("esquerda {0} lines.", nums[middle]);
                insereBalanceado(nums, middle + 1, right, arvore);
            }

            return arvore;
        }
        public static No balanceio(No arvore, List<int> nums)
        {
            arvore = insereBalanceado(nums, 0, nums.Count - 1, arvore);
            foreach (int x in nums)
            {
                No nono = new No(x);
                if (No.Busca(arvore, nono.valor) == false)
                {
                    arvore = No.ConstroiArvore(nono, arvore);
                }
            }
            return arvore;
        }

        public static No Remover(No arvore, int valor)
        {
            List<int> NumArvore = new List<int>();
            List<int> NewArvore = new List<int>();
            if (arvore == null)
            {
                Console.WriteLine("Arvore vazia");
            }
            NumArvore = PassaPraVet(arvore,NumArvore);
            foreach(int x in NumArvore)
            {
                if(x!= valor)
                {
                    NewArvore.Add(x);
                }
            }
            NewArvore.Sort();
            arvore = null;
            arvore = balanceio(arvore, NewArvore);
            return arvore;
        }

        public static No Insere(No arvore, int valor)
        {
            List<int> NumArvore = new List<int>();
            if (arvore == null)
            {
                Console.WriteLine("Arvore vazia");
            }
            NumArvore = PassaPraVet(arvore, NumArvore);

            NumArvore.Add(valor);
            NumArvore.Sort();

            arvore = null;
            arvore = balanceio(arvore, NumArvore);
            return arvore;
        }

        public static List<int> PassaPraVet(No no, List<int> NumArvore)
        {
            NumArvore.Add(no.valor);
            if (no.esquerda != null)
            {
                PassaPraVet(no.esquerda, NumArvore);
            }
            if (no.direita != null)
            {
                PassaPraVet(no.direita, NumArvore);
            }
            return NumArvore;
        }

    }
}
