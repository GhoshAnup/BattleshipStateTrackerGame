using BattleShipStateTracker.Core.Enums;

namespace BattleShipStateTracker.Core.Entities
{
    public class Destroyer : Vessel
    {
        public Destroyer()
        {
            Count = 2;
            VesselType = VesselType.Destroyer;
        }
    }
}
