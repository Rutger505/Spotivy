namespace Spotivy;

public class Playlist(string title, string creator, List<Song> songs)
    : SongCollection(title, creator, songs)
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