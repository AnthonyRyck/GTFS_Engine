using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsEngine.Entities
{
    public class Shapes
    {
        public string shape_id { get; set; }
        public double shape_pt_lat { get; set; }
        public double shape_pt_lon { get; set; }
        public int shape_pt_sequence { get; set; }
        public double? shape_dist_traveled { get; set; }
    }
}
