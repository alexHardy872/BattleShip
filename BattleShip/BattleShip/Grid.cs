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
        public List<string> letters;





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
            Console.BackgroundColor = ConsoleColor.Gray;
                for (int i = 0; i < stringGrid.GetLength(0)+1; i++)
            {
                if ( i < 10)
                {
                     if (i == 0)
                    {
                        Console.Write("  ");
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
            Console.ResetColor();
            Console.WriteLine();



                for (int i = 0; i < stringGrid.GetLength(0); i++)
                {

                if (i >= 9 )
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write((i+1));
                    Console.ResetColor();
                }
            
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write(" " +(i+1));
                    Console.ResetColor();
                }
               
                    for (int j = 0; j < stringGrid.GetLength(1); j++)
                    {
                        Console.ResetColor();

                        

                        string spot = stringGrid[i, j];


                        if (spot == "[X]")
                            {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(spot);
                         }
                        else if (spot == "[M]")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(spot);
                    }
                        else if (spot == "[D]" || spot == "[S]" || spot == "[B]" || spot == "[A]")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black; 
                        Console.Write(spot);

                    }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(spot);
                                
                            }
                       
                     }
                Console.ResetColor();
                      Console.WriteLine();
                }
                Console.ReadLine();
            }










        }


    }

