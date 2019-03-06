﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

namespace CAFirstTask
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            ResultGenerate(null);
            var finder = new BreadthFirstSearch();
            var (start, finish, matrix) = GetInputData(Console.ReadLine);
            var resultRoute = finder.GetRoute(start, finish, matrix);
            
            Console.WriteLine(ResultGenerate(resultRoute));
        }

        public static string ResultGenerate(List<Cell> route) => 
            route == null ? "N" : string.Join(Environment.NewLine, "Y", string.Join(Environment.NewLine, route));

        public static (Cell start, Cell finish, bool[,] matrix) GetInputData(Func<string> lineReader)
        {   
            var rowCount = int.Parse(lineReader().Trim());
            var columnCount = int.Parse(lineReader().Trim());
            var matrix = new bool[rowCount, columnCount];

            for (int row = 0; row < rowCount; row++)
            {
                var currentRow = ReadLineToArray();
                for (int column = 0; column < columnCount; column++)
                    matrix[row, column] = int.Parse(currentRow[column].Trim()) == 0;
            }

            var startAsArray = ReadLineToArray();
            var start = new Cell(int.Parse(startAsArray[0]) - 1, int.Parse(startAsArray[1]) - 1);
            var finishAsArray = ReadLineToArray();
            var finish = new Cell(int.Parse(finishAsArray[0]) - 1, int.Parse(finishAsArray[1]) - 1);

            return (start, finish, matrix);

            string[] ReadLineToArray() => Regex.Split(lineReader(), @"\W+")
                                               .Where(str => str.Length > 0)
                                               .ToArray();
        }
    }
}