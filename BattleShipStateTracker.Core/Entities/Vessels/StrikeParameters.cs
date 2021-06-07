using BattleShipStateTracker.Core.Enums;

namespace BattleShipStateTracker.Core.Entities.Vessels
{
    public class StrikeParameters
    {
        public int StrikeRowIndex { get; set; }
        public int StrikeColumnIndex { get; set; }
        public VesselType VesselType { get; set; }
        public BattleBoardStatus BattleBoardStatus { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
