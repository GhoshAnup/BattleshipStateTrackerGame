using BattleShipStateTracker.Core.Enums;

namespace BattleShipStateTracker.Core.Entities
{
    public class Cruisers : Vessel
    {
        public Cruisers()
        {
            Count = 2;
            VesselType = VesselType.Cruisers;
        }
    }
}
