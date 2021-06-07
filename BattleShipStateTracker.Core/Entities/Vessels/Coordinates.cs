using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Core.Entities.Vessels
{
    public class Coordinates
    {
        public int PlacementRowIndex { get; set; }
        public int PlacementColumnIndex { get; set; }
        public int BoardRowCount { get; set; }
        public int BoardColumnCount { get; set; }
    }
}
