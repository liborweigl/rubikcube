﻿namespace RubikCubeEngine
{
    internal interface ICubeCreator
    {
        string[,,] Create(int FaceSize = 6, int matrixSize = 3);
    }
}