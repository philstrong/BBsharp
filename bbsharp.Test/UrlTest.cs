using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using bbsharp.Easy;

namespace bbsharp.Test
{
    [TestFixture]
    [Category("Unit")]
    public class UrlTest
    {        

        [Test]
        public void HttpHeaderUrlTest()
        {
            var input = "and [url=http://about.com]then [/url]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body>and <a href=\"http://about.com/\">then </a></body>", output);
        }

        [Test]
        public void HttpsHeaderUrlTest()
        {
            var input = "and [url=https://about.com]then [/url]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body>and <a href=\"https://about.com/\">then </a></body>", output);
        }

        [Test]
        public void SimpleUrlTest()
        {
            var input = "on that may still be reflected in beaten down [url=http://www.istockanalyst.com/article/viewarticlepaged/articleid/4493833/pageid/1]shares[/url].\"That means the stock could soar even higher than it is today";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body>on that may still be reflected in beaten down <a href=\"http://www.istockanalyst.com/article/viewarticlepaged/articleid/4493833/pageid/1\">shares</a>.&quot;That means the stock could soar even higher than it is today</body>", output);
        }

        [Test]
        public void ComplexUrlTest()
        {
            var input = "[p]on that may still be reflected in beaten down [url=http://www.istockanalyst.com/article/viewarticlepaged/articleid/4493833/pageid/1][b]shares[/b][/url].\"That means the stock could soar even higher than it is today[/p]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><p>on that may still be reflected in beaten down <a href=\"http://www.istockanalyst.com/article/viewarticlepaged/articleid/4493833/pageid/1\"><b>shares</b></a>.&quot;That means the stock could soar even higher than it is today</p></body>", output);
            
        }
    }
}
