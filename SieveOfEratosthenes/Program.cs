namespace SieveOfEratosthenes;

static class Program
{
    static int Main(string[] args)
    {
        var isConsole = false;
        long searchValue;
        if (args.Length == 0)
        {
            Console.Write("Enter number to find primes for: ");
            var searchString = Console.ReadLine() ?? "0";
            searchValue = long.Parse(searchString);
        }
        else
        {
            searchValue = long.Parse(args[0]);
            isConsole = true;
        }

        if (searchValue <= 0)
        {
            Console.WriteLine($"{searchValue} is invalid.");
            return -1;
        }

        var isPrime = new bool[searchValue + 1];

        for (var index = 0; index < isPrime.Length; index++)
        {
            isPrime[index] = true;
        }

        var sqrt = Math.Ceiling(Math.Sqrt(searchValue));

        for (var i = 2; i < sqrt; i++)
        {
            if (!isPrime[i]) continue;
            for (var j = i * i; j <= searchValue; j += i)
            {
                isPrime[j] = false;
            }
        }

        List<string> writeToFile = [];
        for (var i = 2; i < isPrime.Length; i++)
        {
            if (!isPrime[i]) continue;
            if (!isConsole)
            {
                Console.WriteLine(i);
            }
            else
            {
                writeToFile.Add(i.ToString());
            }
        }

        if (isConsole)
        {
            File.WriteAllLines(@"D:\\out.txt", writeToFile);
        }

        return 0;
    }
}