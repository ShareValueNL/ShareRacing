namespace ShareRacing.Data.Interfaces;

public interface IErgastClient
{
    Task<Track[]> GetTracks();
}