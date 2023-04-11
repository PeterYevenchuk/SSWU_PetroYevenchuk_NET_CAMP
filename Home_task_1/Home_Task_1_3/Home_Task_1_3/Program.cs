using Home_Task_1_3;

class Program
{
    static void Main(string[] args)
    {
        CubeMatrix cubeMatrix = new CubeMatrix();

        int size = 5; // Розмір куба

        int[,,] cube = cubeMatrix.CreateCube(size);

        cubeMatrix.DispayCube(cube, size);

        bool hasCrossLine = cubeMatrix.CheckThroughLinearHoleInCube(cube, size);
        bool hasVerticalLine = cubeMatrix.CheckVerticalLinear(cube, size);
        bool hasHorizontalLine = cubeMatrix.CheckHorizontalLinear(cube, size);

        cubeMatrix.DisplayLinearHoles(cube, size, hasCrossLine, hasVerticalLine, hasHorizontalLine);
    }
}
