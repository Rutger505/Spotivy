using Spotivy;

public class SpotivyClient(List<Song> songs, List<Album> albums, List<User> users)
{
    List<Song> songs = songs;
    List<Album> albums = albums;
    List<User> users = users;

    Song? selectedSong;

    public void SelectSongBasedOnTitle(string name)
    {
        var foundSong = songs.Find(song => song.Title == name);
        if (foundSong == null)
        {
            Console.WriteLine($"Song with title '{name}' not found.");
            return;
        }

        selectedSong = foundSong;
        Console.WriteLine($"Selected song: {selectedSong.Title}");
    }
}