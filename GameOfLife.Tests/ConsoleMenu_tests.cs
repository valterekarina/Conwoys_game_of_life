namespace GameOfLife.Tests
{
    [TestClass]
    public class ConsoleMenu_tests
    {
        [TestMethod]
        public void CallingMethod_WhenCreateMenu_ThenDisplaysMenu()
        {
            //Arrange
            IMenu menu = new ConsoleMenu();
            string expectedOutput = "Field sizes:\n\r\n" +
                                    "1) 10x10\r\n" +
                                    "2) 15x15\r\n" +
                                    "3) 20x20\r\n" +
                                    "4) 36x36\r\n" +
                                    "5) Choose your own grid height and width\r\n" +
                                    "6) Load previous game\r\n" +
                                    "7) Stop the application\r\n";
            string actualOutput;

            //Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                menu.CreateMenu();
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void GivenOption1_WhenHandleOption_ThenGameHeightEqual()
        {
            //Arrange
            IMenu menu = new ConsoleMenu();
            int option = 1;

            //Act
            GameOfLife gameActual = menu.HandleOption(option);

            //Assert
            Assert.AreEqual(10, gameActual.Grid.Height);
        }

        [TestMethod]
        public void GivenOption2_WhenHandleOption_ThenGameWidthEqual()
        {
            //Arrange
            IMenu menu = new ConsoleMenu();
            int option = 2;

            //Act
            GameOfLife gameActual = menu.HandleOption(option);

            //Assert
            Assert.AreEqual(15, gameActual.Grid.Width);
        }

        [TestMethod]
        public void GivenOption3_WhenHandleOption_ThenCellIsFalse()
        {
            //Arrange
            IMenu menu = new ConsoleMenu();
            int option = 3;

            //Act
            GameOfLife gameActual = menu.HandleOption(option);

            //Assert
            Assert.IsFalse(gameActual.Grid.Cells[1, 1].IsAlive);
        }

        [TestMethod]
        public void GivenOption4_WhenHandleOption_ThenAliveCellsEqual()
        {
            //Arrange
            IMenu menu = new ConsoleMenu();
            int option = 4;

            //Act
            GameOfLife gameActual = menu.HandleOption(option);

            //Assert
            Assert.AreEqual(36, gameActual.Grid.CountAliveCells(gameActual.Grid));
        }

        [TestMethod]
        public void GivenOption8_WhenHandleOption_ThenGameHeightEqual()
        {
            //Arrange
            IMenu menu = new ConsoleMenu();
            int option8 = 8;
            string expectedOutput = "There is no option 8\r\n";
            string actualOutput;

            //Act
            GameOfLife game8 = menu.HandleOption(option8);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                menu.HandleOption(option8);
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.IsNull(game8);
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
