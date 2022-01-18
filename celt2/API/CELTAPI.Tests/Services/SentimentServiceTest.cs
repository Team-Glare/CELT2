/**
* @license
* Copyright Team Glare. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
*/

using CELTAPI.Model;
using CELTAPI.Services;
using CELTAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CELTAPI.Tests.Services
{
    /// <summary>
    /// Test class for sentiment services.
    /// </summary>
    public class SentimentServiceShould
    {
        /// <summary>
        /// Tests for sentiment positive equality from plain text.
        /// </summary>
        [Test]
        public async Task CalculateSentimentFromTextEquality()
        {
            var mockTextInput = new Mock<TextInput>();
            var mockStreamReader = new Mock<IStreamReader>();
            var mockServerClient = new Mock<IServerClient>();

            var mockResult = new SentimentResult
            {
                label = "Positive"
            };

            mockServerClient.Setup(o => o.PostAsync<SentimentResult, TextInput>(It.IsAny<string>(), It.IsAny<TextInput>())).ReturnsAsync(mockResult);

            var sut = new SentimentService(mockStreamReader.Object, mockServerClient.Object);
            var result = await sut.CalculateSentimentFromText(mockTextInput.Object);

            Assert.That(result, Is.EqualTo("Positive"));
        }

        /// <summary>
        /// Tests for sentiment positive in equality from plain text.
        /// </summary>
        [Test]
        public async Task CalculateSentimentFromTextInEquality()
        {
            var mockTextInput = new Mock<TextInput>();
            var mockStreamReader = new Mock<IStreamReader>();
            var mockServerClient = new Mock<IServerClient>();

            var mockResult = new SentimentResult
            {
                label = "Positive"
            };

            mockServerClient.Setup(o => o.PostAsync<SentimentResult, TextInput>(It.IsAny<string>(), It.IsAny<TextInput>())).ReturnsAsync(mockResult);

            var sut = new SentimentService(mockStreamReader.Object, mockServerClient.Object);
            var result = await sut.CalculateSentimentFromText(mockTextInput.Object);

            Assert.That(result, Is.Not.EqualTo("Negative"));
        }

        /// <summary>
        /// Tests for sentiment positive equality from text file.
        /// </summary>
        [Test]
        public async Task CalculateSentimentFromTextFileEquality()
        {
            var mockFormFile = new Mock<IFormFile>();
            var mockTextInput = new Mock<TextInput>();
            var mockStreamReader = new Mock<IStreamReader>();
            var mockServerClient = new Mock<IServerClient>();

            var mockResult = new SentimentResult
            {
                label = "Positive"
            };

            mockStreamReader.Setup(o => o.GetReader(mockFormFile.Object.OpenReadStream())).Returns(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file"))));

            mockServerClient.Setup(o => o.PostAsync<SentimentResult, TextInput>(It.IsAny<string>(), It.IsAny<TextInput>())).ReturnsAsync(mockResult);

            var sut = new SentimentService(mockStreamReader.Object, mockServerClient.Object);
            var result = await sut.CalculateSentimentFromTextFile(mockFormFile.Object);

            Assert.That(result, Is.EqualTo("Positive"));
        }

        /// <summary>
        /// Tests for sentiment positive in equality from text file.
        /// </summary>
        [Test]
        public async Task CalculateSentimentFromTextFileInEquality()
        {
            var mockFormFile = new Mock<IFormFile>();
            var mockTextInput = new Mock<TextInput>();
            var mockStreamReader = new Mock<IStreamReader>();
            var mockServerClient = new Mock<IServerClient>();

            var mockResult = new SentimentResult
            {
                label = "Positive"
            };

            mockStreamReader.Setup(o => o.GetReader(mockFormFile.Object.OpenReadStream())).Returns(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file"))));

            mockServerClient.Setup(o => o.PostAsync<SentimentResult, TextInput>(It.IsAny<string>(), It.IsAny<TextInput>())).ReturnsAsync(mockResult);

            var sut = new SentimentService(mockStreamReader.Object, mockServerClient.Object);
            var result = await sut.CalculateSentimentFromTextFile(mockFormFile.Object);

            Assert.That(result, Is.Not.EqualTo("Negative"));
        }
    }
}
