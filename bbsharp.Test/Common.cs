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
    public class Common
    {

        [Test]
        public void TestLeftOnlyBracket()
        {
            var input = "and [ I am the best blogger ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body>and [I am the best blogger ever</body>", output);
        }

        [Test]
        public void TestRightOnlyBracket()
        {
            var input = "and ] I am the best blogger ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);

            Assert.AreEqual("<body>and ] I am the best blogger ever</body>", output);
        }

        [Test]
        public void TestEmptyBracketsOnlyBracket()
        {
            var input = "and [] I am the best blogger ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            // empty brackets get removed
            Assert.AreEqual("<body>and  I am the best blogger ever</body>", output);
        }

        [Test]
        public void TestBold()
        {
            var input = "and [b] I am the best blogger[/b] ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body>and <b> I am the best blogger</b> ever</body>", output);
        }

        [Test]
        public void TestItalic()
        {
            var input = "and [i] I am the best blogger[/i] ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body>and <i> I am the best blogger</i> ever</body>", output);
        }

        [Test]
        public void TestBoldandInnerItalic()
        {
            var input = "and [b] I am the [i]best[/i] blogger[/b] ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body>and <b> I am the <i>best</i> blogger</b> ever</body>", output);
        }

        [Test]
        public void TestUnderline()
        {
            var input = "and [u] I am the best blogger[/u] ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body>and <span style=\"text-decoration: underline\"> I am the best blogger</span> ever</body>", output);
        }

        [Test]
        public void TestSize()
        {
            var input = "and [size=16] I am the best blogger[/size] ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body>and <span style=\"font-size: 16px\"> I am the best blogger</span> ever</body>", output);
        }

        [Test]
        public void TestColor()
        {
            var input = "and [color=orange] I am the best blogger[/color] ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body>and <span style=\"color:orange\"> I am the best blogger</span> ever</body>", output);
        }

        [Test]
        public void TestHexColor()
        {
            var input = "and [color=#cc0000] I am the best blogger[/color] ever";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body>and <span style=\"color:#cc0000\"> I am the best blogger</span> ever</body>", output);
        }

        [Test]
        public void TestOrderedList()
        {
            var input = "[ol][li]Item one[/li][li]Item two[/li][/ol]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body><ol><li>Item one</li><li>Item two</li></ol></body>", output);
        }
        
        [Test]
        public void TestOrderedList2()
        {
            var input = "[ol][li]the best number one[/li][li]and then there was two[/li][li]and three[/li][/ol]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body><ol><li>the best number one</li><li>and then there was two</li><li>and three</li></ol></body>", output);
        }

        [Test]
        public void TestUnorderedOrderedList()
        {
            var input = "[ul][li]uno[/li][li]dos[/li][li]tres with some [b]bold[/b] text[/li][/ul]";

            var output = input.BbToHtml();

            Assert.IsNotNull(output);
            Assert.AreNotEqual(output, input);
            
            Assert.AreEqual("<body><ul><li>uno</li><li>dos</li><li>tres with some <b>bold</b> text</li></ul></body>", output);
        }
    }
}
