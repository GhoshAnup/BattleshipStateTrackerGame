using BattleShipStateTracker.Core.Services;
using Xunit;

namespace BattleShipStateTracker.Test
{
    public class BattleBoardTests
    {
        [Theory]
        [InlineData(10, 10)]
        public void ShouldReturnBattleBoard_WhenBattleBoardCreated(int rowCount, int columnCount)
        {
            //arrange
            var battleBoardBuilder = new BattleBoardBuilder();

            //act
            var battleBoard = battleBoardBuilder.CreateBattleBoard(rowCount, columnCount);

            //assert
            Assert.Equal(rowCount * columnCount, battleBoard.BattleBoardStatuses.Length);
        }
    }
}
