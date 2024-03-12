// See https://aka.ms/new-console-template for more information
using RubikCubeEngine;
 
 

Console.WriteLine("Test sequense: F R' U B' L D'");
var rubicCubeEngine = new RubikCubeEngine.RubikCubeEngine();
rubicCubeEngine.RotateCubeNineteeDegreeClockwise(CubeFace.Front);
rubicCubeEngine.RotateCubeNineteeDegreeAntiClockwise(CubeFace.Right);
rubicCubeEngine.RotateCubeNineteeDegreeClockwise(CubeFace.Up);
rubicCubeEngine.RotateCubeNineteeDegreeAntiClockwise(CubeFace.Bottom);
rubicCubeEngine.RotateCubeNineteeDegreeClockwise(CubeFace.Left);
rubicCubeEngine.RotateCubeNineteeDegreeAntiClockwise(CubeFace.Down);

rubicCubeEngine.PrintRubikCube();

Console.ReadLine();
