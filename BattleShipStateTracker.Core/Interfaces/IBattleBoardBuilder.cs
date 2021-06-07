using BattleShipStateTracker.Core.Entities;
using BattleShipStateTracker.Core.Entities.Board;
using BattleShipStateTracker.Core.Enums;

namespace BattleShipStateTracker.Core.Interfaces
{
    public interface IBattleBoardBuilder
    {
        BattleBoard CreateBattleBoard(int rows, int columns);
        Vessel CreateVessel(VesselType vesselType);
        string PlaceVesselToBoard(Vessel vessel, BattleBoard battleBoard, int row, int column);
    }
}
