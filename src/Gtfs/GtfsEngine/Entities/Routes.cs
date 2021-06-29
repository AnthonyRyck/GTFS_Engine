using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsEngine.Entities
{
    /// <summary>
    /// Itinéraires en transports en commun. Un itinéraire est un ensemble de trajets présentés aux usagers comme relevant du même service.
    /// </summary>
    public class Routes
    {
        public string route_id { get; set; }
        public string agency_id { get; set; }
        public string route_short_name { get; set; }
        public string route_long_name { get; set; }
        public string route_desc { get; set; }
        public int route_type { get; set; }
        public string route_url { get; set; }
        public string route_color { get; set; }
        public string route_text_color { get; set; }
        public int? route_sort_order { get; set; }
        public int? continuous_pickup { get; set; }
        public int? continuous_drop_off { get; set; }
    }
}
