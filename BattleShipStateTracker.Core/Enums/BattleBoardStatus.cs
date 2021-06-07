using System.ComponentModel;

namespace BattleShipStateTracker.Core.Enums
{
    public enum BattleBoardStatus
    {
        [Description("Unoccupied board space")]
        Unoccupied,

        [Description("Occupied board space")]
        Occupied,

        [Description("Succesfull target")]
        Hit,

        [Description("Unsuccesfull target")]
        Miss
            ,
        [Description("Stike range not available")]
        NotFound,

        [Description("Vessels placement position is out of board")]
        NotAvailable,

        [Description("Vessel placed on the board succesfully")]
        Placed,
    }
}
