namespace ShareRacing.Data.Ergast;

public class Root
{
    public Mrdata MRData { get; set; }
}

public class Mrdata
{
    public string xmlns { get; set; }
    public string series { get; set; }
    public string url { get; set; }
    public string limit { get; set; }
    public string offset { get; set; }
    public string total { get; set; }
    public Circuittable CircuitTable { get; set; }
}

public class Circuittable
{
    public string season { get; set; }
    public Circuit[] Circuits { get; set; }
}

public class Circuit
{
    public string circuitId { get; set; }
    public string url { get; set; }
    public string circuitName { get; set; }
    public Location Location { get; set; }
}

public class Location
{
    public string lat { get; set; }
    public string _long { get; set; }
    public string locality { get; set; }
    public string country { get; set; }
}
