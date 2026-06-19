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
                Status = ProbeStatus.Active;
                if(field <= 20)
                {
                    Status = ProbeStatus.LowFuel;
                }
                if(field < 0)
                {
                    Status = ProbeStatus.Lost;
                    field = 0;
                }
            }
        }
        public ProbeStatus Status {get; set;} = ProbeStatus.Active;
        public enum ProbeStatus
        {
            Active,
            LowFuel,
            Lost
        }
        public delegate void EventStatus(Probe item);
        public event EventStatus? StatusChanged;

        public Probe(string Name, string Target, int Fuel)
        {
            this.Name = Name;
            this.Target = Target;
            this.Fuel = Fuel;
            if(Fuel == 0)
            {
                Status = ProbeStatus.Lost;
            } else if(Fuel <= 20)
            {
                Status = ProbeStatus.LowFuel;
            }
        }

        public void Fly()
        {   
            if (Status == ProbeStatus.Lost) return;
            Fuel -= 15;
            StatusChanged?.Invoke(this);
        }
    }
}