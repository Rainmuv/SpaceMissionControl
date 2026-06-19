using StockLog;
namespace System
{
    class MissionControl
    {

        public void Run(ref Fleet<Probe> fleet,Func<Probe, int> topUp, Func<Probe, int> fixed30)
        {
            
            for (int i = 0; i < 5; i++)
            { 
                bool statusChoice = true;
                while(statusChoice)
                {
                    bool statusWarning = false;
                    Console.WriteLine("[------------Space-Mission------------]");
                    Console.WriteLine("Satellite status:");
                    foreach (var item in fleet.GetAll())
                    {
                        Console.WriteLine($"{item.Name} - Fuel: {item.Fuel}");
                        if(item.Status == "LowFuel")
                        {
                            statusWarning = true;
                        }
                    }
                    if(statusWarning)
                    {
                        fleet.Filter(fleet.GetAll());
                    }
                    Console.WriteLine($"Choice control step {i + 1} \n 1. fly \n 2. sendFuel");
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1": 
                            foreach (var item in fleet.GetAll())
                            {
                                item.Fly();
                            }
                            statusChoice = false;
                        ; break;
                        case "2":
                        Console.WriteLine("Type Name of Satellite");
                        var choiceWich = Console.ReadLine();
                        foreach (var item in fleet.GetAll())
                        {
                            if(item.Name == choiceWich)
                            { 
                                if(item.Fuel != 0)
                                {
                                    Console.WriteLine("Choice type SendRefuel \n 1. Full \n 2. fixed 30");
                                    var choiceHowSendFuel = Console.ReadLine();
                                    switch (choiceHowSendFuel)
                                    {
                                        case "1": 
                                            item.Fuel = SendRefuel(item, topUp);
                                        ; break;
                                        case "2": 
                                            item.Fuel += SendRefuel(item, fixed30);
                                        ; break;
                                    }
                                } else
                                {
                                  Console.WriteLine($"Satellite status: {item.Status}");
                                  Console.ReadKey();
                                }
                            }
                        }
                        ; break;
                        default: ; break;
                    }
                    Console.Clear();
                }
                
            }
            foreach (var item in fleet.GetAll())
            {
                if(item.Fuel != 0)
                {
                    Console.WriteLine($"{item.Name} was able to reach the target of\"{item.Target}\"!");
                }
            }
        }
        public int SendRefuel(Probe item, Func<Probe, int> strategy)
        {
            return strategy(item);
        }
    }
}