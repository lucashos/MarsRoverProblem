using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rovers
{
    class Program
    {
        enum Ponto {N = 0,E = 1,S = 2 ,W = 3}

        static void Main(string[] args)
        {
            Ponto direcao;            
            int[] quadrante = new int [2];
            int[] posicao = new int[2];

            int sondas = 2;

            //Declaração do tamanho do perímetro
            setTamanho(quadrante, Console.ReadLine().Split(' '));

            while (sondas--!= 0)
            {                
                //Declaração da posição da Sonda e sua orientação
                direcao = setPosition(posicao, Console.ReadLine().ToUpper().Split(' '));
                //Direcionamento da Sonda conforme comandos                   
                direcao = move(Console.ReadLine().ToUpper(), posicao, direcao);
                //Posição final da sonda.
                Console.WriteLine(posicao[0] + " " + posicao[1] + " " + direcao);
                //Caso a sonda ultrapasse o perímetro
                if (posicao[0] > quadrante[0] && posicao[1] > quadrante[1])
                {
                    Console.WriteLine("Sonda fora do perímetro.");
                }
            }
            Console.ReadKey();
        }

        //Tamanho do perímetro
        static void setTamanho(int []tamanho,string[] s)
        {
            try
            {
                int i = 0;
                foreach (string sqr in s)
                {
                    tamanho[i] = Convert.ToInt32(sqr);
                    i++;
                }
            }
            catch
            {
                Console.WriteLine("Insira os dados corretamente - Coordenadas X Y.");
            }
        }

        //Declaração de Posição
        static Ponto setPosition(int[] posicao, string[] s)
        {
            try
            {
                int i = 0;
                foreach (string sqr in s)
                {
                    if (i < 2)
                    {
                        posicao[i++] = Convert.ToInt32(sqr);
                    }
                    else if (i == 2)
                    {
                        if (Convert.ToChar(sqr) == 'N')
                        {
                            return Ponto.N;
                        }
                        else if (Convert.ToChar(sqr) == 'E')
                        {
                            return Ponto.E;
                        }
                        else if (Convert.ToChar(sqr) == 'S')
                        {
                            return Ponto.S;
                        }
                        else if (Convert.ToChar(sqr) == 'W')
                        {
                            return Ponto.W;
                        }



                    }
                }
                return Ponto.N;
            } catch{
                Console.WriteLine("Deve ser dada a coordenada do rover");
                return Ponto.N;
            }
                

        }

        //Movimentação
        static Ponto move(string comando, int[] posicao, Ponto direcao)
        {
            try
            {
                //Sequencia de comandos dados à sonda.
                for (int i = 0; i < comando.Length; i++)
                {
                    //Virar 90º à esquerda
                    if (comando[i] == 'L')
                    {
                        direcao--;
                        if ((int)direcao == -1)
                        {
                            direcao = Ponto.W;
                        }
                        else if ((int)direcao == -2)
                        {
                            direcao = Ponto.S;
                        }
                        else if ((int)direcao == -3)
                        {
                            direcao = Ponto.E;
                        }
                        else if ((int)direcao == -4)
                        {
                            direcao = Ponto.N;
                        }
                    }
                    //Virar 90º à direita
                    else if (comando[i] == 'R')
                    {
                        direcao++;
                        if ((int)direcao == 4)
                        {
                            direcao = Ponto.N;
                        }
                    }
                    //M = Mover-se
                    else if (comando[i] == 'M')
                    {
                        if (direcao == Ponto.N)
                        {
                            posicao[1]++;
                        }
                        else if (direcao == Ponto.S)
                        {
                            posicao[1]--;
                        }
                        else if (direcao == Ponto.E)
                        {
                            posicao[0]++;
                        }
                        else if (direcao == Ponto.W)
                        {
                            posicao[0]--;
                        }
                    }
                }
                return direcao;
            }
            catch
            {
                return Ponto.N;
            }
        }

    }
}

