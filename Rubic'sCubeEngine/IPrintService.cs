namespace RubikCubeEngine
{
    internal interface IPrintService
    {
        void PrintRubikCubeDefinitionAsTable(string[,,] rubikCubeDefinition, int matrixSize);
    }
}