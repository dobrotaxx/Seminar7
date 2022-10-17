/*
Задача 50. Напишите программу, которая на вход принимает позицию элемента в двумерном массиве, 
и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
17 -> такого числа в массиве нет
5 -> 9
2 -> 7
9 -> 4
индексы:
[0][1][2][3]
1 4 7 2
[4][5][6][7]
5 9 2 3
[8][9][10][11]
8 4 2 4
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

double[] New1DArray(double[,] array)
{
    double[] oneDArray = new double[array.GetLength(0) * array.GetLength(1)];
    int k = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            oneDArray[k] = array[i, j];
            k++;
        }

    }
    return oneDArray;
}

int height = getNumberFromUser("Задайте высоту массива: ");
int width = getNumberFromUser("Задайте ширину массива: ");
int start = getNumberFromUser("Задайте стартовое число генерации чисел: ");
int end = getNumberFromUser("Задайте конечное число генерации чисел: ");
double[,] newArray = NewRandomArray(height, width, start, end);
print2DArray(newArray);
double[] oneDArray = New1DArray(newArray);
int index = getNumberFromUser("Напишите индекс элемента, значение которого вы хотите увидеть: ");

if (index <= oneDArray.Length)
{
    Console.Write($"Значение элемента с индексом [{index}] -> {oneDArray[index]}");
}
else
{
    Console.Write($"Элемента с индексом [{index}] не существует, введите существующий индекс: ");
    while (index > oneDArray.Length)
    {
        string userLine = Console.ReadLine();
        int.TryParse(userLine, out index);
        if (index == 0 && userLine != "0" || index > oneDArray.Length)
        {
            Console.Write($"Элемента с индексом [{index}] не существует, введите существующий индекс: ");
        }
        else
        {
            break;
        }
    }
    Console.Write($"Значение элемента с индексом [{index}] -> {oneDArray[index]}");
}
