﻿namespace ShareRacing.Data;

public class Track
{
    public string Id { get; set; }

    public string Name { get; set; }

    public List<TrackTime> TrackTimes { get; set; }
}
