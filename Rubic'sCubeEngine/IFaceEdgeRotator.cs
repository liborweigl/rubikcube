namespace RubikCubeEngine
{
    internal interface IFaceEdgeRotator
    {
        void RotateBottomEdges(string[,,] rubikCubeConfigurationState, int matrixSize);
        void RotateDownEdges(string[,,] rubikCubeConfigurationState, int matrixSize);
        void RotateFrontFaceEdges(string[,,] rubikCubeConfigurationState, int matrixSize);
        void RotateLeftEdges(string[,,] rubikCubeConfigurationState, int matrixSize);
        void RotateRightEdges(string[,,] rubikCubeConfigurationState, int matrixSize);
        void RotateUpEdges(string[,,] rubikCubeConfigurationState, int matrixSize);
    }
}