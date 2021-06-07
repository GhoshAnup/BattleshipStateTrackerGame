using BattleShipStateTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShipStateTracker.Core.Entities
{
    public abstract class Vessel
    {       
        public int Count { get; set; }
        public VesselType VesselType { get; set; }
    }
}
