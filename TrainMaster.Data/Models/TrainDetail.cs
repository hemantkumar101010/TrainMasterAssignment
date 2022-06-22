using System;
using System.Collections.Generic;

namespace TrainMaster.Data.Models
{
    public partial class TrainDetail
    {
        public int TrainNumber { get; set; }
        public string TrainName { get; set; } = null!;
        public string FromStation { get; set; } = null!;
        public string ToStaion { get; set; } = null!;
        public DateTime? JourneyStime { get; set; }
        public DateTime? JourneyEtime { get; set; }

        public virtual DaysSchedular DaysSchedular { get; set; } = null!;
    }
}
