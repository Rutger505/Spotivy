namespace Spotivy;

public class Song : IPlayable
{
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

    public void Skip()
    {
        throw new NotImplementedException();
    }

    public void Repeat(bool state)
    {
        throw new NotImplementedException();
    }
}