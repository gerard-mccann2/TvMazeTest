using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TvMazeApiTest.APIHelper;

namespace TvMazeApiTest.API
{
    public class TvMazeApi
    {
        private readonly RestClient restClient;
        private readonly string baseUri = "https://api.tvmaze.com";

        public TvMazeApi()
        {
            restClient = new RestClient(baseUri);
        }

        public List<TvShows> GetTvShows()
        {
            var request = new RestRequest("shows");
            var response = restClient.Execute(request);
            return JsonConvert.DeserializeObject<List<TvShows>>(response.Content);            
        }

        public List<TvShowEpisodes> GetTvShowEpisodes(int tvShowId)
        {
            var request = new RestRequest($"shows/{tvShowId}/episodes");
            var response = restClient.Execute(request);
            return JsonConvert.DeserializeObject<List<TvShowEpisodes>>(response.Content);
        }

        public int GetTvShowIdByTitle(string tvShowTitle)
        {   
            var tvShows = GetTvShows();
            return tvShows.Where(t => t.name == tvShowTitle).FirstOrDefault().id;
        }

        public List<TvShowEpisodes> GetTvShowEpisodes(string tvShowTitle, int seasonNumber)
        {
            var tvShowId = GetTvShowIdByTitle(tvShowTitle);
            return GetTvShowEpisodes(tvShowId).Where(t => t.season == seasonNumber).ToList();
        }

        public List<TvShowRunTime> GetTvShowRuntimesBySeason(List<TvShowSeason> tvShowSeasons)
        {
            var output = new List<TvShowRunTime>();
            
            foreach (var tvShowSeason in tvShowSeasons)
            {
                var tvShowEpisodes = GetTvShowEpisodes(tvShowSeason.TvShowName, tvShowSeason.SeasonNumber);
                var tvShowRunTime = new TvShowRunTime
                {
                    TvShowName = tvShowSeason.TvShowName,
                    SeasonNumber = tvShowSeason.SeasonNumber,
                    SeasonRunTime = tvShowEpisodes.Sum(t => t.runtime) / (double)tvShowEpisodes.Count
                };

                output.Add(tvShowRunTime);
            }

            return output;
        }

        public List<TvShowRunTime> GetTvShowRuntimesByShow(List<TvShowSeason> tvShowSeasons)
        {
            var output = new List<TvShowRunTime>();
            var tvShowSeasonRunTimes = GetTvShowRuntimesBySeason(tvShowSeasons);
                        
            foreach (var tvShowName in tvShowSeasons.Select(t => t.TvShowName).Distinct())
            {
                var tvShowRunTime = new TvShowRunTime();

                tvShowRunTime.TvShowName = tvShowName;
                tvShowRunTime.SeasonRunTime = tvShowSeasonRunTimes.Where(t => t.TvShowName == tvShowName).Sum(t => t.SeasonRunTime) / tvShowSeasonRunTimes.Count(t => t.TvShowName == tvShowName);

                output.Add(tvShowRunTime);
            }

            return output;
        }
    }
}
