﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Chinook.Data.DTOs
{
   public class ArtistTitle
    {
        public string title { get; set; }
        public string artist { get; set; }
        public List<TracksAndLength> songs { get; set; }
    }
}
