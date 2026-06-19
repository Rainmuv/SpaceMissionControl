namespace StockLog
{
    class Fleet<T> where T: Probe
    {
        List<T> allFleet = new List<T> {} ;
        public void Add(T item)
        {
            allFleet.Add(item);
        }
 
        public List<T> GetAll()
        {
            return allFleet;
        }
        public void Filter()
        {   
            Console.WriteLine(" \n WARNING! \n");
            foreach (var item in allFleet)
            {
                if(item.Status == Probe.ProbeStatus.LowFuel)
                {
                    Console.WriteLine($"{item.Name} need fuel!");
                }
            }
            Console.WriteLine("\n");
        }
    }
}