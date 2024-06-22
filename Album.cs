namespace Spotivy;

public class Album(string title, string creator, string genre, List<Song> songs)
    : SongCollection(title, creator, genre, songs)
{
}