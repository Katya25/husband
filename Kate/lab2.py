import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.model_selection import train_test_split, cross_val_score
from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import PolynomialFeatures
from sklearn.metrics import mean_squared_error

# 1. Завантаження даних (приклад даних)
data = {
    'distance': [500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000],
    'time': [60, 120, 180, 240, 300, 360, 420, 480, 540, 600]  # Час польоту в хвилинах
}

df = pd.DataFrame(data)

# 2. Розбиття на тренувальну та валідаційну вибірки
X = df['distance'].values.reshape(-1, 1)  # Дистанція
y = df['time'].values  # Час

X_train, X_val, y_train, y_val = train_test_split(X, y, test_size=0.2, random_state=42)

# 3. Навчання лінійної регресії
lin_reg = LinearRegression()
lin_reg.fit(X_train, y_train)

# 4. Оцінка моделі на валідаційній вибірці
y_pred = lin_reg.predict(X_val)
mse_linear = mean_squared_error(y_val, y_pred)

# 5. Крос-валідація для лінійної регресії
cross_val_score_lin = cross_val_score(lin_reg, X, y, cv=3, scoring='neg_mean_squared_error')
mse_cv_linear = -cross_val_score_lin.mean()

# 6. Створення квадратичних та кубічних ознак
poly_2 = PolynomialFeatures(degree=2)
X_poly_2 = poly_2.fit_transform(X)

poly_3 = PolynomialFeatures(degree=3)
X_poly_3 = poly_3.fit_transform(X)

# 7. Моделювання з квадратичною регресією
poly_reg_2 = LinearRegression()
poly_reg_2.fit(X_poly_2, y)

# 8. Моделювання з кубічною регресією
poly_reg_3 = LinearRegression()
poly_reg_3.fit(X_poly_3, y)

# 9. Оцінка квадратичної та кубічної регресії
y_pred_2 = poly_reg_2.predict(poly_2.transform(X_val))
y_pred_3 = poly_reg_3.predict(poly_3.transform(X_val))

mse_poly_2 = mean_squared_error(y_val, y_pred_2)
mse_poly_3 = mean_squared_error(y_val, y_pred_3)

# 10. Крос-валідація для квадратичної та кубічної регресії
cross_val_score_poly_2 = cross_val_score(poly_reg_2, X_poly_2, y, cv=3, scoring='neg_mean_squared_error')
mse_cv_poly_2 = -cross_val_score_poly_2.mean()

cross_val_score_poly_3 = cross_val_score(poly_reg_3, X_poly_3, y, cv=3, scoring='neg_mean_squared_error')
mse_cv_poly_3 = -cross_val_score_poly_3.mean()

# Вивід результатів
print(f"Середньоквадратична помилка лінійної регресії: {mse_linear}")
print(f"Середньоквадратична помилка квадратичної регресії: {mse_poly_2}")
print(f"Середньоквадратична помилка кубічної регресії: {mse_poly_3}")

print(f"Середнє значення крос-валідації для лінійної регресії: {mse_cv_linear}")
print(f"Середнє значення крос-валідації для квадратичної регресії: {mse_cv_poly_2}")
print(f"Середнє значення крос-валідації для кубічної регресії: {mse_cv_poly_3}")

c
