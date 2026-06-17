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
    }
}