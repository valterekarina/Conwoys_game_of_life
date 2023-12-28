namespace GameOfLife.Tests
{
    [TestClass]
    public class LoadGame_tests
    {
        [TestMethod]
        public void GrivenCorrectFilePath_WhenLoadGame_ThenGameLoaded()
        {
            //Arrange
            ILoadGame gameLoader = new LoadGame();
            int expectedIteration;
            int expectedCellsAlive;

            //Act
            using (StreamReader reader = new StreamReader("C:\\Users\\karina.e.valtere\\OneDrive - Accenture\\Desktop\\experiment\\test.txt"))
            {
                string iterationString = reader.ReadLine();
                string cellsAliveString = reader.ReadLine();
                expectedIteration = int.Parse(iterationString?.Substring(iterationString.IndexOf(':') + 1));
                expectedCellsAlive = int.Parse(cellsAliveString?.Substring(cellsAliveString.IndexOf(':') + 1));
            }

            var game = gameLoader.GameLoad("C:\\Users\\karina.e.valtere\\OneDrive - Accenture\\Desktop\\experiment\\test.txt");

            //Assert
            Assert.AreEqual(expectedIteration, game.Iteration);
            Assert.AreEqual(expectedCellsAlive, game.CellsAlive);
        }

        [TestMethod]
        public void GrivenIncorrectFilePath_WhenLoadGame_ThenGameNotLoaded()
        {
            //Arrange
            ILoadGame gameLoader = new LoadGame();

            //Act
            var game = gameLoader.GameLoad("incorrectPath");

            //Assert
            Assert.IsNull(game);
        }
    }
}
