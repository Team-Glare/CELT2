using CELTAPI.Model;
using CELTAPI.Services;
using CELTAPI.Utilities;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CELTAPI.Tests.Services
{
    public class SentimentServiceShould
    {
        [Test]
        public async Task CalculateSentimentEquality()
        {
            var mockTextInput = new Mock<TextInput>();
            var mockStreamReader = new Mock<IStreamReader>();
            var mockServerClient = new Mock<IServerClient>();

            var mockResult = new SentimentResult
            {
                label = "Positive"
            };

            mockServerClient.Setup(o => o.PostAsync<SentimentResult, string>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(mockResult);

            var sut = new SentimentService(mockStreamReader.Object, mockServerClient.Object);
            var result = await sut.CalculateSentimentFromText(mockTextInput.Object);

            Assert.That(result, Is.EqualTo("Positive"));
        }
    }
}
