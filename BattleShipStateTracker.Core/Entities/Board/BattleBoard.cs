using BattleShipStateTracker.Core.Enums;

namespace BattleShipStateTracker.Core.Entities.Board
{
    public class BattleBoard
    {
        public int EngageedCellCount { get; set; }
        public int HitSuccessCount { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }        
        public bool HasLost => HitSuccessCount >= EngageedCellCount;
        public BattleBoardStatus[,] BattleBoardStatuses { get; set; }
    }
}
