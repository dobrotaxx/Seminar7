/*
Задача 52. Задайте двумерный массив из целых чисел. 
Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

int getNumberFromUser(string userInformation)
{
    int result = 0;
    while (result == 0)
    {
        Console.Write(userInformation);
        string userLine = Console.ReadLine();
        int.TryParse(userLine, out result);
        if (result == 0 && userLine != "0")
        {
            Console.WriteLine($"Ошибка ввода! Введите целое число: [{userLine}].");
        }
        else
        {
            break;
        }
    }
    return result;
}

double GetRandomNumber(double minimum, double maximum) //генерация вещественных рандомных чисел
{
    Random random = new Random();
    return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, 2);
}

double[,] NewRandomArray(int lengthHeight, int lengthWidth, int startPoint, int endPoint)
{
    double[,] array = new double[lengthHeight, lengthWidth];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = GetRandomNumber(startPoint, endPoint);
        }
    }
    return array;
}

void PrintColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(data);
    Console.ResetColor();
}

void print2DArray(double[,] arrayTwoPrint)
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

double[] FindAverageOfColumn(double[,] array)
{
    double[] averageOfColumn = new double[array.GetLength(1)];
    int k = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            averageOfColumn[k] += array[i, j];
        }
        averageOfColumn[k] /= array.GetLength(0);
        averageOfColumn[k] = Math.Round(averageOfColumn[k],2);
        k++;
    }
    return averageOfColumn;
}

void printArray(double[] incomingArray) //печатаем массив
{
    Console.Write("Cреднее арифметическое элементов в каждом столбце. [");
    for (int i = 0; i < incomingArray.Length; i++)
    {
        Console.Write(incomingArray[i]);
        if (i < incomingArray.Length - 1)
        {
            Console.Write(", ");
        }
    }
    Console.Write("]");
    Console.WriteLine();
}

int height = getNumberFromUser("Задайте высоту массива: ");
int width = getNumberFromUser("Задайте ширину массива: ");
int start = getNumberFromUser("Задайте стартовое число генерации чисел: ");
int end = getNumberFromUser("Задайте конечное число генерации чисел: ");
double[,] newArray = NewRandomArray(height, width, start, end);
print2DArray(newArray);
double[] averageOfColumn = FindAverageOfColumn(newArray);
printArray(averageOfColumn);