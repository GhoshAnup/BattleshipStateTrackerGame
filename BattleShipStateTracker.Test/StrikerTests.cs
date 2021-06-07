using BattleShipStateTracker.Core.Enums;
using BattleShipStateTracker.Core.Services;
using Xunit;

namespace BattleShipStateTracker.Test
{
    public class StrikerTests
    { 
        [Theory]
        [InlineData(10, 10, 0, 0, 0, 0, VesselType.Cruisers, BattleBoardStatus.Hit)]
        [InlineData(10, 10, 0, 4, 0, 4, VesselType.Cruisers, BattleBoardStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 5, VesselType.Destroyer, BattleBoardStatus.Miss)]
        [InlineData(10, 10, 0, 0, 3, 8, VesselType.Destroyer, BattleBoardStatus.Miss)]
        public void ShouldReturnCorrectStrikeStatus_WhenStrikeLaunched(
            int boardRowCount, int boardColumnCount,
            int placementRowIndex, int placementColumnIndex,
            int strikeRow, int strikeColumn,
            VesselType vesselType, BattleBoardStatus battleBoardStatus)
        {
            //arrange
            var battleBoardBuilder = new BattleBoardBuilder();
            var battleBoard = battleBoardBuilder.CreateBattleBoard(boardRowCount, boardColumnCount);
            var vessel = battleBoardBuilder.CreateVessel(vesselType);
            battleBoardBuilder.PlaceVesselToBoard(vessel, battleBoard, placementRowIndex, placementColumnIndex);

            //act
            var striker = new Striker();
            striker.Strike(strikeRow, strikeColumn, battleBoard);

            //assert
            Assert.True(
                battleBoard.BattleBoardStatuses[strikeRow, strikeColumn] == battleBoardStatus
            );
        }

        [Theory]
        [InlineData(10, 10, 0, 0, 11, 11, VesselType.Destroyer)]
        [InlineData(10, 10, 0, 0, 17, 15, VesselType.Destroyer)]
        public void ShouldReturnMessage_WhenIncorrectAttackCoordinatesProvided(
          int boardRowCount, int boardColumnCount,
          int placementRowIndex, int placementColumnIndex,
          int strikeRow, int strikeColumn,
          VesselType vesselType)
        {
            //arrange
            var battleBoardBuilder = new BattleBoardBuilder();
            var battleBoard = battleBoardBuilder.CreateBattleBoard(boardRowCount, boardColumnCount);
            var vessel = battleBoardBuilder.CreateVessel(vesselType);
            battleBoardBuilder.PlaceVesselToBoard(vessel, battleBoard, placementRowIndex, placementColumnIndex);

            //act
            var striker = new Striker();
            var result = striker.Strike(strikeRow, strikeColumn, battleBoard);

            //assert
            Assert.Equal("Stike range not available",result);
        }
    }
}
