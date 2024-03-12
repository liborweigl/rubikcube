using RubikCubeEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubic_sCubeEngine
{
    internal class CubeCreator : ICubeCreator
    {
        public string[,,] Create(int FaceSize = 6, int matrixSize = 3)
        {
            string[,,] rubikCubeDefinition = new string[FaceSize, matrixSize, matrixSize];

            foreach (var cubeSideDefintion in CubeConfiguration.GetCubeDefintion())
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    for (int k = 0; k < matrixSize; k++)
                    {
                        rubikCubeDefinition[(int)cubeSideDefintion.face, j, k] = cubeSideDefintion.color;
                    }
                }

            }

            return rubikCubeDefinition;
        }
    }
}
