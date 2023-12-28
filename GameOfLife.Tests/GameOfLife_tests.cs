using Moq;

namespace GameOfLife.Tests
{
    [TestClass]
    public class GameOfLife_tests
    {
        //[TestMethod]
        //[Ignore]
        //public void bnm()
        //{
        //    //Arrange
        //    var gridMock = new Mock<IGrid>();
        //    var inputHandlerMock = new Mock<IInputHandler>();

        //    GameOfLife game = new GameOfLife(gridMock.Object);

        //    //StringWriter writer = new StringWriter();
        //    //Console.SetOut(writer);

        //    inputHandlerMock.Setup(ih => ih.PauseOrEnd(It.IsAny<bool>(), It.IsAny<int>(), 
        //        It.IsAny<int>(), It.IsAny<IGrid>())).Returns(true);

        //    gridMock.Setup(g => g.CountAliveCells(gridMock.Object)).Returns(10);
        //    gridMock.Setup(g => g.UpdateGrid()).Callback(() => 
        //    gridMock.Setup(g => g.CountAliveCells(gridMock.Object)).Returns(5));

        //    string expectedExitGame = "Press 'x' to exit the game!";
        //    string expectedPauseGame = "Press 'Spacebar' to pause/unpause the game!";

        //    //Act
        //    Thread runThread = new Thread(() => game.Run());
        //    runThread.Start();
        //    Thread.Sleep(1000);

        //    game.ExitLoop = true;

        //    //game.ClearConsole();

        //    runThread.Join();

        //    //Assert
        //    //string output = writer.ToString();
        //    //Assert.IsTrue(output.Contains(expectedPauseGame));
        //    //Assert.IsTrue(output.Contains(expectedExitGame));

        //    gridMock.Verify(g => g.UpdateGrid(), Times.AtLeastOnce);
        //    Assert.AreEqual(2, game.Iteration);
        //}

        [TestMethod]
        public void GivenGame_WhenDisplay_ThenConsoleText()
        {
            //Arrange
            GameOfLife game = new GameOfLife(grid: new Grid(10,10));
            string actualOutput;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                game.Display();
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.IsTrue(actualOutput.Contains("Press 'Spacebar' to pause/unpause the game!"));
            Assert.IsTrue(actualOutput.Contains("Iteration 0"));

        }
    }
}
