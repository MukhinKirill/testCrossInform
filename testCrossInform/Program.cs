using System;
using System.Collections.Generic;

namespace testCrossInform
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new List<int>();
            var maxI = 0;
            var maxJ = 0;
            int[,] table = new int[3, 3];
            bool IsCorrect = false;
            while (!IsCorrect)
            {
                Console.WriteLine("Введите 3 строки по 3 элемента от 1 до 9 в произвольном порядке, без повторений, разделенные пробелами");
                if(!IsCorrect)
                {
                    table = new int[3, 3];
                    IsCorrect = true;
                    result.Clear();
                }
                for (int i = 0; i < 3; i++)
                {
                    var str = Console.ReadLine();
                    var line = str.Split(' ');
                    if(line.Length != 3)
                    {
                        Console.WriteLine("Некорректные данные, смотри условия задачи");
                        IsCorrect = false;
                        break;
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        var item = Convert.ToInt32(line[j]);
                        if ((result.Contains(item) || item < 1 || item > 9) && IsCorrect)
                        {
                            Console.WriteLine("Некорректные данные, смотри условия задачи");
                            IsCorrect = false;
                            break;
                        }
                        table[i, j] = item;
                        result.Add(item);
                        //запоминаем максимум, который не находится рядом с центром, иначе заблудимся и не обойдем все элементы
                        if (item > table[maxI, maxJ] && (i + j) % 2 == 0)
                        {
                            maxI = i;
                            maxJ = j;
                        }
                    }
                }
                
            }
            result.Clear();
            Console.WriteLine("Наша таблица:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
            var currentI = maxI;
            var currentJ = maxJ;
            result.Add(table[currentI, currentJ]);
            while (result.Count < 9)
            {
                var localMax = 0;
                var isSwap = true;
                while (isSwap)
                {
                    //ищем куда пойти по вертикали
                    isSwap = false;
                    switch (currentI)
                    {
                        case 0:
                            if (table[currentI + 1, currentJ] > localMax && !result.Contains(table[currentI + 1, currentJ]))
                            {
                                localMax = table[currentI + 1, currentJ];
                                maxI = currentI + 1;
                                maxJ = currentJ;
                                isSwap = true;
                            }
                            break;
                        case 1:
                            if (table[currentI - 1, currentJ] > localMax && !result.Contains(table[currentI - 1, currentJ]))
                            {
                                localMax = table[currentI - 1, currentJ];
                                maxI = currentI - 1;
                                maxJ = currentJ;
                                isSwap = true;
                            }
                            if (table[currentI + 1, currentJ] > localMax && !result.Contains(table[currentI + 1, currentJ]))
                            {
                                localMax = table[currentI + 1, currentJ];
                                maxI = currentI + 1;
                                maxJ = currentJ;
                                isSwap = true;
                            }
                            break;
                        case 2:
                            if (table[currentI - 1, currentJ] > localMax && !result.Contains(table[currentI - 1, currentJ]))
                            {
                                localMax = table[currentI - 1, currentJ];
                                maxI = currentI - 1;
                                maxJ = currentJ;
                                isSwap = true;
                            }
                            break;
                    }
                    //ищем куда пойти по горизонтали
                    switch (currentJ)
                    {
                        case 0:
                            if (table[currentI, currentJ + 1] > localMax && !result.Contains(table[currentI, currentJ + 1]))
                            {
                                localMax = table[currentI, currentJ + 1];
                                maxI = currentI;
                                maxJ = currentJ + 1;
                                isSwap = true;
                            }
                            break;
                        case 1:
                            if (table[currentI, currentJ - 1] > localMax && !result.Contains(table[currentI, currentJ - 1]))
                            {
                                localMax = table[currentI, currentJ - 1];
                                maxI = currentI;
                                maxJ = currentJ - 1;
                                isSwap = true;
                            }
                            if (table[currentI, currentJ + 1] > localMax && !result.Contains(table[currentI, currentJ + 1]))
                            {
                                localMax = table[currentI, currentJ + 1];
                                maxI = currentI;
                                maxJ = currentJ + 1;
                                isSwap = true;
                            }
                            break;
                        case 2:
                            if (table[currentI, currentJ - 1] > localMax && !result.Contains(table[currentI, currentJ - 1]))
                            {
                                localMax = table[currentI, currentJ - 1];
                                maxI = currentI;
                                maxJ = currentJ - 1;
                                isSwap = true;
                            }
                            break;
                    }
                }
                //делаем шаг на максимальеый элемент из находящихся рядом
                currentI = maxI;
                currentJ = maxJ;
                result.Add(table[currentI, currentJ]);
            }
            foreach (var item in result)
            {
                Console.Write(item);
            }
            Console.ReadKey();
        }
    }
}
