namespace System
{
    class MissionLogger
    {
        List<string> logActive = new List<string> {};
        List<int> logFuel = new List<int> {};
        public void OnStatusChanged(Probe item)
        {
           logActive.Add(item.Status);
           logFuel.Add(item.Fuel);  
        }
    }
}