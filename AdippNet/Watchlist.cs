using System.Text.RegularExpressions;
using AdippNet.Models;

namespace AdippNet;

public class Watchlist
{
    private readonly List<WatchlistCategory> _watchlist;

    public Watchlist(string path)
    {
        var inputStream = IO.GetReadFileStream(path);
        _watchlist = Serializer.DeserializeFromStream<List<WatchlistCategory>>(inputStream);
    }

    public List<Bookmark> Search(string searchText, string watchlistName)
    {
        var searchResult = new List<Bookmark>();

        foreach (var category in _watchlist)
        {
            searchResult.AddRange(category.SearchTerms.Where(searchTerm => Regex
                .IsMatch(searchText, searchTerm, RegexOptions.IgnoreCase))
                .Select(searchTerm => new Bookmark
                {
                    Path = string.Join("/", watchlistName, category.Name), Name = searchTerm
                }));
        }

        return searchResult;

    }
}