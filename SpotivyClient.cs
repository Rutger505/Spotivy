using Spotivy;

public class SpotivyClient(List<Song> songs, List<Album> albums, List<User> users)
{
    List<Song> songs = songs;
    List<Album> albums = albums;
    List<User> users = users;

    private IPlayable? selectedSong;
    private User? selectedUser;

    public void SelectSong(string title)
    {
        var foundSong = songs.Find(song => song.Title == title);
        if (foundSong == null)
        {
            Console.WriteLine($"Song with title '{title}' not found.");
            return;
        }

        selectedSong = foundSong;
        Console.WriteLine($"Selected song: {foundSong.Title}");
    }

    public void SelectUser(string name)
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