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
                if(field < 0)
                {
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
            StatusChanged?.Invoke(this);    
        }

        public void Fly()
        {   
            Fuel -= 5;
            if(Fuel <= 20)
            {
                Status = "LowFuel";
            }
            if(Fuel == 0)
            {

                Status = "Lost";
            }   
            StatusChanged?.Invoke(this);
        }
    }
}