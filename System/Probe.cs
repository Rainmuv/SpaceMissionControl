namespace System
{
    class Probe
    {
        public string Name {get; set;} = "";
        public string Target {get; set;} = "";
        public int Fuel {get; set;} = 0;
        public string Status {get; set;} ="";
        public delegate void EventStatus(Probe item);
        public event EventStatus? StatusChanged;

        public Probe(string Name, string Target, int Fuel)
        {
            this.Name = Name;
            this.Target = Target;
            this.Fuel = Fuel;            
        }
    }
}