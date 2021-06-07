using BattleShipStateTracker.Core.Entities.Board;
using BattleShipStateTracker.Core.Enums;
using BattleShipStateTracker.Core.Helper;
using BattleShipStateTracker.Core.Interfaces;

namespace BattleShipStateTracker.Core.Services
{
    public class Striker : IStriker
    {
        public string Strike(int row, int column, BattleBoard battleBoard)
        {
            if (Validator.ValidateParameter(battleBoard, row, column))
            {
                if (battleBoard.BattleBoardStatuses[row, column] == BattleBoardStatus.Occupied)
                {
                    battleBoard.BattleBoardStatuses[row, column] = BattleBoardStatus.Hit;
                    battleBoard.HitSuccessCount++;
                    return BattleBoardStatus.Hit.GetEnumDescription();
                }
                battleBoard.BattleBoardStatuses[row, column] = BattleBoardStatus.Miss;
                return BattleBoardStatus.Miss.GetEnumDescription();
            }
            return BattleBoardStatus.NotFound.GetEnumDescription();
        }
    }
}
