using System;

namespace OceanLife.Events;

public class KillConfirmSubscriber : IShowKill
{
    private Ocean _oc;
    private Coordinates _killPlace;
    private Cell _victim;
    private Cell _killer;

    public KillConfirmSubscriber(Ocean oc)
    {
        _oc = oc;
        _oc.KillConfirm += KillConfirmSub;
    }

    public Coordinates KillPlace { get => _killPlace; set => _killPlace = value; }
    public Image Victim { get => _victim.DefaultImage; set => _victim.DefaultImage = value; }
    public Image Killer { get => _killer.DefaultImage; set => _killer.DefaultImage = value; }

    public void KillConfirmSub(object sender, Coordinates coord, Cell victim, Cell killer)
    {
        _killPlace = new Coordinates(coord);
        _victim = new Prey((Prey)victim);
        _killer = new Predator((Predator)killer);
    }
}
