using Spotivy;

public class SpotivyClient(List<Song> songs, List<Album> albums, List<User> users)
{
    List<Song> songs = songs;
    List<Album> albums = albums;
    List<User> users = users;


    IPlayable? selectedPlayable;

    public void SelectPlayable(IPlayable playable)
    {
        selectedPlayable = playable;
    }
}