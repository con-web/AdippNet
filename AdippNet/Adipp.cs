using System.Text;
using System.Text.Json;
using AdippNet.Models;

namespace AdippNet;

public class Adipp
{
    private readonly List<BinaryUniqueFile>? _binaryUniqueFiles;

    public Adipp()
    {
        Console.InputEncoding = Encoding.UTF8;
        var inputString = Console.ReadLine();
        _binaryUniqueFiles =
            JsonSerializer.Deserialize<List<BinaryUniqueFile>>(inputString ?? throw new InvalidOperationException());
    }

    private List<Action<List<BinaryUniqueFile>>> BatchActions { get; } = new();
    private List<Action<BinaryUniqueFile>> SingleActions { get; } = new();

    public void AddAction(Action<List<BinaryUniqueFile>> action)
    {
        BatchActions.Add(action);
    }

    public void AddAction(Action<BinaryUniqueFile> action)
    {
        SingleActions.Add(action);
    }

    public void Run()
    {
        foreach (var action in BatchActions) action(_binaryUniqueFiles!);

        foreach (var action in SingleActions)
        {
            foreach (var file in _binaryUniqueFiles!)
            {
                action(file);
            }
        }

        var output = new Output();

        foreach (var file in _binaryUniqueFiles!)
        {
            output.Bookmarks.AddRange(file.NewBookmarks);
            output.CustomProperties.AddRange(file.NewCustomProperties);
        }

        Console.WriteLine(JsonSerializer.Serialize(output));
    }
}