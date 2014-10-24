using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace E5R.SimpleAutoDeployer.Tasks.Tests
{
    public class QueueTest
    {
        [Fact]
        public void Ok()
        {
            Assert.True("OK" == "ok".ToUpper());
        }

        [Fact]
        public void Error()
        {
            Assert.Throws<Exception>( () =>
            {
                throw new Exception("Random error");
            });
        }
    }
}
