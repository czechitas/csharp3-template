public class FizzBuzz
{
    public void CountTo(int lastNumber)
    {
        for (int currentNumber = 1; currentNumber <= lastNumber; currentNumber++)
        {
            if (currentNumber % 3 == 0 && currentNumber % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
                continue;
            }
            if (currentNumber % 3 == 0)
            {
                Console.WriteLine("Fizz");
                continue;
            }
            if (currentNumber % 5 == 0)
            {
                Console.WriteLine("Buzz");
                continue;
            }
            Console.WriteLine(currentNumber);
        }
    }
}
