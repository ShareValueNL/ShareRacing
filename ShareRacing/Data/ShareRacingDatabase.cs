using SQLite;

namespace ShareRacing.Data;

public class ShareRacingDatabase
{
    SQLiteAsyncConnection Database;

    public ShareRacingDatabase()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<TrackTime>();
    }

    public async Task<List<TrackTime>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<TrackTime>().ToListAsync();
    }

    public async Task<List<TrackTime>> GetItemsByTrackIdAsync(string trackId)
    {
        await Init();
        return await Database.Table<TrackTime>().Where(x => x.TrackId == trackId).ToListAsync();
    }

    public async Task<int> SaveItemAsync(TrackTime item)
    {
        await Init();
        if (item.Id != Guid.Empty)
            return await Database.UpdateAsync(item);
        else
        {
            item.Id = Guid.NewGuid();
            return await Database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(TrackTime item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<TrackTime> GetItemAsync<T>(Guid trackTimeId)
    {
        await Init();
        return await Database.Table<TrackTime>().FirstOrDefaultAsync(x => x.Id == trackTimeId);
    }
}