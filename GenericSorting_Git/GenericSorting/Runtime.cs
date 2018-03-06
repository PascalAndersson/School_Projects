using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenericSorting
{
    public class Runtime
    {
        public void Start()
        {
            var fileHandler = new FileHandler();
            //fileHandler.AddListsToFile();

            var integerArrayFromFile = fileHandler.GetIntegerListFromFile();
            var charArrayFromFile = fileHandler.GetCharListFromFile();

            BubbleSort(integerArrayFromFile);
            BubbleSort(charArrayFromFile);

            fileHandler.WriteResultToFile(integerArrayFromFile);
            fileHandler.WriteResultToFile(charArrayFromFile);

            MergeSort(integerArrayFromFile, 0, integerArrayFromFile.Length - 1);
            MergeSort(charArrayFromFile, 0, charArrayFromFile.Length - 1);

            fileHandler.WriteResultToFile(integerArrayFromFile);
            fileHandler.WriteResultToFile(charArrayFromFile);

            QuickSort(integerArrayFromFile, 0, integerArrayFromFile.Length - 1);
            QuickSort(charArrayFromFile, 0, charArrayFromFile.Length - 1);

            fileHandler.WriteResultToFile(integerArrayFromFile);
            fileHandler.WriteResultToFile(charArrayFromFile);
        }

        private void Swap<T>(ref T leftHandSide, ref T rightHandSide)
        {
            T temp = leftHandSide;
            leftHandSide = rightHandSide;
            rightHandSide = temp;
        }

        private void BubbleSort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort].CompareTo(array[sort + 1]) > 0)
                    {
                        Swap(ref array[sort], ref array[sort + 1]);
                    }
                }
            }
        }

        private void MergeSort<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
        }

        private void Merge<T>(T[] array, int low, int middle, int high) where T : IComparable<T>
        {
            int left = low;
            int right = middle + 1;
            T[] tmp = new T[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (array[left].CompareTo(array[right]) < 0)
                {
                    tmp[tmpIndex] = array[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = array[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = array[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = array[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                array[low + i] = tmp[i];
            }
        }

        private void QuickSort<T>(T[] array, int left, int right) where T : IComparable
        {
            int i = left;
            int j = right;

            var pivot = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                //Kommer att byta ut värden i arrayen gentemot pivot-värdet. 
                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);

                    i++;
                    j--;
                }
            }

            //Rekursiva calls för att räkna ut de två staplarna
            if (left < j)
            {
                //Vänsterstapeln
                QuickSort(array, left, j);
            }

            if (i < right)
            {
                //Högerstapeln
                QuickSort(array, i, right);
            }
        }
    }
}
