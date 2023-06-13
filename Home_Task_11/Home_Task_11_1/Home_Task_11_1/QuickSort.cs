namespace Home_Task_11_1;

public class QuickSort<T>
{
    private static Random _random = new Random();

    public static void Sort(T[] array, Comparison<T> comparison, int pivotChoice)
    {
        CustomSort(array, 0, array.Length - 1, comparison, pivotChoice);
    }

    private static void CustomSort(T[] array, int left, int right, Comparison<T> comparison, int pivotChoice)
    {
        if (left < right)
        {
            int pivotIndex;

            switch (pivotChoice)
            {
                case 1:
                    pivotIndex = left;
                    break;
                case 2:
                    pivotIndex = _random.Next(left, right + 1);
                    break;
                case 3:
                    pivotIndex = (left + right) / 2;
                    break;
                default:
                    pivotIndex = left;
                    break;
            }

            T pivotValue = array[pivotIndex];
            Swap(array, pivotIndex, right);

            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (comparison(array[i], pivotValue) <= 0)
                {
                    Swap(array, i, storeIndex);
                    storeIndex++;
                }
            }

            Swap(array, storeIndex, right);

            CustomSort(array, left, storeIndex - 1, comparison, pivotChoice);
            CustomSort(array, storeIndex + 1, right, comparison, pivotChoice);
        }
    }

    private static void Swap(T[] array, int i, int j)
    {
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

