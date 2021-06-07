using BattleShipStateTracker.Core.Entities.Board;
using BattleShipStateTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Core.Interfaces
{
    public interface IStriker
    {
        string Strike(int row, int column, BattleBoard battleBoard);
    }
}
