namespace Spotivy;

public class User(
    string name,
    List<Playlist> playlists,
    List<User> friends)
{
    public string Name { get; } = name;
    public List<Song> CurrentPlayList { get; } = new();
    public List<Playlist> Playlists { get; } = playlists;
    public List<User> Friends { get; } = friends;
}