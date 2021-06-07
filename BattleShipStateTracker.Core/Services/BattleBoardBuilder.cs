using BattleShipStateTracker.Core.Entities;
using BattleShipStateTracker.Core.Entities.Board;
using BattleShipStateTracker.Core.Enums;
using BattleShipStateTracker.Core.Helper;
using BattleShipStateTracker.Core.Interfaces;
using System;

namespace BattleShipStateTracker.Core.Services
{
    public class BattleBoardBuilder : IBattleBoardBuilder
    {
        public BattleBoard CreateBattleBoard(int rows, int columns)
        {
            BattleBoardStatus[,] statusArray = new BattleBoardStatus[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    statusArray[row, column] = BattleBoardStatus.Unoccupied;
                }
            }
            return new BattleBoard
            {
                BattleBoardStatuses = statusArray,
                RowCount = rows,
                ColumnCount = columns
            };
        }
        public Vessel CreateVessel(VesselType vesselType)
        {
            try
            {
                return vesselType switch
                {
                    VesselType.Cruisers => new Cruisers(),
                    VesselType.Destroyer => new Destroyer(),
                    _ => new Destroyer(),
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not create Vessel : {ex.Message}");
            }
        }
        public string PlaceVesselToBoard(Vessel vessel, BattleBoard battleBoard, int row, int column)
        {
            if (Validator.ValidateParameter(battleBoard, row, column, vessel))
            {
                for (int i = 0; i < vessel.Count; i++)
                {
                    battleBoard.BattleBoardStatuses[row, column + i] = BattleBoardStatus.Occupied;
                    battleBoard.EngageedCellCount++;
                }
                return BattleBoardStatus.Placed.GetEnumDescription();
            }
            return BattleBoardStatus.NotAvailable.GetEnumDescription();

        }
    }
}
