namespace Spotivy;

public class User
{
    public List<Song> CurrentPlayList { get; set; }
    public List<Playlist> Playlists { get; set; }
    public List<User> Friends { get; set; }
}