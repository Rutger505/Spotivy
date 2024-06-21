using Spotivy;

public class SpotivyClient(List<Song> songs, List<Album> albums, List<User> users)
{
    List<Song> songs = songs;
    List<Album> albums = albums;
    List<User> users = users;

    // todo make song playable
    private Song? selectedSong;
    private User? selectedUser;

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

    public void SelectUserBasedOnName(string name)
    {
        var foundUser = users.Find(user => user.Name == name);
        if (foundUser == null)
        {
            Console.WriteLine($"User with name '{name}' not found.");
            return;
        }

        selectedUser = foundUser;
        Console.WriteLine($"Selected user: {selectedUser.Name}");
    }
}