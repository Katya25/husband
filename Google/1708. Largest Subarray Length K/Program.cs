using System;
/*
Вам дан массив целых чисел nums и целое число k. Ваша задача — найти подмассив длины k, который является наибольшим в лексикографическом порядке среди всех возможных подмассивов длины k.
Определение:
Подмассив считается больше другого, если на первом элементе, где они различаются, элемент первого подмассива больше, чем элемент второго.
Входные данные:
Массив nums состоит из целых чисел.
k — длина подмассива, которую нужно найти.

Input: nums = [1, 4, 5, 2, 3], k = 3
Output: [5, 2, 3]

Input: nums = [9, 8, 7, 6, 5], k = 2
Output: [9, 8]

Input: nums = [3, 1, 5, 6, 2], k = 1
Output: [6]
*/
class Program
{
    public static int[] LargestSub(int[] nums, int k) {
        int maxIndex = 0;
        
        for(int i = 1; i < nums.Length-k; i++)
        {
            if(nums[i] > nums[maxIndex])
            {
                maxIndex = i;
            }
            else if(nums[i] == nums[maxIndex])
            {
                for(int j = 1; j < k; j++)
                {
                    if(nums[i+j] > nums[maxIndex + j])
                    {
                        maxIndex = i;
                    }
                    else if(nums[i+j] > nums[maxIndex + j]) break;
                }
            }
        }

        int[] res = new int[k];

        for(int i = 0; i < k; i++)
        {
            res[i] = nums[maxIndex+i];
        }

        return res;
    }
    static void Main()
    {
        int[] nums = {0, 0, 0, 0, 0}; 
        int k = 2;
        int[] res = LargestSub(nums, k);

        foreach(int num in res)
        {
            System.Console.Write(num + ", ");
        }
    }
}
