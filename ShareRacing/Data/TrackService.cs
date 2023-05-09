using ShareRacing.Data.Interfaces;

namespace ShareRacing.Data;

public class TrackService
{
    private readonly IErgastClient _ergastClient;
    
    public TrackService(IErgastClient ergastClient)
    {
        _ergastClient = ergastClient;
    }

    public Task<Track[]> GetTracks() => _ergastClient.GetTracks();
}

