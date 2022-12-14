/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
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

int height = getNumberFromUser("Задайте высоту массива: ");
int width = getNumberFromUser("Задайте ширину массива: ");
int start = getNumberFromUser("Задайте стартовое число генерации чисел: ");
int end = getNumberFromUser("Задайте конечное число генерации чисел: ");
double[,] newArray = NewRandomArray(height, width, start, end);
print2DArray(newArray);
