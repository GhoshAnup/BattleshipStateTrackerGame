using BattleShipStateTracker.Core.Enums;
using BattleShipStateTracker.Core.Services;
using Xunit;

namespace BattleShipStateTracker.Test
{
    public class PlaceVesselsTests
    {
        [Theory]
        [InlineData(10, 10, 0, 0, VesselType.Cruisers)]
        [InlineData(10, 10, 0, 6, VesselType.Destroyer)]
        public void ShouldPlaceAVessel_WhenCorrectCoordinateProvided(
               int boardRowCount, int boardColumnCount,
            int placementRowIndex, int placementColumnIndex,
            VesselType vesselType)
        {
            //arrange
            var battleBoardBuilder = new BattleBoardBuilder();
            var battleBoard = battleBoardBuilder.CreateBattleBoard(boardRowCount, boardColumnCount);
            var vessel = battleBoardBuilder.CreateVessel(vesselType);

            //act
            battleBoardBuilder.PlaceVesselToBoard(vessel, battleBoard, placementRowIndex, placementColumnIndex);

            //assert
            Assert.True(battleBoard.BattleBoardStatuses[placementRowIndex, placementColumnIndex + vessel.Count - 1] == BattleBoardStatus.Occupied
            );
        }

        [Theory]
        [InlineData(10, 10, 20, 14, VesselType.Cruisers)]
        public void ShouldFailVesselPlacement_WhenIncorrectCorrectCoordinateProvided(
              int boardRowCount, int boardColumnCount,
            int placementRowIndex, int placementColumnIndex,
            VesselType vesselType)
        {
            //arrange
            var battleBoardBuilder = new BattleBoardBuilder();
            var battleBoard = battleBoardBuilder.CreateBattleBoard(boardRowCount, boardColumnCount);
            var vessel = battleBoardBuilder.CreateVessel(vesselType);

            //act
            var result = battleBoardBuilder.PlaceVesselToBoard(vessel, battleBoard, placementRowIndex, placementColumnIndex);

            //assert
            Assert.Equal("Vessels placement position is out of board", result);
        }
    }
}
