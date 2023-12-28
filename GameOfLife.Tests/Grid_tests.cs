namespace GameOfLife.Tests
{
    [TestClass]
    public class Grid_tests
    {
        private readonly IGrid _grid;

        public Grid_tests()
        {
            _grid = new Grid(15,15);
        }
        [TestMethod]
        public void GivenNegativeX_WhenGetCell_ThenNull()
        {
            //Arrange
            int height = -1;
            int width = 5;

            //Act
            ICell result = _grid.GetCell(height, width);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GivenNegativeY_WhenGetCell_ThenNull()
        {
            //Arrange
            int height = 5;
            int width = -1;

            //Act
            ICell result = _grid.GetCell(height, width);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GivenCorrectXY_WhenGetCell_ThenCell()
        {
            //Arrange
            int height = 5;
            int width = 5;

            //Act
            ICell result = _grid.GetCell(height, width);

            //Assert
            Assert.IsFalse(result.IsAlive);
        }

        [TestMethod]
        public void GivenTooBigX_WhenGetCell_ThenCell()
        {
            //Arrange
            int height = 16;
            int width = 5;

            //Act
            ICell result = _grid.GetCell(height, width);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GivenTooBigY_WhenGetCell_ThenCell()
        {
            //Arrange
            int height = 4;
            int width = 16;

            //Act
            ICell result = _grid.GetCell(height, width);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Given_WhenCountAliveCells_ThenCellCount()
        {
            //Arrange

            //Act
            int result = _grid.CountAliveCells(_grid);

            //Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void GivenTrue_WhenSteCell_ThenCellTrue()
        {
            //Arrange
            int height = 4;
            int width = 5;
            bool isAlive = true;

            //Act
            _grid.SetCell(height, width, isAlive);

            //Assert
            Assert.IsTrue(_grid.Cells[height, width].IsAlive);
        }

        [TestMethod]
        public void TestDefaultDisplayGrid()
        {
            //Arrange
            int height = 3;
            int width = 4;
            IGrid grid = new Grid(height, width);
            string actualOutput;
            string expectedOutput = "  * \r\n" +
                                    "* * \r\n" +
                                    " ** \r\n";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                grid.DisplayGrid(grid);
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void TestSmallestDisplayGrid()
        {
            //Arrange
            int height = 4;
            int width = 10;
            IGrid grid = new Grid(height, width);
            string actualOutput;
            string expectedOutput = "  *       \r\n" +
                                    "* *    *  \r\n" +
                                    " **    * *\r\n" +
                                    "       ** \r\n";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                grid.DisplayGrid(grid);
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void TestSmallDisplayGrid()
        {
            //Arrange
            int height = 11;
            int width = 11;
            IGrid grid = new Grid(height, width);
            string actualOutput;
            string expectedOutput = "  *        \r\n" +
                                    "* *     *  \r\n" +
                                    " **     * *\r\n" +
                                    "        ** \r\n" +
                                    "           \r\n" +
                                    "           \r\n" +
                                    "           \r\n" +
                                    " **        \r\n" +
                                    "* *     ** \r\n" +
                                    "  *     * *\r\n" +
                                    "        *  \r\n";


            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                grid.DisplayGrid(grid);
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestMediumDisplayGrid()
        {
            //Arrange
            int height = 20;
            int width = 20;
            IGrid grid = new Grid(height, width);
            string actualOutput;
            string expectedOutput = "                    \r\n" +
                                    "                    \r\n" +
                                    "                    \r\n" +
                                    "                    \r\n" +
                                    "                    \r\n" +
                                    "                    \r\n" +
                                    "          *         \r\n" +
                                    "         * *        \r\n" +
                                    "        *   *       \r\n" +
                                    "       *  *  *      \r\n" +
                                    "      *  ***  *     \r\n" +
                                    "       *  *  *      \r\n" +
                                    "        *   *       \r\n" +
                                    "         * *        \r\n" +
                                    "          *         \r\n" +
                                    "                    \r\n" +
                                    "                    \r\n" +
                                    "                    \r\n" +
                                    "                    \r\n" +
                                    "                    \r\n";


            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Act
                grid.DisplayGrid(grid);
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestLargeDisplayGrid()
        {
            //Arrange
            int height = 11;
            int width = 36;
            IGrid grid = new Grid(height, width);
            string actualOutput;
            string expectedOutput = "                                    \r\n" +
                                    "                        *           \r\n" +
                                    "                      * *           \r\n" +
                                    "            **      **            **\r\n" +
                                    "           *   *    **            **\r\n" +
                                    "**        *     *   **              \r\n" +
                                    "**        *   * **    * *           \r\n" +
                                    "          *     *       *           \r\n" +
                                    "           *   *                    \r\n" +
                                    "            **                      \r\n" +
                                    "                                    \r\n";

            //Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                grid.DisplayGrid(grid);
                actualOutput = sw.ToString();
            }

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void GivenGrid_WhenUpdateGrid_ThenNextCellCount()
        {
            //Arrange
            IGrid grid = new Grid(36, 36);

            //Act
            grid.UpdateGrid();
            int actualCellCount = grid.CountAliveCells(grid);

            //Assert
            Assert.AreEqual(39, actualCellCount);

        }
    }
}
