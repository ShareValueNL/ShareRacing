using ShareRacing.Data.Ergast;
using ShareRacing.Data.Interfaces;
using System.Text.Json;

namespace ShareRacing.Data;

public class ErgastClient : IErgastClient
{
    private HttpClient _client;
    private readonly string _baseUrl = "https://ergast.com/api/f1/";

    public ErgastClient()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(_baseUrl);
    }

    public async Task<Track[]> GetTracks()
    {
        var response = await _client.GetAsync("2021/circuits.json");
        var json = await response.Content.ReadAsStringAsync();
        var tracks = JsonSerializer.Deserialize<Root>(json);
        
        return tracks.MRData.CircuitTable.Circuits.Select(c => new Track
        {
            Id = c.circuitId,
            Name = c.circuitName
        }).ToArray();
    }
}