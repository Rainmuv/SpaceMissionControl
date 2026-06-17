using StockLog;
namespace System
{
    class MissionControl
    {

        public void Run(Fleet<Probe> fleet)
        {
            for (int i = 0; i < 5; i++)
            {
                
                foreach (var item in fleet.GetAll())
                {
                    item.Fly();
                }
            }
        }
    }
}