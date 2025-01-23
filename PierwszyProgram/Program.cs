Console.WriteLine(CalculateSum(10, 50));
Console.WriteLine(CalculateSum(1000, 7000));
SayHello();

int CalculateSum(int number1, int number2)
{
    int sum = number1 + number2;
    return sum;
}

void SayHello()
{
    Console.WriteLine("Hello, world");
}

int x = 50;           // Zmienna
const int y = 100;    // Stała
int sum = x + y;
Console.WriteLine(sum);
