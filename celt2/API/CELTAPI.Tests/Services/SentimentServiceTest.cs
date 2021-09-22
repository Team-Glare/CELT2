using CELTAPI.Models;
using CELTAPI.Services;
using CELTAPI.Utilities;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CELTAPI.Tests.Services
{
    /// <summary>
    /// Tests for Sentiment Service
    /// </summary>

    public class SentimentServiceShould
    {
        [Test]
        public async Task CalculateSentimentEquality()
        {
            var mockTextInput = new Mock<TextInput>();
            var mockStreamReader = new Mock<IStreamReader>();
            var sut = new SentimentService(mockStreamReader.Object);

            var result = await sut.CalculateSentimentFromText(mockTextInput.Object);

            Assert.That(result, Is.EqualTo("Positive"));
        }
    }
}
