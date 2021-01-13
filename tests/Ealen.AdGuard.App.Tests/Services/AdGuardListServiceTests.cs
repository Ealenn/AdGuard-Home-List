using Ealen.AdGuard.App.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ealen.AdGuard.App.Tests.Services
{
    public class AdGuardListServiceTests
    {
        private readonly Mock<ILogger<AdGuardListService>> _loggerMock;

        public AdGuardListServiceTests()
        {
            _loggerMock = new Mock<ILogger<AdGuardListService>>();
        }

        #region AdGuard
        [Theory]
        [InlineData("# Comment", "")]
        [InlineData(" ||example.com^  ", "||example.com^")]
        [InlineData("||example.com^", "||example.com^")]
        public void FileLineTransform_WithAdGuardBlock_ExpectValidAdGuardStyle(string input, string output)
        {
            // A
            var service = new AdGuardListService(_loggerMock.Object);

            // A
            var result = service.FileLineTransform(input, FileProviderFormat.AD_GUARD, FileProviderType.BLOCK_LIST);

            // A
            result.Should().Be(output);
        }
        [Theory]
        [InlineData("# Comment", "")]
        [InlineData(" @@||example.com^$important  ", "@@||example.com^$important")]
        [InlineData("@@||example.com^$important", "@@||example.com^$important")]
        public void FileLineTransform_WithAdGuardAllow_ExpectValidAdGuardStyle(string input, string output)
        {
            // A
            var service = new AdGuardListService(_loggerMock.Object);

            // A
            var result = service.FileLineTransform(input, FileProviderFormat.AD_GUARD, FileProviderType.ALLOW_LIST);

            // A
            result.Should().Be(output);
        }
        #endregion

        #region Host
        [Theory]
        [InlineData("# Comment", "")]
        [InlineData("127.0.0.1      example.com  ", "||example.com^")]
        [InlineData("0.0.0.0 example.com", "||example.com^")]
        public void FileLineTransform_WithHostBlock_ExpectValidAdGuardStyle(string input, string output)
        {
            // A
            var service = new AdGuardListService(_loggerMock.Object);

            // A
            var result = service.FileLineTransform(input, FileProviderFormat.HOSTS, FileProviderType.BLOCK_LIST);

            // A
            result.Should().Be(output);
        }
        [Theory]
        [InlineData("# Comment", "")]
        [InlineData("127.0.0.1      example.com  ", "@@||example.com^$important")]
        [InlineData("0.0.0.0 example.com", "@@||example.com^$important")]
        public void FileLineTransform_WithHostAllow_ExpectValidAdGuardStyle(string input, string output)
        {
            // A
            var service = new AdGuardListService(_loggerMock.Object);

            // A
            var result = service.FileLineTransform(input, FileProviderFormat.HOSTS, FileProviderType.ALLOW_LIST);

            // A
            result.Should().Be(output);
        }
        #endregion

        #region PiHole
        [Theory]
        [InlineData("# Comment", "")]
        [InlineData(" example.com  ", "||example.com^")]
        [InlineData("example.com", "||example.com^")]
        public void FileLineTransform_WithPiHoleBlock_ExpectValidAdGuardStyle(string input, string output)
        {
            // A
            var service = new AdGuardListService(_loggerMock.Object);

            // A
            var result = service.FileLineTransform(input, FileProviderFormat.PI_HOLE, FileProviderType.BLOCK_LIST);

            // A
            result.Should().Be(output);
        }
        [Theory]
        [InlineData("# Comment", "")]
        [InlineData(" example.com  ", "@@||example.com^$important")]
        [InlineData("example.com", "@@||example.com^$important")]
        public void FileLineTransform_WithPiHoleAllow_ExpectValidAdGuardStyle(string input, string output)
        {
            // A
            var service = new AdGuardListService(_loggerMock.Object);

            // A
            var result = service.FileLineTransform(input, FileProviderFormat.PI_HOLE, FileProviderType.ALLOW_LIST);

            // A
            result.Should().Be(output);
        }
        #endregion
    }
}
