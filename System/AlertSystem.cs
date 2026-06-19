namespace System
{
    class AlertSystem
    {
        public void OnStatusChanged(Probe item)
        {
            if(item.Status == Probe.ProbeStatus.Lost)
            {
                Console.WriteLine($"Ahtung! {item.Name}");
                Console.ReadKey();
            }
        }
    }
}