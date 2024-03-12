namespace RubikCubeEngine
{
    internal static class CubeConfiguration
    {
        public static List<(CubeFace face, string color)> GetCubeDefintion()
        {

            var cubeDefintion = new List<(CubeFace face, string color)>() {
                (CubeFace.Front, "Green"),
                (CubeFace.Bottom, "Blue"),
                (CubeFace.Left, "Orange"),
                (CubeFace.Right, "Red"),
                (CubeFace.Up, "White"),
                (CubeFace.Down, "Yellow")
            };

            return cubeDefintion;

        }
    }
}
