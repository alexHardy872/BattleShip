﻿using System;
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
        private int boardSize;
        public int BoardSize
        {
            get
            {
                return boardSize;
            }
        }


        public Grid(int gridSize)
        {
            boardSize = gridSize;
            stringGrid = new string[boardSize, boardSize];             
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
            Console.ForegroundColor = ConsoleColor.Black;
                for (int i = 0; i < stringGrid.GetLength(0)+1; i++)
            {
                if ( i < 11)
                {
                     if (i == 0)
                    {
                        Console.Write("  ");
                    }
                     else
                    {
                        Console.Write(" " + (i-1) + " ");
                    }               
                }  
                else
                {
                    Console.Write((i-1)+" ");
                }            
            }
            Console.ResetColor();
            Console.WriteLine();


                for (int i = 0; i < stringGrid.GetLength(0); i++)
                {

                if (i >= 10 )
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write((i));
                    Console.ResetColor();
                }
            
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" " +(i));
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
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.Write(spot);                              
                            }                  
                     }
                Console.ResetColor();
                      Console.WriteLine();
                }
                
            }


        }


    }

