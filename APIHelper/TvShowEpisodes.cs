using System;
using System.Collections.Generic;
using System.Text;

namespace TvMazeApiTest.APIHelper
{
    public class TvShowEpisodes
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public int season { get; set; }
        public int number { get; set; }
        public string type { get; set; }
        public string airdate { get; set; }
        public string airtime { get; set; }
        public DateTime airstamp { get; set; }
        public int runtime { get; set; }
        public Image image { get; set; }
        public string summary { get; set; }
        public Links _links { get; set; }

        public class Image
        {
            public string medium { get; set; }
            public string original { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Links
        {
            public Self self { get; set; }
        }
    }
}
