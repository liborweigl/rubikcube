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
        private IFaceEdgeRotatorOperator FaceEdgeRotatorOperator;


        public RubikCubeEngine()
        {
            PrintService = new PrintService();
            CubeCreator = new CubeCreator();
            FaceEdgeRotatorOperator = new FaceEdgeRotatorOperator();

            rubikCubeConfigurationState = CubeCreator.Create();

        }

        public RubikCubeEngine(int matrixSize)
        {
            PrintService = new PrintService();
            CubeCreator = new CubeCreator();
            FaceEdgeRotatorOperator = new FaceEdgeRotatorOperator();

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
                    FaceEdgeRotatorOperator.RotateFrontFaceEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Bottom:
                    FaceEdgeRotatorOperator.RotateBottomEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Left:
                    FaceEdgeRotatorOperator.RotateLeftEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Right:
                    FaceEdgeRotatorOperator.RotateRightEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Up:
                    FaceEdgeRotatorOperator.RotateUpEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Down:
                    FaceEdgeRotatorOperator.RotateDownEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
            }
        }


        public void PrintRubikCube()
        {
            PrintService.PrintRubikCubeDefinitionAsTable(rubikCubeConfigurationState, MatrixSize);
        }


    }
}
