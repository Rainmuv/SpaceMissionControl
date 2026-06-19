using System;
using StockLog;
class Program
{
    public static void Main()
    {
        var fleet = new Fleet<Probe>();
        Func<Probe, int> topUp   = p => 100 - p.Fuel;  // долить до максимума
        Func<Probe, int> fixed30 = _ => 30;             // фиксированно 30 единиц


        fleet.Add(new Probe("Voyager-X",  "Mars",    0));
        fleet.Add(new Probe("Artemis-3",  "Venus",   5));
        fleet.Add(new Probe("Helios",     "Jupiter", 20));
        fleet.Add(new Probe("Nomad",      "Saturn",  100));

        var logger = new MissionLogger();
        var alerts = new AlertSystem();
        var startMission = new MissionControl();

        foreach (var probe in fleet.GetAll())
        {
            probe.StatusChanged += logger.OnStatusChanged;
            probe.StatusChanged += alerts.OnStatusChanged;
        }
        
        startMission.Run(ref fleet, topUp, fixed30);
        logger.Cons();
    }
}