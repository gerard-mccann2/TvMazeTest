using System;
using System.Collections.Generic;
using System.Text;

namespace TvMazeApiTest.APIHelper
{
    public class TvShowSeason
    {
        public string TvShowName;
        public int SeasonNumber;
        
        public TvShowSeason(string tvShowName, int seasonNumber)
        {
            TvShowName = tvShowName;
            SeasonNumber = seasonNumber;
        }
    }
}
