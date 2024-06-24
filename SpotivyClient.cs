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
                PlaySong(song);
                break;
            default:
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

    public void Skip()
    {
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                break;
            case Song song:
                SkipSong(song);
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    private void SkipSong(Song song)
    {
        Console.WriteLine($"Skipped song: {song.Title}");
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