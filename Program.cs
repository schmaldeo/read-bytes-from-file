class Program
{
    public static async Task Main(string[] args)
    {
        var text = await File.ReadAllBytesAsync(args[0] ?? throw new ArgumentNullException(nameof(args), "No file specified"));

        var outputPath = "./output.txt";
        try
        {
            outputPath = args[1];
        }
        catch (IndexOutOfRangeException){}

        await using StreamWriter sw = new(outputPath);
        foreach (var b in text)
        {
            await sw.WriteLineAsync(b.ToString());
        }
    }
}