using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Grid
    {

        public string[,] stringGrid;





        public Grid()
        {

            stringGrid = new string[20, 20];
             
        }



        public void PopulateEmptyGrid()
        {
            for (int i = 0; i < stringGrid.GetLength(0); i++)
            {
                for (int j = 0; j < stringGrid.GetLength(1); j++)
                {
                    stringGrid[i, j] = "[ ]";                 
                } 
            }            
        }



        public void BuildGrid()

            {    // MARKERS

            Console.WriteLine();
                for (int i = 0; i < stringGrid.GetLength(0)+1; i++)
            {
                if ( i < 10)
                {
                     if (i == 0)
                    {
                        Console.Write("   ");
                    }
                     else
                    {
                        Console.Write(" " + i + " ");
                    }
                    
                }
              
                else
                {
                    Console.Write(i+" ");
                }
                
            }
            Console.WriteLine();



                for (int i = 0; i < stringGrid.GetLength(0); i++)
                {

                if (i >= 9 )
                {
                    Console.Write((i+1) + " ");
                }
                else
                {
                    Console.Write(" " +(i+1) +" ");
                }
               
                    for (int j = 0; j < stringGrid.GetLength(1); j++)
                    {                      
                        string spot = stringGrid[i, j];
                        Console.Write(spot);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }










        }


    }

