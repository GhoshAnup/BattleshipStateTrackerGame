using BattleShipStateTracker.Core.Enums;
using BattleShipStateTracker.Core.Services;
using Xunit;

namespace BattleShipStateTracker.Test
{
    public class GameTracketTests
    {
        [Fact]
        public void ShouldReturnLostGameStatus_WhenVesselsSunk()
        {
            //arrange
            var battleBoardBuilder = new BattleBoardBuilder();
            var battleBoard = battleBoardBuilder.CreateBattleBoard(10, 10);
            var vessel = battleBoardBuilder.CreateVessel(VesselType.Destroyer);
            battleBoardBuilder.PlaceVesselToBoard(vessel, battleBoard, 10, 10);

            //act
            var striker = new Striker();
            striker.Strike(0, 0, battleBoard);
            striker.Strike(0, 1, battleBoard);

            //assert 
            Assert.True(battleBoard.HasLost);
        }

        [Fact]
        public void ShouldNotReturnLostGameStatusTrue_WhenVesselsNotSunk()
        {
            //arrange
            var battleBoardBuilder = new BattleBoardBuilder();
            var battleBoard = battleBoardBuilder.CreateBattleBoard(10, 10);
            var vessel = battleBoardBuilder.CreateVessel(VesselType.Destroyer);
            battleBoardBuilder.PlaceVesselToBoard(vessel, battleBoard, 0, 0);

            //act
            var striker = new Striker();
            striker.Strike(0, 1, battleBoard);

            //assert 
            Assert.False(battleBoard.HasLost);
        }
    }
}
