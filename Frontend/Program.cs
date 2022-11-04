using AdippNet;
using AdippNet.Models;

var plugin = new Adipp();
plugin.AddAction(MyFunc);
plugin.AddAction(MyFunc2);
plugin.Run();

void MyFunc(IEnumerable<BinaryUniqueFile> binaryUniqueFiles)
{
    foreach (var file in binaryUniqueFiles.Where(file => file.FileSize > 10000))
    {
        file.AddBookmark(new Bookmark { Path = "CustomBookmarks", Name = file.FileClass });
        var aspectRatio = file.Width / file.Height;
        file.AddCustomProperty(new CustomProperty { Id = 1, Value = aspectRatio.ToString() });
    }
}

void MyFunc2(BinaryUniqueFile file)
{
    file.AddBookmark(new Bookmark {Name = "so und so!"});
}