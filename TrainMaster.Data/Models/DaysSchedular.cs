using System;
using System.Collections.Generic;

namespace TrainMaster.Data.Models
{
    public partial class DaysSchedular
    {
        public int TrainNo { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thusday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }

        public virtual TrainDetail TrainNoNavigation { get; set; } = null!;
    }
}
