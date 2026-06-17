namespace System
{
    class AlertSystem
    {
        public void OnStatusChanged(Probe item)
        {
            if(item.Status == "Lost")
            {
                Console.WriteLine($"Ahtung! {item.Name}");
                Console.ReadKey();
            }
        }
    }
}