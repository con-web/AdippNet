using System.Text;
using System.Text.Json;
using AdippNet.Models;
namespace AdippNet;


public class Adipp
{
    private readonly string? _inputString;
    private List<MediaFile>? _mediaFiles;
    private List<Action<List<MediaFile>>> BatchActions { get; } = new();
    private List<Action<MediaFile>> SingleActions { get; } = new();
    

    public Adipp()
    {
        _inputString = IO.ReadFromConsole();
    }
    
    public Adipp(string fileName)
    {
        _inputString = IO.ReadFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
    }
    

    public void AddAction(Action<List<MediaFile>> action)
    {
        BatchActions.Add(action);
    }

    public void AddAction(Action<MediaFile> action)
    {
        SingleActions.Add(action);
    }

    public void Run()
    {
        _mediaFiles = JsonSerializer.Deserialize<List<MediaFile>>(_inputString ?? throw new InvalidOperationException());
        var output = new Output();
        foreach (var action in BatchActions) action(_mediaFiles!);

        foreach (var mediaFile in _mediaFiles!)
        {
            foreach (var action in SingleActions) action(mediaFile);
            output.Bookmarks.AddRange(mediaFile.NewBookmarks);
            output.CustomProperties.AddRange(mediaFile.NewCustomProperties);
            
        }

        var outputString = JsonSerializer.Serialize(output);
        
        IO.WriteToConsole(outputString);
        
    }

    public void DumpInput(string fileName)
    {
        IO.WriteToFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName), _inputString!);
    }
    
}