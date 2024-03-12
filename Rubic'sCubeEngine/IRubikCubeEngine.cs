namespace RubikCubeEngine
{
    public interface IRubikCubeEngine
    {
        void PrintRubikCube();
        void RotateCubeNineteeDegreeAntiClockwise(CubeFace cubeFace);
        void RotateCubeNineteeDegreeClockwise(CubeFace cubeFace);
    }
}