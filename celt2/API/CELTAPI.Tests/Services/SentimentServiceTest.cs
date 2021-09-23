using CELTAPI.Model;
using CELTAPI.Services;
using CELTAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            var mockServerClient = new Mock<IServerClient>();

            var mockResult = new SentimentResult();
            mockResult.label = "Positive";

            mockServerClient.Setup(o => o.PostAsync<SentimentResult, string>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(mockResult);

            var sut = new SentimentService(mockStreamReader.Object, mockServerClient.Object);
            var result = await sut.CalculateSentimentFromText(mockTextInput.Object);

            Assert.That(result, Is.EqualTo("Positive"));
        }
    }
}
