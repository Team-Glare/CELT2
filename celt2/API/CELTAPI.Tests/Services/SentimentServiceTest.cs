using CELTAPI.Model;
using CELTAPI.Services;
using CELTAPI.Utilities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
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
            var sut = new SentimentService(mockStreamReader.Object);

            var result = await sut.CalculateSentimentFromText(mockTextInput.Object);

            Assert.That(result, Is.EqualTo("Positive"));
        }
    }
}
