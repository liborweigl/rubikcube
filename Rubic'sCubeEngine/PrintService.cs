namespace RubikCubeEngine
{
    internal class PrintService : IPrintService
    {
        public void PrintRubikCubeDefinitionAsTable(string[,,] rubikCubeDefinition, int matrixSize)
        {

            foreach (var cubeDefiniton in CubeConfiguration.GetCubeDefintion())
            {
                Console.WriteLine();
                Console.WriteLine($"Table {cubeDefiniton.face.ToString("G")}:");

                for (int j = 0; j < matrixSize; j++)
                {

                    Console.WriteLine();
                    for (int k = 0; k < matrixSize; k++)
                    {
                        var color = rubikCubeDefinition[(int)cubeDefiniton.face, j, k];
                        var temp = Console.BackgroundColor;
                        Console.BackgroundColor = GetColorId(color);
                        Console.Write(rubikCubeDefinition[(int)cubeDefiniton.face, j, k] + "\t");
                        Console.BackgroundColor = temp;

                    }
                }
            }

        }

        private ConsoleColor GetColorId(string color)
        {
 
            return color switch
            {
                "Green" => ConsoleColor.Green,
                "Blue" => ConsoleColor.Blue,
                "Orange" => ConsoleColor.Magenta,
                "Red" => ConsoleColor.Red,
                "White" => ConsoleColor.White,
                "Yellow" => ConsoleColor.Yellow,
                _ => 0,
            };
        }
    }
}