using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikCubeEngine
{
    internal class FaceRotator : IFaceRotator
    {
        public string[,,] RotateFaceClockwise(string[,,] rubikCubeConfigurationState, int matrixSize, CubeFace cubeFace)
        {
            string[,] rotatedFace = new string[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    rotatedFace[i, j] = rubikCubeConfigurationState[(int)cubeFace, matrixSize - 1 - j, i];
                }
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    rubikCubeConfigurationState[(int)cubeFace, i, j] = rotatedFace[i, j];
                }
            }

            return rubikCubeConfigurationState;
        }
    }
}
