using BattleShipStateTracker.Core.Enums;

namespace BattleShipStateTracker.Core.Entities.Vessels
{
    public class VesselParameters
    {
        //public int PlacementRowIndex { get; set; }
        //public int PlacementColumnIndex { get; set; }
        //public int BoardRowIndex { get; set; }
        //public int BoardColumnIndex { get; set; }
        public Coordinates Coordinates { get; set; }        
        public VesselType VesselType { get; set; }
    }
}
