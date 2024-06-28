namespace Spotivy;

public class Playlist(string title, string creator, List<Song> songs)
    : SongCollection(title, creator, songs)
{
    public void Add(IPlayable playable)
    {
        switch (playable)
        {
            case Song song:
                Songs.Add(song);
                Console.WriteLine(
                    $"Added song '{song.Title}' to playlist '{Title}'.");
                break;
            case SongCollection songCollection:
                Songs.AddRange(songCollection.Songs);
                Console.WriteLine(
                    $"Added {songCollection.Title} to playlist {Title}.");
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    public void RemoveSong(string songTitle)
    {
        var songToRemove = Songs.Find(s => s.Title == songTitle);
        if (songToRemove == null)
        {
            Console.WriteLine($"Song with title '{songTitle}' not found in playlist.");
            return;
        }

        Songs.Remove(songToRemove);
        Console.WriteLine($"Removed song '{songToRemove.Title}' from playlist.");
    }
}