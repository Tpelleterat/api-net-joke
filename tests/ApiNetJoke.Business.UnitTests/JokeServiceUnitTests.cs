using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Infrastructure.Interfaces;
using ApiNetJoke.Infrastructure.Models;
using ApiNetJoke.Models;
using Moq;

namespace ApiNetJoke.Business.UnitTests
{
    public class JokeServiceUnitTestsUnitTests
    {
        private readonly Mock<IJokeRequestService> _JokeRequestServiceMock;
        private readonly IJokeService jokeService;



        public JokeServiceUnitTestsUnitTests()
        {
            _JokeRequestServiceMock = new Mock<IJokeRequestService>();

            jokeService = new JokeService(_JokeRequestServiceMock.Object);
        }

        [Fact]
        public async Task GetJokesWithOneShouldCallGetJokeOfJokeRequestService()
        {
            // Arrange
            var testJoke = new OfficialJokeApiJokeResponse
            {
                Id = 1,
                Punchline = "MyPunchline",
                Setup = "MySetup",
                Type = "MyType"
            };
            _JokeRequestServiceMock.Setup(service => service.GetJoke()).ReturnsAsync(testJoke);

            // Act
            IEnumerable<string> jokes = await jokeService.GetJokes(1);

            // Assert
            Assert.Equal(testJoke.ToString(), jokes.First());
            _JokeRequestServiceMock.Verify(service => service.GetJoke());
            _JokeRequestServiceMock.Verify(service => service.GetTenJokes(), Times.Never);
        }

        [Fact]
        public async Task GetJokesWithMoreThanOneShouldCallGetTenJokesOfJokeRequestService()
        {
            // Arrange
            var testJokes = new List<OfficialJokeApiJokeResponse>
            {
                new OfficialJokeApiJokeResponse
            {
                Id = 1,
                Punchline = "MyPunchline",
                Setup = "MySetup",
                Type = "MyType"
            },
                new OfficialJokeApiJokeResponse
            {
                Id = 2,
                Punchline = "MyPunchline",
                Setup = "MySetup",
                Type = "MyType"
                }
            };

            _JokeRequestServiceMock.Setup(x => x.GetTenJokes()).ReturnsAsync(testJokes);

            // Act
            IEnumerable<string> jokes = await jokeService.GetJokes(2);

            // Assert
            Assert.Equal(testJokes.Count(), jokes.Count());
        }
    }
}