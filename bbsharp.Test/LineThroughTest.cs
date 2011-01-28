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
    public class LineThroughTest
    {
        [Test]
        public void SimpleThroughTest()
        {
            var input = "[s]the text to test[/s]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><span style=\"text-decoration: line-through\">the text to test</span></body>", output);
        }

        [Test]
        public void InternalThoughTest()
        {
            var input = "[p][s]the text to test[/s][/p]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><p><span style=\"text-decoration: line-through\">the text to test</span></p></body>", output);
        }

        [Test]
        public void TagsInsideThroughTest()
        {
            var input = "[p][s]the [b]text[/b] to test[/s][/p]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body><p><span style=\"text-decoration: line-through\">the <b>text</b> to test</span></p></body>", output);
        }
    }
}
