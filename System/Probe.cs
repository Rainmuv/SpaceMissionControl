namespace System
{
    class Probe
    {
        public string Name {get; set;} = "";
        public string Target {get; set;} = "";
        public int Fuel {
            get; 
            set
            {
                field = value;
                Status = "Active";
                if(field <= 20)
                {
                    Status = "LowFuel";
                }
                if(field < 0)
                {
                    Status = "Lost";
                    field = 0;
                }
            }
        }
        public string Status {get; set;} = "Active";
        public delegate void EventStatus(Probe item);
        public event EventStatus? StatusChanged;

        public Probe(string Name, string Target, int Fuel)
        {
            this.Name = Name;
            this.Target = Target;
            this.Fuel = Fuel;
            if(Fuel == 0)
            {
                Status = "Lost";
            } else if(Fuel <= 20)
            {
                Status = "LowFuel";
            }
            StatusChanged?.Invoke(this);    
        }

        public void Fly()
        {   
            Fuel -= 5;
            StatusChanged?.Invoke(this);
        }
    }
}