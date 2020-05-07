using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Elemento
    {
        public int Num;

        public Elemento Dir;
        public Elemento Esq;

        public Elemento()
        {
            Num = 0;

            Dir = null;
            Esq = null;
        }
    }

    class Árvore
    {
        public Elemento Raiz;
        public Elemento Aux;

        public Árvore()
        {
            Raiz = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Árvore MinhaÁrvore = new Árvore();

            Elemento Novo;

            bool Achou;

            do
            {
                Novo = new Elemento();

                Console.Write("\n\nDigite um Número: ");
                Novo.Num = int.Parse(Console.ReadLine());

                if (MinhaÁrvore.Raiz == null)
                {
                    MinhaÁrvore.Raiz = Novo;
                }
                else
                {
                    MinhaÁrvore.Aux = MinhaÁrvore.Raiz;

                    Achou = false;

                    while (!Achou)
                    {
                        if (Novo.Num < MinhaÁrvore.Aux.Num)
                        {
                            if (MinhaÁrvore.Aux.Esq == null)
                            {
                                MinhaÁrvore.Aux.Esq = Novo;
                                Achou = true;
                            }
                            else
                            {
                                MinhaÁrvore.Aux = MinhaÁrvore.Aux.Esq;
                            }
                        }
                        else if (Novo.Num > MinhaÁrvore.Aux.Num)
                        {
                            if (MinhaÁrvore.Aux.Dir == null)
                            {
                                MinhaÁrvore.Aux.Dir = Novo;
                                Achou = true;
                            }
                            else
                            {
                                MinhaÁrvore.Aux = MinhaÁrvore.Aux.Dir;
                            }
                        }
                    }
                }

                Console.Write("\nInserir outro número? (ESC cancela...)");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Clear();

            Console.WriteLine("Listagem - EM ORDEM\n");

            ListarEMORDEM(MinhaÁrvore.Raiz);

            Console.ReadKey();
        }

        static void ListarEMORDEM(Elemento x)
        {
            if (x != null)
            {
                ListarEMORDEM(x.Esq);
                Console.Write("{0,7}", x.Num);
                ListarEMORDEM(x.Dir);
            }
        }
    }
}