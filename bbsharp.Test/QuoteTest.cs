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
    public class QuoteTest
    {
        [Test]
        public void SimpleQuoteTest()
        {
            var input = "[quote]the text to test[/quote]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><div class=\"quote\">the text to test</div></body>", output);
        }

        [Test]
        public void InternalQuoteTest()
        {
            var input = "[p][quote]the text to test[/quote][/p]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><p><div class=\"quote\">the text to test</div></p></body>", output);
        }

        [Test]
        public void TagsInsideQuoteTest()
        {
            var input = "[p][quote]the [b]text[/b] to test[/quote][/p]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><p><div class=\"quote\">the <b>text</b> to test</div></p></body>", output);
        }

        [Test]
        public void ComplexQuoteTest()
        {
            var input = "[p]Ok lets try this again[/p][quote][p]qouted text[/p][/quote][p]the final paragraph[/p]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><p>Ok lets try this again</p><div class=\"quote\"><p>qouted text</p></div><p>the final paragraph</p></body>", output);
        }

        [Test]
        public void ActualQuotesTest()
        {
            var input = "[p]Ok lets try this again[/p]\"[p]qouted text[/p]\"[p]the final paragraph[/p]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><p>Ok lets try this again</p>&quot;<p>qouted text</p>&quot;<p>the final paragraph</p></body>", output);
        }
        
    }
}
