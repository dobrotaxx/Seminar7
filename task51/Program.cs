/*
Задача 51: Задайте двумерный массив. Найдите Сумма элементов главной диагонали.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Сумма элементов главной диагонали: 1+9+2 = 12
*/

void PrintColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(data);
    Console.ResetColor();
}

void print2DArray(int[,] arrayTwoPrint)
{
    Console.Write("\t");
    for (int i = 0; i < arrayTwoPrint.GetLength(1); i++)
    {
        PrintColorData(i + "\t");
    }
    Console.WriteLine();
    for (int i = 0; i < arrayTwoPrint.GetLength(0); i++)
    {
        PrintColorData(i + "\t");
        for (int j = 0; j < arrayTwoPrint.GetLength(1); j++)
        {
            Console.Write(arrayTwoPrint[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

int[] GetElemetsOfDiagonals(int[,] matrix) //получаем главную диагональ из 2D массива и записываем в одинарный массив
{
    int bound = Math.Min(matrix.GetLength(0), matrix.GetLength(1)); /*Просим сравнить два числа и отдать минимальное для
    того, чтобы было понимание чего у нас меньше столбцов или строк, что в свою очередь дает понимание, когда нам во время
    остановить цикл */
    int[] diagonal = new int[bound];
    for (int i = 0; i < bound; i++)
    {
        diagonal[i] = matrix[i, i];
    }
    return diagonal;
}

int GetSumOfDiagonals(int[] diagonal) //суммируем все элементы массива
{
    int sum = 0;
    for (int i = 0; i < diagonal.Length; i++)
    {
        sum+= diagonal[i];
    }
    return sum;
}

void PrintArrayWithSum(int[] diagonal) // печатаем массив с суммой
{
    Console.Write(diagonal[0]);//сначала выодится первое число в консоль
    for (int i = 1; i < diagonal.Length; i++)
    {
        Console.Write($"+{diagonal[i]}");// затем со знаком + выводятся другие числа
    }
    int sum = GetSumOfDiagonals(diagonal);
    Console.Write($" = {sum}"); // в конце после знака = выводится сумма, которую считает функция GetSumOfDiagonals(diagonal)
}

int[,] TwoDArray =
                    {
                        {1, 4, 7, 2},
                        {5, 9, 2, 3},
                        {8, 4, 2, 4}
                    };

print2DArray(TwoDArray);
Console.WriteLine();
int[] diagonal = GetElemetsOfDiagonals(TwoDArray);
PrintArrayWithSum(diagonal);

