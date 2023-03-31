using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_1_4
{
    internal class Initialization
    {
        public void InitializationVektor(int x = 3, int randStart = 0, int randEnd = 10)
        {
            int[] shape = new int[] { x };
            Tensor<int> tensor = new Tensor<int>(shape);

            Random rand = new Random();
            for (int i = 0; i < tensor.Shape[0]; ++i)
            {
                tensor[i] = rand.Next(randStart, randEnd);
                Console.Write(tensor[i] + " ");
            }
            Console.WriteLine();
        }

        public void InitializationMatrix(int x = 3, int y = 3, int randStart = 0, int randEnd = 10)
        {
            int[] shape = new int[] { x, y };
            Tensor<int> tensor = new Tensor<int>(shape);

            Random rand = new Random();
            for (int i = 0; i < tensor.Shape[0]; ++i)
            {
                for (int j = 0; j < tensor.Shape[1]; ++j)
                {
                    tensor[i, j] = rand.Next(randStart, randEnd);
                    Console.Write(tensor[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void InitializationTenzor(int x = 3, int y = 3, int z = 3, int randStart = 0, int randEnd = 10)
        {
            int[] shape = new int[] { x, y, z };
            Tensor<int> tensor = new Tensor<int>(shape);

            Random rand = new Random();
            for (int i = 0; i < tensor.Shape[0]; ++i)
            {
                for (int j = 0; j < tensor.Shape[1]; ++j)
                {
                    for (int k = 0; k < tensor.Shape[2]; ++k)
                    {
                        tensor[i, j, k] = rand.Next(randStart, randEnd);
                        Console.Write(tensor[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
