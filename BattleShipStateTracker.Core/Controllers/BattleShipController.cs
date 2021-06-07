using System;
using BattleShipStateTracker.Core.Entities.Board;
using BattleShipStateTracker.Core.Entities.Vessels;
using BattleShipStateTracker.Core.Interfaces;
using BattleShipStateTracker.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipStateTracker.Core.Controllers
{
    [Route("api/V1/battleship")]
    [ApiController]
    public class BattleShipController : ControllerBase
    {
        private readonly IBattleBoardBuilder _battleBoardBuilder;
        private readonly IStriker _striker;
        public BattleShipController(IBattleBoardBuilder battleBoardBuilder, IStriker striker)
        {
            _battleBoardBuilder = battleBoardBuilder;
            _striker = striker;
        }
        public ActionResult Get()
        {
            return Ok();
        }

        [Route("board")]
        [HttpPost]
        public ActionResult<BattleBoardBuilder> CreateBoard([FromBody] BoardCoordinates boardParams)
        {
            try
            {
                var battleBoard = _battleBoardBuilder.CreateBattleBoard(boardParams.RowCount, boardParams.ColumnCount);
                return Ok($"Create board succeed with row is:{battleBoard.RowCount} columns is:{ battleBoard.ColumnCount}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("vessel")]
        [HttpPost]
        public ActionResult AllocateVessel([FromBody] VesselParameters vesselParams)
        {
            try
            {
                var battleBoard = _battleBoardBuilder.CreateBattleBoard(vesselParams.Coordinates.BoardRowCount, vesselParams.Coordinates.BoardColumnCount);

                var vessel = _battleBoardBuilder.CreateVessel(vesselParams.VesselType);

                var message = _battleBoardBuilder.PlaceVesselToBoard(
                                                    vessel,
                                                    battleBoard,
                                                    vesselParams.
                                                    Coordinates.PlacementRowIndex,
                                                    vesselParams.Coordinates.PlacementColumnIndex);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Route("strike")]
        [HttpPost]
        public ActionResult StrikeVessel([FromBody] StrikeParameters strikeParams)
        {
            try
            {
                var battleBoard = _battleBoardBuilder.CreateBattleBoard(strikeParams.Coordinates.BoardRowCount, strikeParams.Coordinates.BoardColumnCount);

                var vessel = _battleBoardBuilder.CreateVessel(strikeParams.VesselType);

                var message = _battleBoardBuilder.PlaceVesselToBoard(
                                                    vessel,
                                                    battleBoard,
                                                    strikeParams.
                                                    Coordinates.PlacementRowIndex,
                                                    strikeParams.Coordinates.PlacementColumnIndex);

                var result = _striker.Strike(strikeParams.StrikeRowIndex, strikeParams.StrikeColumnIndex,battleBoard);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

    }
}
