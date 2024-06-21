namespace Spotivy;

public class SongCollection : IPlayable
{
    public List<Song> Songs { get; }
    public string Title { get; }
    public string Creator { get; }
    public string Genre { get; }

    public void Play()
    {
        throw new NotImplementedException();
    }

    public void Pause()
    {
        throw new NotImplementedException();
    }

    public void Resume()
    {
        throw new NotImplementedException();
    }
}