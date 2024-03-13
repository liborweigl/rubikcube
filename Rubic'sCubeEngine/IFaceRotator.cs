namespace RubikCubeEngine
{
    internal interface IFaceRotator
    {
        string[,,] RotateFaceClockwise(string[,,] rubikCubeConfigurationState, int matrixSize, CubeFace cubeFace);
    }
}