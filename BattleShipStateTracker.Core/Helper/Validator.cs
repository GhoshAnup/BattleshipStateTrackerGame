using BattleShipStateTracker.Core.Entities;
using BattleShipStateTracker.Core.Entities.Board;

namespace BattleShipStateTracker.Core.Helper
{
    public static class Validator
    {
        public static bool ValidateParameter(BattleBoard board, int row, int column, Vessel vessel = null)
        {
            if (vessel != null)
            {
                for (int c = 0; c < vessel.Count; c++)
                {
                    if (column + c > board.ColumnCount)
                    {
                        return false;
                    }
                }
            }
            return row <= board.RowCount && column <= board.ColumnCount;
        }    
    }
}
