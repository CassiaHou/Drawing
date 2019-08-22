using Drawing.Domain;
using NUnit.Framework;
using System;

namespace Drawing.DomainTest
{
    public class DrawerTest
    {
        private IDrawer Target;

        [Test]
        public void ShouldCanCreateNewCanvasCommand()
        {
            Target = new Drawer();
            Assert.DoesNotThrow(() => Target.Draw("C 20 4"));
        }

        [Test]
        public void ShouldCreateANewCanvas()
        {
            Target = new Drawer();
            var result = Target.Draw("C 20 4").ToArray();
            Assert.AreEqual(result[0], "----------------------");
            Assert.AreEqual(result[1], "|                    |");
            Assert.AreEqual(result[2], "|                    |");
            Assert.AreEqual(result[3], "|                    |");
            Assert.AreEqual(result[4], "|                    |");
            Assert.AreEqual(result[5], "----------------------");
        }

        [Test]
        public void ShouldThrowExceptionIfTryExcuteOtherCommandNotCreateConvasCommandWithoutCreatingACanvasFirst()
        {
            Target = new Drawer();
            Assert.Catch<InvalidOperationException>(() => Target.Draw("L 1 2 6 2"));
        }
        

        [Test]
        public void ShouldThrowExceptionIfItIsNotCreatingHorizontalOrVerticalLine()
        {
            Target = new Drawer();
            Target.Draw("C 20 4");
            Assert.Catch<ArgumentException>(() => Target.Draw("L 1 2 6 3"));
        }

        [Test]
        public void ShouldDrawHorizontalLine()
        {
            Target = new Drawer();
            Target.Draw("C 20 4");
            var result = Target.Draw("L 1 2 6 2").ToArray();
            Assert.AreEqual(result[0], "----------------------");
            Assert.AreEqual(result[1], "|                    |");
            Assert.AreEqual(result[2], "|xxxxxx              |");
            Assert.AreEqual(result[3], "|                    |");
            Assert.AreEqual(result[4], "|                    |");
            Assert.AreEqual(result[5], "----------------------");
        }

        [Test]
        public void ShouldDrawVerticalLine()
        {
            Target = new Drawer();
            Target.Draw("C 20 4");
            Target.Draw("L 1 2 6 2");
            var result = Target.Draw("L 6 3 6 4").ToArray();
            Assert.AreEqual(result[0], "----------------------");
            Assert.AreEqual(result[1], "|                    |");
            Assert.AreEqual(result[2], "|xxxxxx              |");
            Assert.AreEqual(result[3], "|     x              |");
            Assert.AreEqual(result[4], "|     x              |");
            Assert.AreEqual(result[5], "----------------------");
        }

        [Test]
        public void ShouldDrawANewRectangle()
        {
            Target = new Drawer();
            Target.Draw("C 20 4");
            Target.Draw("L 1 2 6 2");
            Target.Draw("L 6 3 6 4");
            var result = Target.Draw("R 14 1 18 3").ToArray();
            Assert.AreEqual(result[0], "----------------------");
            Assert.AreEqual(result[1], "|             xxxxx  |");
            Assert.AreEqual(result[2], "|xxxxxx       x   x  |");
            Assert.AreEqual(result[3], "|     x       xxxxx  |");
            Assert.AreEqual(result[4], "|     x              |");
            Assert.AreEqual(result[5], "----------------------");
        }

        [Test]
        public void ShouldDoBucketFill()
        {
            Target = new Drawer();
            Target.Draw("C 20 4");
            Target.Draw("L 1 2 6 2");
            Target.Draw("L 6 3 6 4");
            Target.Draw("R 14 1 18 3");
            var result = Target.Draw("B 10 3 o").ToArray();

            Assert.AreEqual(result[0], "----------------------");
            Assert.AreEqual(result[1], "|oooooooooooooxxxxxoo|");
            Assert.AreEqual(result[2], "|xxxxxxooooooox   xoo|");
            Assert.AreEqual(result[3], "|     xoooooooxxxxxoo|");
            Assert.AreEqual(result[4], "|     xoooooooooooooo|");
            Assert.AreEqual(result[5], "----------------------");

        }
    }
}