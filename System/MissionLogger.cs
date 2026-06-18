namespace System
{
    class MissionLogger
    {
        public static int count {get; set; }= 1;
        public static int countLog {get; set; }= 1;
        public static Dictionary<string, string> LogOnFleet = new Dictionary<string, string> {};


        public void OnStatusChanged(Probe item)
        {
            LogOnFleet.Add($"{item.Name}{countLog++}", $"Status: {item.Status} - Fuel: {item.Fuel}");
        }
        public void Cons()
        {

            foreach (var value in LogOnFleet)
            {
                Console.WriteLine($"{value.Key}: {value.Value}");
            }
        
            
        }
    }
}