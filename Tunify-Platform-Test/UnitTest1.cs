using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Services;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Tunify_Platform.Repositories.Interfaces;
namespace Tunify_Platform_Test
{
    public class UnitTest1
    {


        [Fact]
        public async Task GetSongsForPlaylist_ReturnsCorrectSongs()
        {
            // Arrange  
            var playlistId = 1;
            var songs = new List<Songs>
             {
                new Songs { SongsId = 3, Title = "Song 1", ArtistsId = 1, AlbumsId = 1, Duration =3, Genre = 1 }, 
                new Songs { SongsId = 4, Title = "Song 2", ArtistsId = 2, AlbumsId = 2, Duration = 4, Genre = 2 }
             };
            var mockRepository = new Mock<ISongs>();
            mockRepository.Setup(repo => repo.GetSongsForPlaylist(playlistId))
                          .ReturnsAsync(songs);
            // Act
            var result = await mockRepository.Object.GetSongsForPlaylist(playlistId); 
            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.Title == "Song 1");
            Assert.Contains(result, s => s.Title == "Song 2");
        }
    }
}
