using Spotivy;

public class SpotivyClient(List<Song> songs, List<Album> albums, List<User> users)
{
    List<Song> songs = songs;
    List<Album> albums = albums;
    List<User> users = users;

    private IPlayable? selectedPlayable;
    private User? selectedUser;

    public void SelectSong(string title)
    {
        var foundSong = songs.Find(song => song.Title == title);
        if (foundSong == null)
        {
            Console.WriteLine($"Song with title '{title}' not found.");
            return;
        }

        selectedPlayable = foundSong;
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

    public void Play()
    {
        if (selectedPlayable == null)
        {
            Console.WriteLine("No song selected.");
            return;
        }

        if (selectedPlayable is Song song)
        {
            PlaySong(song);
        }
        else
        {
            throw new NotImplementedException("Playable type not implemented.");
        }
    }

    private void PlaySong(Song song)
    {
        Console.WriteLine($"Playing song: {song.Title}");
    }

    public void Pause()
    {
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                break;
            case Song song:
                PauseSong(song);
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    private void PauseSong(Song song)
    {
        Console.WriteLine($"Paused song: {song.Title}");
    }

    public void Resume()
    {
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                break;
            case Song song:
                ResumeSong(song);
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    private void ResumeSong(Song song)
    {
        Console.WriteLine($"Resumed song: {song.Title}");
    }
}