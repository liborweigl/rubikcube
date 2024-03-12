namespace RubikCubeEngine
{
    public class RubikCubeEngine : IRubikCubeEngine
    {

        private string[,,] rubikCubeDefinition;
        private const int FaceSize = 6;
        private const int MatrixSize = 3;
        private IPrintService PrintService;


        public RubikCubeEngine()
        {
            PrintService = new PrintService();
            rubikCubeDefinition = InitializeCube();

        }

        public RubikCubeEngine(int matrixSize)
        {
            PrintService = new PrintService();
            rubikCubeDefinition = InitializeCube(matrixSize);
        }

        private string[,,] InitializeCube(int matrixSize = 3)
        {
            rubikCubeDefinition = new string[FaceSize, matrixSize, matrixSize];

            foreach (var cubeSideDefintion in CubeConfiguration.GetCubeDefintion())
            {

                for (int j = 0; j < matrixSize; j++)
                {
                    for (int k = 0; k < matrixSize; k++)
                    {
                        rubikCubeDefinition[(int)cubeSideDefintion.face, j, k] = cubeSideDefintion.color;
                    }
                }

            }

            return rubikCubeDefinition;
        }



        public void RotateCubeNineteeDegreeClockwise(CubeFace cubeFace)
        {
            RotateFaceClockwise(cubeFace);
            ApplyRotationOnEdgeFaces(cubeFace);

        }


        public void RotateCubeNineteeDegreeAntiClockwise(CubeFace cubeFace)
        {

            //we can rotate the face 3 times clockwise to achieve anticlockwise rotation
            RotateFaceClockwise(cubeFace);
            ApplyRotationOnEdgeFaces(cubeFace);

            RotateFaceClockwise(cubeFace);
            ApplyRotationOnEdgeFaces(cubeFace);

            RotateFaceClockwise(cubeFace);
            ApplyRotationOnEdgeFaces(cubeFace);

        }

        private void RotateFaceClockwise(CubeFace cubeFace)
        {
            string[,] rotatedFace = new string[MatrixSize, MatrixSize];

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    rotatedFace[i, j] = rubikCubeDefinition[(int)cubeFace, MatrixSize - 1 - j, i];
                }
            }

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    rubikCubeDefinition[(int)cubeFace, i, j] = rotatedFace[i, j];
                }
            }
        }

        private void ApplyRotationOnEdgeFaces(CubeFace cubeFace)
        {
            switch (cubeFace)
            {
                case CubeFace.Front:
                    UpdateFrontFaceEdges();
                    break;
                case CubeFace.Bottom:
                    UpdateBottomEdges();
                    break;
                case CubeFace.Left:
                    UpdateLeftEdges();
                    break;
                case CubeFace.Right:
                    UpdateRightEdges();
                    break;
                case CubeFace.Up:
                    UpdateUpEdges();
                    break;
                case CubeFace.Down:
                    UpdateDownEdges();
                    break;
            }
        }

        private void UpdateFrontFaceEdges()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeDefinition[(int)CubeFace.Up, MatrixSize - 1, i];
                rubikCubeDefinition[(int)CubeFace.Up, MatrixSize - 1, i] = rubikCubeDefinition[(int)CubeFace.Left, MatrixSize - 1 - i, MatrixSize - 1];
                rubikCubeDefinition[(int)CubeFace.Left, MatrixSize - 1 - i, MatrixSize - 1] = rubikCubeDefinition[(int)CubeFace.Down, 0, MatrixSize - 1 - i];
                rubikCubeDefinition[(int)CubeFace.Down, 0, MatrixSize - 1 - i] = rubikCubeDefinition[(int)CubeFace.Right, i, 0];
                rubikCubeDefinition[(int)CubeFace.Right, i, 0] = temp;
            }
        }

        private void UpdateUpEdges()
        {

            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeDefinition[(int)CubeFace.Left, 0, i];
                rubikCubeDefinition[(int)CubeFace.Left, 0, i] = rubikCubeDefinition[(int)CubeFace.Front, 0, i];
                rubikCubeDefinition[(int)CubeFace.Front, 0, i] = rubikCubeDefinition[(int)CubeFace.Right, 0, i];
                rubikCubeDefinition[(int)CubeFace.Right, 0, i] = rubikCubeDefinition[(int)CubeFace.Bottom, 0, i];
                rubikCubeDefinition[(int)CubeFace.Bottom, 0, i] = temp;
            }
        }

        private void UpdateDownEdges()
        {

            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeDefinition[(int)CubeFace.Bottom, MatrixSize - 1, i];
                rubikCubeDefinition[(int)CubeFace.Bottom, MatrixSize - 1, i] = rubikCubeDefinition[(int)CubeFace.Right, MatrixSize - 1, i];
                rubikCubeDefinition[(int)CubeFace.Right, MatrixSize - 1, i] = rubikCubeDefinition[(int)CubeFace.Front, MatrixSize - 1, i];
                rubikCubeDefinition[(int)CubeFace.Front, MatrixSize - 1, i] = rubikCubeDefinition[(int)CubeFace.Left, MatrixSize - 1, i];
                rubikCubeDefinition[(int)CubeFace.Left, MatrixSize - 1, i] = temp;
            }
        }


        private void UpdateBottomEdges()
        {


            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeDefinition[(int)CubeFace.Left, i, 0];
                rubikCubeDefinition[(int)CubeFace.Left, i, 0] = rubikCubeDefinition[(int)CubeFace.Up, 0, MatrixSize - 1 - i];
                rubikCubeDefinition[(int)CubeFace.Up, 0, MatrixSize - 1 - i] = rubikCubeDefinition[(int)CubeFace.Right, MatrixSize - 1 - i, MatrixSize - 1];
                rubikCubeDefinition[(int)CubeFace.Right, MatrixSize - 1 - i, MatrixSize - 1] = rubikCubeDefinition[(int)CubeFace.Down, MatrixSize - 1, i];
                rubikCubeDefinition[(int)CubeFace.Down, MatrixSize - 1, i] = temp;
            }
        }



        private void UpdateLeftEdges()
        {

            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeDefinition[(int)CubeFace.Bottom, i, MatrixSize - 1];
                rubikCubeDefinition[(int)CubeFace.Bottom, i, MatrixSize - 1] = rubikCubeDefinition[(int)CubeFace.Down, MatrixSize - 1 - i, 0];
                rubikCubeDefinition[(int)CubeFace.Down, MatrixSize - 1 - i, 0] = rubikCubeDefinition[(int)CubeFace.Front, MatrixSize - 1 - i, 0];
                rubikCubeDefinition[(int)CubeFace.Front, MatrixSize - 1 - i, 0] = rubikCubeDefinition[(int)CubeFace.Up, MatrixSize - 1 - i, 0];
                rubikCubeDefinition[(int)CubeFace.Up, MatrixSize - 1 - i, 0] = temp;
            }
        }

        private void UpdateRightEdges()
        {


            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeDefinition[(int)CubeFace.Bottom, MatrixSize - 1 - i, 0];
                rubikCubeDefinition[(int)CubeFace.Bottom, MatrixSize - 1 - i, 0] = rubikCubeDefinition[(int)CubeFace.Up, i, MatrixSize - 1];
                rubikCubeDefinition[(int)CubeFace.Up, i, MatrixSize - 1] = rubikCubeDefinition[(int)CubeFace.Front, i, MatrixSize - 1];
                rubikCubeDefinition[(int)CubeFace.Front, i, MatrixSize - 1] = rubikCubeDefinition[(int)CubeFace.Down, i, MatrixSize - 1];
                rubikCubeDefinition[(int)CubeFace.Down, i, MatrixSize - 1] = temp;
            }
        }


        public void PrintRubikCube()
        {
            PrintService.PrintRubikCubeDefinitionAsTable(rubikCubeDefinition, MatrixSize);

        }



    }
}
