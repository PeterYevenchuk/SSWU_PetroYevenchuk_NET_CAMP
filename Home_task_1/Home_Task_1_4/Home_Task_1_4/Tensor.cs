using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_1_4
{
    internal class Tensor<T>
    {
        private readonly int[] _shape; // Розмірність тензора
        private readonly T[] _data; // Дані тензора

        public Tensor(params int[] shape)
        {
            _shape = shape;
            _data = new T[GetLength()]; // Створення масиву даних з відповідною кількістю елементів
        }

        public int[] Shape
        {
            get => _shape;
        }

        public T this[params int[] indices] // Індексатор для доступу до елементів тензора за допомогою індексів
        {
            get => _data[GetIndex(indices)];
            set => _data[GetIndex(indices)] = value;
        }

        private int GetIndex(int[] indices) // Метод, який обчислює індекс елемента в масиві даних за допомогою індексів
        {
            if (indices.Length != _shape.Length)
                throw new ArgumentException("Invalid number of indices.");

            int index = 0;
            int stride = 1;
            for (int i = _shape.Length - 1; i >= 0; i--)
            {
                if (indices[i] < 0 || indices[i] >= _shape[i])
                    throw new IndexOutOfRangeException("Index out of range.");

                index += indices[i] * stride;
                stride *= _shape[i];
            }

            return index;
        }

        private int GetLength() // Метод, який обчислює загальну кількість елементів тензора
        {
            int length = 1;
            foreach (int dim in _shape)
                length *= dim;

            return length;
        }
    }
}
