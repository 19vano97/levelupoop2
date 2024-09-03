using System;

namespace OceanLife.Delegates;

public delegate void KillConfirmDelegate(object sender, Coordinates coord, Cell victim, Cell killer);
