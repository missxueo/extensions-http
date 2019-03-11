using System;
using System.Diagnostics;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace Meng.Net.Http.UnitTest
{
    public class CreateAndReadTest
    {
        public CreateAndReadTest(ITestOutputHelper output)
        {
            _output = output;
        }
        private ITestOutputHelper _output;


        [Theory()]
        [InlineData("hello world")]
        public void Test(string content)
        {
            var httpContent = new JsonContent(content);
            var result = httpContent.ReadAsStringAsync().Result;
            Assert.Equal("hello world", result);
            Assert.Equal("application/json", httpContent.Headers.ContentType.MediaType);
        }

        [Fact]
        public void Test1()
        {
            var data = new
            {
                key1 = "value1",
                key2 = 12,
            };
            var httpContent = new JsonContent(data);
            Print(httpContent);

            Assert.Equal("application/json", httpContent.Headers.ContentType.MediaType);
        }

        private void Print(JsonContent content)
        {
            foreach(var head in content.Headers)
            {
                _output.WriteLine($"{head.Key}:\t{string.Join(", ", head.Value)}");
            }

            _output.WriteLine(content.ReadAsStringAsync().Result);

        }

    }
}
