var random = new Random();
const int minGuess = 1;
const int maxGuess = 100;

RunApplication();

void RunApplication()
{
    var randomNumber = GenerateRandomNumber();
    var attempts = 0;
    int guess;

    do
    {
        guess = TakeIntInput("Enter Guess Between One and One-Hundred: ");
        AssessGuess(guess, randomNumber);
        attempts++;
    } while (guess != randomNumber);
    
    DisplayResults(randomNumber, attempts);
}

void AssessGuess(int guess, int target)
{
    if (guess > target)
    {
        Console.WriteLine("Too high.");
    }
    else if (guess < target)
    {
        Console.WriteLine("Too low.");
    }
}

int GenerateRandomNumber()
{
    return random.Next(minGuess, maxGuess);
}

void DisplayResults(int random, int attempts)
{
    Console.Clear();
    Console.WriteLine($"You guessed {random} correctly and it took you {attempts} attempts.");
}

int TakeIntInput(string message)
{
    while (true)
    {
        Console.Write(message);
        var input = Console.ReadLine();

        if (int.TryParse(input, out var output))
        {
            if (output is <= maxGuess and >= minGuess)
            {
                return output;
            }
            Console.WriteLine("Guess is out of range. Try again.");
        }
        else
        {
            Console.WriteLine("Input was not a number. Try again.");
        }
    }
}