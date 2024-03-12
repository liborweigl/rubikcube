using RubikCubeEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikCubeEngine
{
    internal class FaceEdgeRotatorOperator : IFaceEdgeRotatorOperator
    {
        public void RotateFrontFaceEdges(string[,,] rubikCubeConfigurationState, int matrixSize)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Up, matrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Up, matrixSize - 1, i] = rubikCubeConfigurationState[(int)CubeFace.Left, matrixSize - 1 - i, matrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Left, matrixSize - 1 - i, matrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Down, 0, matrixSize - 1 - i];
                rubikCubeConfigurationState[(int)CubeFace.Down, 0, matrixSize - 1 - i] = rubikCubeConfigurationState[(int)CubeFace.Right, i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Right, i, 0] = temp;
            }
        }

        public void RotateUpEdges(string[,,] rubikCubeConfigurationState, int matrixSize)
        {

            for (int i = 0; i < matrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Left, 0, i];
                rubikCubeConfigurationState[(int)CubeFace.Left, 0, i] = rubikCubeConfigurationState[(int)CubeFace.Front, 0, i];
                rubikCubeConfigurationState[(int)CubeFace.Front, 0, i] = rubikCubeConfigurationState[(int)CubeFace.Right, 0, i];
                rubikCubeConfigurationState[(int)CubeFace.Right, 0, i] = rubikCubeConfigurationState[(int)CubeFace.Bottom, 0, i];
                rubikCubeConfigurationState[(int)CubeFace.Bottom, 0, i] = temp;
            }
        }

        public void RotateDownEdges(string[,,] rubikCubeConfigurationState, int matrixSize)
        {

            for (int i = 0; i < matrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Bottom, matrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Bottom, matrixSize - 1, i] = rubikCubeConfigurationState[(int)CubeFace.Right, matrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Right, matrixSize - 1, i] = rubikCubeConfigurationState[(int)CubeFace.Front, matrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Front, matrixSize - 1, i] = rubikCubeConfigurationState[(int)CubeFace.Left, matrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Left, matrixSize - 1, i] = temp;
            }
        }

        public void RotateBottomEdges(string[,,] rubikCubeConfigurationState, int matrixSize)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Left, i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Left, i, 0] = rubikCubeConfigurationState[(int)CubeFace.Up, 0, matrixSize - 1 - i];
                rubikCubeConfigurationState[(int)CubeFace.Up, 0, matrixSize - 1 - i] = rubikCubeConfigurationState[(int)CubeFace.Right, matrixSize - 1 - i, matrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Right, matrixSize - 1 - i, matrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Down, matrixSize - 1, i];
                rubikCubeConfigurationState[(int)CubeFace.Down, matrixSize - 1, i] = temp;
            }
        }

        public void RotateLeftEdges(string[,,] rubikCubeConfigurationState, int matrixSize)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Bottom, i, matrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Bottom, i, matrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Down, matrixSize - 1 - i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Down, matrixSize - 1 - i, 0] = rubikCubeConfigurationState[(int)CubeFace.Front, matrixSize - 1 - i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Front, matrixSize - 1 - i, 0] = rubikCubeConfigurationState[(int)CubeFace.Up, matrixSize - 1 - i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Up, matrixSize - 1 - i, 0] = temp;
            }
        }

        public void RotateRightEdges(string[,,] rubikCubeConfigurationState, int matrixSize)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                var temp = rubikCubeConfigurationState[(int)CubeFace.Bottom, matrixSize - 1 - i, 0];
                rubikCubeConfigurationState[(int)CubeFace.Bottom, matrixSize - 1 - i, 0] = rubikCubeConfigurationState[(int)CubeFace.Up, i, matrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Up, i, matrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Front, i, matrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Front, i, matrixSize - 1] = rubikCubeConfigurationState[(int)CubeFace.Down, i, matrixSize - 1];
                rubikCubeConfigurationState[(int)CubeFace.Down, i, matrixSize - 1] = temp;
            }
        }

    }
}
