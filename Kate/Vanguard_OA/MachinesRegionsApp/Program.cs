using System;
using System.Collections.Generic;
//НЕ РАБОТАЕТ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
class Program
{
    static void Main(string[] args)
    {
        // Входные данные
        List<int> machineCount = new List<int> { 5, 10, 15, 25 };
        List<int> finalMachineCount = new List<int> { 20, 19, 30 };
        int shiftingCost = 5;

        // Шаг 1: Удаляем совпадающие значения
        foreach (int final in finalMachineCount.ToArray())
        {
            if (machineCount.Contains(final))
            {
                machineCount.Remove(final);
                finalMachineCount.Remove(final);
            }
        }

        // Если уже все совпадают, стоимость равна 0
        if (finalMachineCount.Count == 0)
        {
            Console.WriteLine("Minimum Cost: 0");
            return;
        }

        // Шаг 2: Поиск минимальной стоимости
        int minCost = int.MaxValue;
        Solve(0, 0, new List<int>(machineCount), new HashSet<int>());

        // Рекурсивная функция для поиска минимальной стоимости
        void Solve(int currentIndex, int currentCost, List<int> remainingMachines, HashSet<int> usedMachines)
        {
            // Если мы обработали все элементы из finalMachineCount
            if (currentIndex == finalMachineCount.Count)
            {
                minCost = Math.Min(minCost, currentCost);
                return;
            }

            int target = finalMachineCount[currentIndex];

            // Пробуем каждую машину
            for (int i = 0; i < remainingMachines.Count; i++)
            {
                if (usedMachines.Contains(i)) continue;

                int machine = remainingMachines[i];
                int cost = Math.Abs(target - machine); // Стоимость достижения значения target с одной машиной

                // Проверяем, можем ли объединить машины для достижения target
                for (int j = 0; j < remainingMachines.Count; j++)
                {
                    if (i == j || usedMachines.Contains(j)) continue;

                    int secondMachine = remainingMachines[j];
                    if (machine + secondMachine == target)
                    {
                        // Если объединение машин достигает target
                        cost = Math.Min(cost, shiftingCost);
                    }
                }

                // Пробуем этот вариант
                usedMachines.Add(i);
                Solve(currentIndex + 1, currentCost + cost, remainingMachines, usedMachines);
                usedMachines.Remove(i);
            }
        }

        // Вывод результата
        Console.WriteLine($"Minimum Cost: {minCost}");
    }
}
