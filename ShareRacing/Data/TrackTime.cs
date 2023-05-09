using SQLite;

namespace ShareRacing.Data;

public class TrackTime
{
    [PrimaryKey]
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }

	public string TrackId { get; set; }

    public string Name { get; set; }

    // Track Time in milliseconds
    public int Time { get; set; }
}
