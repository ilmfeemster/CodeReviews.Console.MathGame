public class GameEngine
{
    // Create a list of GameResult to store the history of game results
    private List<GameResult> gameHistory = new List<GameResult>();
    public void StartGame()
    {
        //This is a terminal based menu for a simple math game.
        bool menuActive = true;

        Console.WriteLine("Welcome, make a selection:");

        while (menuActive)
        {
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Show Game History");
            Console.WriteLine("6. Exit");

            string input = Console.ReadLine(); // Gather user input

            switch (input)
            {
                case "1":
                    Console.WriteLine("Addition selected. \n");
                    GenerateAddition();
                    break;
                case "2":
                    Console.WriteLine("Subtraction selected. \n");
                    GenerateSubtraction();
                    break;
                case "3":
                    Console.WriteLine("Multiplication selected. \n");
                    GenerateMultiplication();
                    break;
                case "4":
                    Console.WriteLine("Division selected. \n");
                    GenerateDivision();
                    break;
                case "5":
                    Console.WriteLine("Showing game history. \n");
                    GetGameHistory();
                    break;
                case "6":
                    Console.WriteLine("Exiting the game.");
                    menuActive = false;
                    break;
            }

            Console.WriteLine("Select an option:");
        }
    }

    // Methods to generate math problems and check answers
    private GameResult GenerateAddition()
    {
        int[] numbers = GenerateRandomNumbers("addition");
        int answer = numbers[0] + numbers[1];
        Console.WriteLine($"What is {numbers[0]} + {numbers[1]}?");
        int userAnswer = int.Parse(Console.ReadLine());
        GameResult result = new GameResult
        {
            Equation = $"{numbers[0]} + {numbers[1]}",
            UserAnswer = userAnswer,
            Result = userAnswer == answer
        };
        Console.WriteLine($"{result.GetResultString()} \n");
        gameHistory.Add(result);
        return result;
    }

    private GameResult GenerateSubtraction()
    {
        int[] numbers = GenerateRandomNumbers("subtraction");
        int answer = numbers[0] - numbers[1];
        Console.WriteLine($"What is {numbers[0]} - {numbers[1]}?");
        int userAnswer = int.Parse(Console.ReadLine());
        GameResult result = new GameResult
        {
            Equation = $"{numbers[0]} - {numbers[1]}",
            UserAnswer = userAnswer,
            Result = userAnswer == answer
        };
        Console.WriteLine($"{result.GetResultString()} \n");
        gameHistory.Add(result);
        return result;
    }

    private GameResult GenerateMultiplication()
    {
        int[] numbers = GenerateRandomNumbers("multiplication");
        int answer = numbers[0] * numbers[1];
        Console.WriteLine($"What is {numbers[0]} * {numbers[1]}?");
        int userAnswer = int.Parse(Console.ReadLine());
        GameResult result = new GameResult
        {
            Equation = $"{numbers[0]} * {numbers[1]}",
            UserAnswer = userAnswer,
            Result = userAnswer == answer
        };
        Console.WriteLine($"{result.GetResultString()} \n");
        gameHistory.Add(result);
        return result;
    }

    private GameResult GenerateDivision()
    {
        int[] numbers = GenerateRandomNumbers("division");
        int answer = numbers[0] / numbers[1];
        Console.WriteLine($"What is {numbers[0]} / {numbers[1]}?");
        int userAnswer = int.Parse(Console.ReadLine());
        GameResult result = new GameResult
        {
            Equation = $"{numbers[0]} / {numbers[1]}",
            UserAnswer = userAnswer,
            Result = userAnswer == answer
        };
        Console.WriteLine($"{result.GetResultString()} \n");
        gameHistory.Add(result);
        return result;
    }

    // Method to generate random numbers based for game problems
    private int[] GenerateRandomNumbers(string operation)
    {
        Random random = new Random();
        int[] numbers = new int[2];
        if (operation == "division")
        {
            // Ensure the second number is not zero to avoid division by zero
            numbers[0] = random.Next(0, 101);
            numbers[1] = random.Next(1, 101);

            while (numbers[0] < numbers[1])
            {
                numbers[0] = random.Next(0, 101);
            }
            //Trim the first number to be a divisable number
            numbers[0] = numbers[0] - (numbers[0] % numbers[1]);
            return numbers;
        }
        else if (operation == "subtraction")
        {
            // Ensure the first number is greater than the second to avoid negative results
            numbers[0] = random.Next(0, 101);
            numbers[1] = random.Next(0, 101);

            while (numbers[0] < numbers[1])
            {
                numbers[0] = random.Next(0, 101);
            }
            return numbers;
        }
        else
        {
            numbers[0] = random.Next(0, 101);
            numbers[1] = random.Next(0, 101);
            return numbers;
        }
    }
    // Method to retrieve the game history
    public void GetGameHistory()
    {
        if (gameHistory.Count == 0)
        {
            Console.WriteLine("No game history available.");
        }
        else
        {
            foreach (var result in gameHistory)
            {
                Console.WriteLine(result.ToString());
            }
        }
        Console.WriteLine("\n");
    }
}