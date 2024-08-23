using System;

namespace OceanLife;

public interface IShowKill
{
    Coordinates KillPlace {get; set;}
    Image Victim {get; set;}
    Image Killer {get; set;}
}
