using System;
using System.Data;
/*
Условие задачи LeetCode 370: Range Addition:
Вам дан массив длины n, и вы должны выполнить несколько обновлений над этим массивом. Каждый элемент массива изначально равен нулю.
Каждое обновление представлено в виде триплета [startIndex, endIndex, inc], где все элементы массива от startIndex до endIndex (включительно) увеличиваются на значение inc.
Ваша задача — вернуть массив после выполнения всех обновлений.

Input: length = 5, updates = [[1, 3, 2], [2, 4, 3], [0, 2, -2]]
Output: [-2, 0, 3, 5, 3]

Шаги выполнения:
Изначальный массив: [0, 0, 0, 0, 0]

1. После применения обновления [1, 3, 2]: [0, 2, 2, 2, 0]
2. После применения обновления [2, 4, 3]: [0, 2, 5, 5, 3]
3. После применения обновления [0, 2, -2]: [-2, 0, 3, 5, 3]

*/
class Program
{
    public static int[] RangeAddition(int[][] updates, int[] initial) {
        int len = initial.Length;
        int[] dif = new int[len]; // Создаем разностный массив на 1 элемент больше
    
        // Применяем каждое обновление
        foreach (var update in updates) {
            int start = update[0];
            int end = update[1];
            int add = update[2];
    
            dif[start] += add; // Увеличиваем на начальном индексе
            if (end + 1 < len) { // Проверяем границы
                dif[end + 1] -= add; // Уменьшаем на индексе, следующем за конечным
            }
        }
    
        // Применяем накопленные изменения
        for (int i = 1; i < len; i++) {
            dif[i] += dif[i - 1];
        }
    
        // Обновляем начальный массив с учётом изменений
        for (int i = 0; i < len; i++) {
            initial[i] += dif[i];
        }
    
        return initial;
    }

    

    static void Main()
    {
        int[][] updates = new int[][] {
            new int[] { 1, 3, 2 },
            new int[] { 2, 4, 3 },
            new int[] { 0, 2, -2}
        };
        int[] initial = {1, 0, 7, 0, -1};
        int[] res = RangeAddition(updates, initial);

        foreach(int num in res)
        {
            System.Console.Write(num + ", ");
        }
    }
}
