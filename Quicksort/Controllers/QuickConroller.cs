using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace QuickSortMVC.Controllers
{
    public class QuickSortController : Controller
    {
        public ActionResult Index()
        {
            // Sample unsorted array
            int[] arr = { 64, 25, 12, 22, 11 };

            QuickSort(arr, 0, arr.Length - 1);

            // Pass the sorted array to the view
            ViewBag.SortedArray = arr;

            return View();
        }

        // QuickSort algorithm
        private void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partition the array and get the number
                int number = Partition(arr, low, high);

                // Recursively sort the elements before and after the number
                QuickSort(arr, low, number - 1);
                QuickSort(arr, number + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                // If the current element is smaller than or equal to the pivot
                if (arr[j] <= pivot)
                {
                    i++;

                    // Swap arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // Swap arr[i+1] and arr[high]
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
    }
}
