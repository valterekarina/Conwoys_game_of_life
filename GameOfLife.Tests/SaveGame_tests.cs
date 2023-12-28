namespace GameOfLife.Tests
{
    [TestClass]
    public class SaveGame_tests
    {
        [TestMethod]
        public void GivenCorrectFilePath_WhenCallingSaveGame_ThenGameSaved()
        {
            //Arrange
            int iteration = 0;
            int cellsAlive = 10;
            IGrid grid = new Grid(10,10);
            string filePath = "C:\\Users\\karina.e.valtere\\OneDrive - Accenture\\Desktop\\experiment\\testtesttest.txt";
            ISaveGame gameSaver = new SaveGame();
            string expectedOutput = "Game information save to file C:\\Users\\karina.e.valtere\\OneDrive - Accenture\\Desktop\\experiment\\testtesttest.txt\r\n";
            string actualOutput;

            //Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                gameSaver.SaveGameInfo(iteration, cellsAlive, grid, filePath);
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
