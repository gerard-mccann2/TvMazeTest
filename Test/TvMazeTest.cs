using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TvMazeApiTest.API;
using TvMazeApiTest.APIHelper;

namespace TvMazeApiTest
{
    public class Tests
    {
        [Test]
        public void ValidateGetShowsReturnsMoreThan200Results()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShows = tvMazeApi.GetTvShows();

            //Assert
            Assert.GreaterOrEqual(tvShows.Count, 200);
        }

        [Test]
        public void ValidateTheLeftoversEpisodesSeason1Response()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShowEpisodes = tvMazeApi.GetTvShowEpisodes("The Leftovers", 1);

            //Assert            
            Assert.AreEqual(10, tvShowEpisodes.Count);            
            Assert.AreEqual(600, tvShowEpisodes.Sum(t => t.runtime));
        }

        [Test]
        public void ValidateTheLeftoversEpisodesSeason2Response()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShowEpisodes = tvMazeApi.GetTvShowEpisodes("The Leftovers", 2);

            //Assert            
            Assert.AreEqual(10, tvShowEpisodes.Count);
            Assert.AreEqual(600, tvShowEpisodes.Sum(t => t.runtime));
        }

        [Test]
        public void ValidateTheLeftoversEpisodesSeason3Response()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShowEpisodes = tvMazeApi.GetTvShowEpisodes("The Leftovers", 3);

            //Assert            
            Assert.AreEqual(8, tvShowEpisodes.Count);
            Assert.AreEqual(495, tvShowEpisodes.Sum(t => t.runtime));
        }

        [Test]
        public void ValidateTrueDetectiveEpisodesSeason1Response()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShowEpisodes = tvMazeApi.GetTvShowEpisodes("True Detective", 1);

            //Assert            
            Assert.AreEqual(8, tvShowEpisodes.Count);
            Assert.AreEqual(480, tvShowEpisodes.Sum(t => t.runtime));
        }

        [Test]
        public void ValidateTrueDetectiveEpisodesSeason2Response()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShowEpisodes = tvMazeApi.GetTvShowEpisodes("True Detective", 2);

            //Assert            
            Assert.AreEqual(8, tvShowEpisodes.Count);
            Assert.AreEqual(510, tvShowEpisodes.Sum(t => t.runtime));
        }

        [Test]
        public void ValidateTrueDetectiveEpisodesSeason3Response()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShowEpisodes = tvMazeApi.GetTvShowEpisodes("True Detective", 3);

            //Assert            
            Assert.AreEqual(8, tvShowEpisodes.Count);
            Assert.AreEqual(503, tvShowEpisodes.Sum(t => t.runtime));
        }

        [Test]
        public void ValidateLookingEpisodesSeason1Response()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShowEpisodes = tvMazeApi.GetTvShowEpisodes("Looking", 1);

            //Assert            
            Assert.AreEqual(8, tvShowEpisodes.Count);
            Assert.AreEqual(240, tvShowEpisodes.Sum(t => t.runtime));
        }

        [Test]
        public void ValidateLookingEpisodesSeason2Response()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            //Act
            var tvShowEpisodes = tvMazeApi.GetTvShowEpisodes("Looking", 2);

            //Assert            
            Assert.AreEqual(10, tvShowEpisodes.Count);
            Assert.AreEqual(300, tvShowEpisodes.Sum(t => t.runtime));
        }

        [Test]
        public void ValidateHighestAverageEpisodeRuntime()
        {
            //Arrange
            var tvMazeApi = new TvMazeApi();

            var tvShowsAndSeasons = new List<TvShowSeason>();
            tvShowsAndSeasons.Add(new TvShowSeason("The Leftovers", 1));
            tvShowsAndSeasons.Add(new TvShowSeason("The Leftovers", 2));
            tvShowsAndSeasons.Add(new TvShowSeason("The Leftovers", 3));
            tvShowsAndSeasons.Add(new TvShowSeason("True Detective", 1));
            tvShowsAndSeasons.Add(new TvShowSeason("True Detective", 2));
            tvShowsAndSeasons.Add(new TvShowSeason("True Detective", 3));
            tvShowsAndSeasons.Add(new TvShowSeason("Looking", 1));
            tvShowsAndSeasons.Add(new TvShowSeason("Looking", 2));

            //Act
            var tvShowSeasonRuntimes = tvMazeApi.GetTvShowRuntimesByShow(tvShowsAndSeasons);
            var tvShowSeasonWithLongestRuntime = tvShowSeasonRuntimes.OrderByDescending(t => t.SeasonRunTime).Take(1).ToList();

            //Assert            
            Assert.AreEqual("True Detective", tvShowSeasonWithLongestRuntime[0].TvShowName);
            Assert.AreEqual(62.208333333333336, tvShowSeasonWithLongestRuntime[0].SeasonRunTime);
        }
    }
}