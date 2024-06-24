namespace Spotivy;

public class Playlist(string title, string artist, string genre, List<Song> songs)
    : SongCollection(title, artist, genre, songs)
{
    public void AddSong(Song song)
    {
        throw new NotImplementedException();
    }

    public void RemoveSong(Song song)
    {
        throw new NotImplementedException();
    }
}