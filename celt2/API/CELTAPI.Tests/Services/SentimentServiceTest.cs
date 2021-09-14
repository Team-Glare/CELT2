using CELTAPI.Models;
using CELTAPI.Services;
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
            var sut = new SentimentService();

            var result = await sut.CalculateSentiment(mockTextInput.Object);

            Assert.That(result, Is.EqualTo("positive"));
        }
    }
}
