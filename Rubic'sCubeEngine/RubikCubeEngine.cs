using RubikCubeEngine;

namespace RubikCubeEngine
{
    public class RubikCubeEngine : IRubikCubeEngine
    {

        private string[,,] rubikCubeConfigurationState;
        private const int FaceSize = 6;
        private const int MatrixSize = 3;

        private ICubeCreator CubeCreator;
        private IPrintService PrintService;
        private IFaceEdgeRotator FaceEdgeRotator;
        private IFaceRotator FaceRotator;


        public RubikCubeEngine()
        {
            PrintService = new PrintService();
            CubeCreator = new CubeCreator();
            FaceEdgeRotator = new FaceEdgeRotator();
            FaceRotator = new FaceRotator();

            rubikCubeConfigurationState = CubeCreator.Create();

        }

        public RubikCubeEngine(int matrixSize)
        {
            PrintService = new PrintService();
            CubeCreator = new CubeCreator();
            FaceEdgeRotator = new FaceEdgeRotator();
            FaceRotator = new FaceRotator();

            rubikCubeConfigurationState = CubeCreator.Create(FaceSize, matrixSize);
        }


        public void RotateCubeNineteeDegreeClockwise(CubeFace cubeFace)
        {
            rubikCubeConfigurationState = FaceRotator.RotateFaceClockwise(rubikCubeConfigurationState, MatrixSize, cubeFace);
            ApplyRotationOnFaceEdges(cubeFace);
        }

        public void RotateCubeNineteeDegreeAntiClockwise(CubeFace cubeFace)
        {

            //we can rotate the face 3 times clockwise to achieve anticlockwise rotation
            rubikCubeConfigurationState = FaceRotator.RotateFaceClockwise(rubikCubeConfigurationState, MatrixSize, cubeFace);
            ApplyRotationOnFaceEdges(cubeFace);

            rubikCubeConfigurationState = FaceRotator.RotateFaceClockwise(rubikCubeConfigurationState, MatrixSize, cubeFace);
            ApplyRotationOnFaceEdges(cubeFace);

            rubikCubeConfigurationState = FaceRotator.RotateFaceClockwise(rubikCubeConfigurationState, MatrixSize, cubeFace);
            ApplyRotationOnFaceEdges(cubeFace);
        }

        private void ApplyRotationOnFaceEdges(CubeFace cubeFace)
        {
            switch (cubeFace)
            {
                case CubeFace.Front:
                    FaceEdgeRotator.RotateFrontFaceEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Bottom:
                    FaceEdgeRotator.RotateBottomEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Left:
                    FaceEdgeRotator.RotateLeftEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Right:
                    FaceEdgeRotator.RotateRightEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Up:
                    FaceEdgeRotator.RotateUpEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
                case CubeFace.Down:
                    FaceEdgeRotator.RotateDownEdges(rubikCubeConfigurationState, MatrixSize);
                    break;
            }
        }

        public void PrintRubikCube()
        {
            PrintService.PrintRubikCubeDefinitionAsTable(rubikCubeConfigurationState, MatrixSize);
        }


    }
}
