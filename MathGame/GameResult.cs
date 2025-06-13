public class GameResult
{
    public string Equation { get; set; }
    public int UserAnswer { get; set; }

    public bool Result { get; set; }
    public DateTime Timestamp { get; set; }

    public GameResult()
    {
        Timestamp = DateTime.Now;
    }

    public string GetResultString()
    {
        return Result ? "Correct" : "Incorrect";
    }

    public override string ToString()
    {
        return $"{Timestamp}: {Equation} Answered: {UserAnswer}, Result = {Result}";
    }
}