using Spotivy;

public class SpotivyClient(
    List<Song> songs,
    List<Album> albums,
    List<User> users,
    User loggedInUser)
{
    private List<Song> songs = songs;
    private List<Album> albums = albums;
    private List<User> users = users;
    private User loggedInUser = loggedInUser;

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

    public void SelectAlbum(string title)
    {
        var foundAlbum = albums.Find(album => album.Title == title);
        if (foundAlbum == null)
        {
            Console.WriteLine($"Album with title '{title}' not found.");
            return;
        }

        selectedPlayable = foundAlbum;
        Console.WriteLine($"Selected album: {foundAlbum.Title}");
    }

    public void SelectPlaylist(string title)
    {
        var foundPlaylist = loggedInUser.Playlists.Find(playlist => playlist.Title == title);
        if (foundPlaylist == null)
        {
            Console.WriteLine($"Playlist with title '{title}' not found.");
            return;
        }

        selectedPlayable = foundPlaylist;
        Console.WriteLine($"Selected playlist: {foundPlaylist.Title}");
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
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                return;
            case Song song:
                song.Play();
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    public void Pause()
    {
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                break;
            case Song song:
                song.Pause();
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }


    public void Resume()
    {
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                break;
            case Song song:
                song.Resume();
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }


    public void Skip()
    {
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                break;
            case Song song:
                song.Skip();
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    public void ViewDetails()
    {
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                break;
            case Album album:
                ViewAlbumDetails(album);
                break;
            case Playlist playlist:
                ViewPlaylistDetails(playlist);
                break;
            case Song song:
                ViewSongDetails(song);
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    private void ViewAlbumDetails(Album album)
    {
        Console.WriteLine($"Album: {album.Title}");
        Console.WriteLine($"Artist: {album.Creator}");
        Console.WriteLine($"Genre: {album.Genre}");
        Console.WriteLine("Songs:");
        foreach (var song in album.Songs)
        {
            Console.WriteLine($"- {song.Title}");
        }
    }

    private void ViewPlaylistDetails(Playlist playlist)
    {
        Console.WriteLine($"Playlist: {playlist.Title}");
        Console.WriteLine($"Creator: {playlist.Creator}");
        Console.WriteLine("Songs:");
        foreach (var song in playlist.Songs)
        {
            Console.WriteLine($"- {song.Title}");
        }
    }

    private void ViewSongDetails(Song song)
    {
        Console.WriteLine($"Song: {song.Title}");
        Console.WriteLine($"Artist: {song.Creator}");
        Console.WriteLine($"Genre: {song.Genre}");
    }
}