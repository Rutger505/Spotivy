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

    private List<Song> playingQueue = new();
    private int currentSongIndex = 0;

    private IPlayable? selectedPlayable;
    private User? selectedUser;

    public bool Repeat { get; set; } = false;
    public bool Shuffle { get; set; } = false;

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

    public void Play()
    {
        switch (selectedPlayable)
        {
            case null:
                Console.WriteLine("No playable selected.");
                return;
            case Song song:
                playingQueue = [song];
                currentSongIndex = 0;
                song.Play();
                break;
            case SongCollection songCollection:
                if (songCollection.Songs.Count == 0)
                {
                    Console.WriteLine("No songs in song collection.");
                    return;
                }

                if (Shuffle)
                {
                    playingQueue = songCollection.Songs.OrderBy(song => Guid.NewGuid()).ToList();
                }
                else
                {
                    playingQueue = songCollection.Songs;
                }

                currentSongIndex = 0;

                playingQueue[currentSongIndex].Play();

                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    public void Pause()
    {
        if (playingQueue.Count == 0)
        {
            Console.WriteLine("No song in queue.");
            return;
        }

        Song playingSong = playingQueue[currentSongIndex];
        playingSong.Pause();
    }

    public void Resume()
    {
        if (playingQueue.Count == 0)
        {
            Console.WriteLine("No song queue.");
            return;
        }

        Song playingSong = playingQueue[currentSongIndex];
        playingSong.Resume();
    }

    public void Skip()
    {
        if (playingQueue.Count == 0)
        {
            Console.WriteLine("No song playing.");
            return;
        }

        Song playingSong = playingQueue[currentSongIndex];
        playingSong.Skip();
        currentSongIndex++;

        bool endOfQueue = currentSongIndex >= playingQueue.Count;
        if (endOfQueue && !Repeat)
        {
            Console.WriteLine("End of queue.");
        }
        else if (endOfQueue && Repeat && Shuffle)
        {
            playingQueue = playingQueue.OrderBy(song => Guid.NewGuid()).ToList();
            currentSongIndex = 0;
            playingQueue[currentSongIndex].Play();
        }
        else if (endOfQueue && Repeat && !Shuffle)
        {
            currentSongIndex = 0;
            playingQueue[currentSongIndex].Play();
        }
        else if (!endOfQueue)
        {
            playingQueue[currentSongIndex].Play();
        }
    }

    public void CreatePlaylist(string title)
    {
        var newPlaylist = new Playlist(title, loggedInUser.Name, []);
        loggedInUser.Playlists.Add(newPlaylist);
        Console.WriteLine($"Created playlist: {newPlaylist.Title}");
    }

    public void AddToPlaylist(string playlistTitle)
    {
        if (selectedPlayable == null)
        {
            Console.WriteLine("No song selected.");
            return;
        }

        var foundPlaylist =
            loggedInUser.Playlists.Find(playlist => playlist.Title == playlistTitle);
        if (foundPlaylist == null)
        {
            Console.WriteLine($"Playlist with title '{playlistTitle}' not found.");
            return;
        }

        switch (selectedPlayable)
        {
            case Song song:
                foundPlaylist.Songs.Add(song);
                Console.WriteLine(
                    $"Added song '{song.Title}' to playlist '{foundPlaylist.Title}'.");
                break;
            case SongCollection songCollection:
                foundPlaylist.Songs.AddRange(songCollection.Songs);
                Console.WriteLine(
                    $"Added {songCollection.Title} to playlist {foundPlaylist.Title}.");
                break;
            default:
                throw new NotImplementedException("Playable type not implemented.");
        }
    }

    public void RemoveSongFromSelectedPlaylist(string songTitle)
    {
        if (selectedPlayable is not Playlist)
        {
            Console.WriteLine("No playlist selected.");
            return;
        }

        var selectedPlaylist = (Playlist)selectedPlayable;

        var songToRemove = selectedPlaylist.Songs.Find(song => song.Title == songTitle);
        if (songToRemove == null)
        {
            Console.WriteLine($"Song with title '{songTitle}' not found in playlist.");
            return;
        }

        selectedPlaylist.Songs.Remove(songToRemove);
        Console.WriteLine($"Removed song '{songToRemove.Title}' from playlist.");
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

    public void ViewUsers()
    {
        Console.WriteLine("Users:");
        foreach (var user in users)
        {
            Console.WriteLine($"- {user.Name}");
        }
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

    public void AddUserAsFriend()
    {
        if (selectedUser == null)
        {
            Console.WriteLine("No user selected.");
            return;
        }

        loggedInUser.Friends.Add(selectedUser);
        Console.WriteLine($"Added {selectedUser.Name} as friend.");
    }
}