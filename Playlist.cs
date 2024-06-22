namespace Spotivy;

public class Playlist(string title, string artist, List<Song> songs)
    : SongCollection(title, artist, songs)
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