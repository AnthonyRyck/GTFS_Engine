﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GtfsEngine.Entities
{
    public class Agency
    {
        public string agency_id { get; set; }
        public string agency_name { get; set; }
        public string agency_url { get; set; }
        public string agency_timezone { get; set; }
        public string agency_lang { get; set; }
        public string agency_phone { get; set; }
        public string agency_fare_url { get; set; }
        public string agency_email { get; set; }
    }
}
