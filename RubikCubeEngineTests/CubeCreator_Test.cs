using RubikCubeEngine;

namespace RubikCubeEngineTests
{
    public class CubeCreator_Test
    {
        private CubeCreator _cubeCreator;

        public CubeCreator_Test()
        {
            _cubeCreator = new CubeCreator();
        }

        [Fact]
        public void TestCubeCreation()
        {
            //act
            var cube = _cubeCreator.Create();

            //assert
            Assert.NotNull(cube);
            Assert.Equal(6, cube.GetLength(0));
            Assert.Equal(3, cube.GetLength(1));
            Assert.Equal(3, cube.GetLength(2));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
       
        public void Create_different_cube_sizes(int value)
        {
            //act
            var result = _cubeCreator.Create(matrixSize: value);

            //assert
            Assert.Equal(value, result.GetLength(1));
            Assert.Equal(value, result.GetLength(2));
        }
    }
}