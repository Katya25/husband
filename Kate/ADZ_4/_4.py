import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from scipy.stats import ttest_ind

# 1. Завантаження даних
data = pd.read_csv('1.csv')  # Замініть 'your_file.csv' на шлях до вашого файлу

# 2. Відображення перших 5 рядків даних
print(data.head())

# 3. Побудова коробкових діаграм для даних обох варіантів
# Переконаємося, що назви колонок правильні
data.rename(columns={'A': 'variant_A', 'B': 'variant_B'}, inplace=True)

# Побудова діаграм
data.boxplot(column=['variant_A', 'variant_B'])
plt.title("Коробкові діаграми для варіантів A та B")
plt.ylabel("Час перегляду (секунди)")
plt.show()

# Розрахунок середнього та медіани
mean_A = data['variant_A'].mean()
median_A = data['variant_A'].median()
mean_B = data['variant_B'].mean()
median_B = data['variant_B'].median()

print(f"Середнє для варіанту A: {mean_A}, медіана: {median_A}")
print(f"Середнє для варіанту B: {mean_B}, медіана: {median_B}")

# 4. Перестановочний тест
# Об'єднуємо дані обох варіантів
combined = np.concatenate([data['variant_A'], data['variant_B']])

# Різниця середніх у спостережуваних даних
observed_diff = mean_B - mean_A

# Функція для перестановочного тесту
def permutation_test(data_A, data_B, num_permutations=2000):
    combined = np.concatenate([data_A, data_B])
    count = 0
    for _ in range(num_permutations):
        np.random.shuffle(combined)
        perm_A = combined[:len(data_A)]
        perm_B = combined[len(data_A):]
        perm_diff = np.mean(perm_B) - np.mean(perm_A)
        if perm_diff >= observed_diff:
            count += 1
    return count / num_permutations

p_value_permutation = permutation_test(data['variant_A'], data['variant_B'])
print(f"P-значення (перестановочний тест): {p_value_permutation}")

# Висновок за альфа (візьмемо 5% для парних варіантів, як у вашому випадку)
alpha = 0.05
if p_value_permutation < alpha:
    print("Різниця є статистично значущою за перестановочним тестом.")
else:
    print("Різниця не є статистично значущою за перестановочним тестом.")

# 5. t-тест
t_stat, p_value_ttest = ttest_ind(data['variant_A'], data['variant_B'], equal_var=False)
print(f"T-статистика: {t_stat}, P-значення (t-тест): {p_value_ttest}")

if p_value_ttest < alpha:
    print("Різниця є статистично значущою за t-тестом.")
else:
    print("Різниця не є статистично значущою за t-тестом.")

# 6. Висновок
print("\nВИСНОВОК:")
if p_value_permutation < alpha and p_value_ttest < alpha:
    print(f"Різниця між варіантами статистично значуща. Варіант B краще на {((mean_B - mean_A) / mean_A) * 100:.2f}%.")
else:
    print("Різниця між варіантами не є статистично значущою. Висновок колеги-новатора не підтвердився.")
