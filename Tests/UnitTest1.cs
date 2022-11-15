using AdippNet;
using AdippNet.Models;

namespace Tests;

public class Tests
{
    [Test]
    public void AccessDataFromFrontendFunc()
    {
        // Arrange
        
        void GetModelsProperties(List<MediaFile> mediaFiles)
        {
            foreach (var file in mediaFiles)
            {
                dynamic? placeholder;
                placeholder = file.AppData;
                placeholder = file.Bookmarks;
                placeholder = file.Comments;
                placeholder = file.DataBaseMatches;
                placeholder = file.Distributed;
                placeholder = file.Exif;
                placeholder = file.ExifSerialNumber;
                placeholder = file.ExifThumbnailCount;
                placeholder = file.FileClass;
                placeholder = file.Files;
                placeholder = file.FileSize;
                placeholder = file.HasSound;
                placeholder = file.Height;
                placeholder = file.InitialCategory;
                placeholder = file.IsAnimated;
                placeholder = file.Latitude;
                placeholder = file.Longitude;
                placeholder = file.Md5Hex;
                placeholder = file.MimeType;
                placeholder = file.NudityLevel;
                placeholder = file.OffenderIdentified;
                placeholder = file.PhotoDnaBase64;
                placeholder = file.Representative;
                placeholder = file.Series;
                placeholder = file.Sha1Hex;
                placeholder = file.Sha256Hex;
                placeholder = file.Sha384Hex;
                placeholder = file.Sha512Hex;
                placeholder = file.Tags;
                placeholder = file.VictimIdentified;
                placeholder = file.VideoLength;
                placeholder = file.VisualDuplicatesCount;
                placeholder = file.Width;
                placeholder = file.FilepathOriginal;
                placeholder = file.FilepathConverted;
                placeholder = file.OutputDirectory;
                placeholder = file.CustomPropertyValues;
            }
        }
        
        
        var cwd = AppDomain.CurrentDomain.BaseDirectory;
        var plugin = new Adipp(Path.Combine(cwd, "../../../test_input.json"));
        
        // Act
        plugin.AddAction(GetModelsProperties);
        plugin.Run();
        
        // Assert
        Assert.Pass();
    }

    [Test]
    public void TestBookmarksAndCustomProperties()
    {
        // Arrange
        void AddBookmark(MediaFile file)
        {
            file.AddBookmark(new Bookmark {Name = "so und so!"});
        }

        void AddCustomProperty(MediaFile file)
        {
            file.AddCustomProperty(new CustomProperty(){Id = 0, Value = "ich bin ein Wert"});
        }
        
        var cwd = AppDomain.CurrentDomain.BaseDirectory;
        var plugin = new Adipp(Path.Combine(cwd, "../../../test_input.json"));
        
        // Act
        plugin.AddAction(AddBookmark);
        plugin.AddAction(AddCustomProperty);
        plugin.Run();
        plugin.DumpInput("test_dump.json");
        
        // Assert
        
        Assert.Pass();
    }

}