using Rubic_sCubeEngine;

namespace RubikCubeEngine
{
    public class RubikCubeEngine : IRubikCubeEngine
    {

        private string[,,] rubikCubeConfigurationState;
        private const int FaceSize = 6;
        private const int MatrixSize = 3;

        private ICubeCreator CubeCreator;
        private IPrintService PrintService;


        public RubikCubeEngine()
        {
            PrintService = new PrintService();
            CubeCreator = new CubeCreator();

            rubikCubeConfigurationState = CubeCreator.Create();

        }

        public RubikCubeEngine(int matrixSize)
        {
            PrintService = new PrintService();
            CubeCreator = new CubeCreator();

            rubikCubeConfigurationState = CubeCreator.Create(FaceSize, matrixSize);
        }


        public void RotateCubeNineteeDegreeClockwise(CubeFace cubeFace)
        {
            RotateFaceClockwise(cubeFace);
            ApplyRotationOnFaceEdges(cubeFace);

        }


        public void RotateCubeNineteeDegreeAntiClockwise(CubeFace cubeFace)
        {

            //we can rotate the face 3 times clockwise to achieve anticlockwise rotation
            RotateFaceClockwise(cubeFace);
            ApplyRotationOnFaceEdges(cubeFace);

            RotateFaceClockwise(cubeFace);
            ApplyRotationOnFaceEdges(cubeFace);

            RotateFaceClockwise(cubeFace);
            ApplyRotationOnFaceEdges(cubeFace);

        }

        private void RotateFaceClockwise(CubeFace cubeFace)
        {
            string[,] rotatedFace = new string[MatrixSize, MatrixSize];

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    rotatedFace[i, j] = rubikCubeConfigurationState[(int)cubeFace, MatrixSize - 1 - j, i];
                }
            }

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    rubikCubeConfigurationState[(int)cubeFace, i, j] = rotatedFace[i, j];
                }
            }
        }

        private void ApplyRotationOnFaceEdges(CubeFace cubeFace)
        {
            switch (cubeFace)
            {
                case CubeFace.Front:
                    RotateFrontFaceEdges();
                    break;
                case CubeFace.Bottom:
                    RotateBottomEdges();
                    break;
                case CubeFace.Left:
                    RotateLeftEdges();
                    break;
                case CubeFace.Right:
                    RotateRightEdges();
                    break;
                case CubeFace.Up:
                    RotateUpEdges();
                    break;
                case CubeFace.Down:
                    RotateDownEdges();
                    break;
            }
        }

        private void RotateFrontFaceEdges()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Up, MatrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Up, MatrixSize - 1, i] = rubikCubeConfigurationState[(int)CubeFace.Left, MatrixSize - 1 - i, MatrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Left, MatrixSize - 1 - i, MatrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Down, 0, MatrixSize - 1 - i];
                rubikCubeConfigurationState[(int)CubeFace.Down, 0, MatrixSize - 1 - i] = rubikCubeConfigurationState[(int)CubeFace.Right, i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Right, i, 0] = temp;
            }
        }

        private void RotateUpEdges()
        {

            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Left, 0, i];
                rubikCubeConfigurationState[(int)CubeFace.Left, 0, i] = rubikCubeConfigurationState[(int)CubeFace.Front, 0, i];
                rubikCubeConfigurationState[(int)CubeFace.Front, 0, i] = rubikCubeConfigurationState[(int)CubeFace.Right, 0, i];
                rubikCubeConfigurationState[(int)CubeFace.Right, 0, i] = rubikCubeConfigurationState[(int)CubeFace.Bottom, 0, i];
                rubikCubeConfigurationState[(int)CubeFace.Bottom, 0, i] = temp;
            }
        }

        private void RotateDownEdges()
        {

            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Bottom, MatrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Bottom, MatrixSize - 1, i] = rubikCubeConfigurationState[(int)CubeFace.Right, MatrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Right, MatrixSize - 1, i] = rubikCubeConfigurationState[(int)CubeFace.Front, MatrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Front, MatrixSize - 1, i] = rubikCubeConfigurationState[(int)CubeFace.Left, MatrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Left, MatrixSize - 1, i] = temp;
            }
        }

        private void RotateBottomEdges()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Left, i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Left, i, 0] = rubikCubeConfigurationState[(int)CubeFace.Up, 0, MatrixSize - 1 - i];
                rubikCubeConfigurationState[(int)CubeFace.Up, 0, MatrixSize - 1 - i] = rubikCubeConfigurationState[(int)CubeFace.Right, MatrixSize - 1 - i, MatrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Right, MatrixSize - 1 - i, MatrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Down, MatrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Down, MatrixSize - 1, i] = temp;
            }
        }

        private void RotateLeftEdges()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Bottom, i, MatrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Bottom, i, MatrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Down, MatrixSize - 1 - i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Down, MatrixSize - 1 - i, 0] = rubikCubeConfigurationState[(int)CubeFace.Front, MatrixSize - 1 - i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Front, MatrixSize - 1 - i, 0] = rubikCubeConfigurationState[(int)CubeFace.Up, MatrixSize - 1 - i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Up, MatrixSize - 1 - i, 0] = temp;
            }
        }

        private void RotateRightEdges()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Bottom, MatrixSize - 1 - i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Bottom, MatrixSize - 1 - i, 0] = rubikCubeConfigurationState[(int)CubeFace.Up, i, MatrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Up, i, MatrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Front, i, MatrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Front, i, MatrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Down, i, MatrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Down, i, MatrixSize - 1] = temp;
            }
        }


        public void PrintRubikCube()
        {
            PrintService.PrintRubikCubeDefinitionAsTable(rubikCubeConfigurationState, MatrixSize);

        }



    }
}
