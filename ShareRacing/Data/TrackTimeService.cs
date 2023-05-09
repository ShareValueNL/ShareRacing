namespace ShareRacing.Data;

public class TrackTimeService
{
    private readonly ShareRacingDatabase _database;
    
    public TrackTimeService(ShareRacingDatabase database)
    {
        _database = database;
    }

    public Task<List<TrackTime>> GetTrackTimes(string trackId) => _database.GetItemsByTrackIdAsync(trackId);

    public Task SaveTrackTime(TrackTime trackTime) => _database.SaveItemAsync(trackTime);

    public async Task DeleteTrackTime(Guid trackTimeId)
    {
        var trackTime = await _database.GetItemAsync<TrackTime>(trackTimeId);

        await _database.DeleteItemAsync(trackTime);
    }
}

