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
        public void Filter(List<T> all)
        {   
            Console.WriteLine(" \n WARNING! \n");
            foreach (var item in all)
            {
                if(item.Status == "LowFuel")
                {
                    Console.WriteLine($"{item.Name} need fuel!");
                }
            }
            Console.WriteLine("\n");
        }
    }
}