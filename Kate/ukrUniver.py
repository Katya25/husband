import pandas as pd
from sklearn.preprocessing import OrdinalEncoder, OneHotEncoder, LabelEncoder, StandardScaler
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.naive_bayes import GaussianNB
from sklearn.metrics import accuracy_score, classification_report
    
file_path = './1.csv'
data = pd.read_csv(file_path)
    
# Виведення перших рядків оригінального набору даних
print("Оригінальний набір даних (перші 5 рядків):")
print(data.head())
   
# Збереження перших рядків у файл
with open("results.txt", "w") as file:
    file.write("Оригінальний набір даних (перші 5 рядків):\n")
    file.write(data.head().to_string())
    file.write("\n\n")
    
# Визначення унікальних значень для категорійних змінних
categorical_columns = ['Обрамлення', 'Охоронний статус', 'Ступінь небезпеки', 'Матеріал', 'Статус проєкта']
unique_values = {col: data[col].unique() for col in categorical_columns}
      
# Виведення унікальних значень категорійних змінних
print("\nУнікальні значення категорійних змінних:")
for col, values in unique_values.items():
    print(f"{col}: {values}")
      
# Збереження унікальних значень у файл
with open("results.txt", "a") as file:
    file.write("Унікальні значення категорійних змінних:\n")
    for col, values in unique_values.items():
        file.write(f"{col}: {values}\n")
    file.write("\n\n")
      
# Копіювання даних для кодування
data_encoded = data.copy()
      
# Ordinal Encoding для 'Ступінь небезпеки'
ordinal_mapping = {'Безпечний': 0, 'Помірна': 1, 'Висока': 2}
data_encoded['Ступінь небезпеки'] = data_encoded['Ступінь небезпеки'].map(ordinal_mapping)
      
# One-Hot Encoding для інших категорійних змінних
one_hot_columns = ['Обрамлення', 'Охоронний статус', 'Матеріал']
data_encoded = pd.get_dummies(data_encoded, columns=one_hot_columns, drop_first=True)
     
# Виведення перших рядків закодованого набору даних
print("\nДані після кодування (перші 5 рядків):")
print(data_encoded.head())
      
# Збереження закодованих даних у файл
with open("results.txt", "a") as file:
    file.write("Дані після кодування (перші 5 рядків):\n")
    file.write(data_encoded.head().to_string())
    file.write("\n\n")
      
# Кодування цільової змінної 'Статус проєкта'
label_encoder = LabelEncoder()
data_encoded['Статус проєкта'] = label_encoder.fit_transform(data_encoded['Статус проєкта'])
      
# Розділення даних на ознаки (X) та цільову змінну (y)
X = data_encoded.drop('Статус проєкта', axis=1)
y = data_encoded['Статус проєкта']
       
# Масштабування даних
scaler = StandardScaler()
X_scaled = scaler.fit_transform(X)
      
# Розділення на тренувальну та тестову вибірки
X_train, X_test, y_train, y_test = train_test_split(X_scaled, y, test_size=0.2, random_state=42)
       
# Виведення розмірів вибірок
print("\nРозміри вибірок:")
print(f"Тренувальна вибірка: {X_train.shape}")
print(f"Тестова вибірка: {X_test.shape}")
       
# Збереження розмірів вибірок у файл
with open("results.txt", "a") as file:
    file.write("Розміри вибірок:\n")
    file.write(f"Тренувальна вибірка: {X_train.shape}\n")
    file.write(f"Тестова вибірка: {X_test.shape}\n\n")
       
# Логістична регресія
log_reg = LogisticRegression(max_iter=500, solver='saga')  
log_reg.fit(X_train, y_train)
log_reg_predictions = log_reg.predict(X_test)
        
# Оцінка точності логістичної регресії
log_reg_accuracy = accuracy_score(y_test, log_reg_predictions)
print("\nТочність логістичної регресії:", log_reg_accuracy)
       
# Збереження результатів логістичної регресії у файл
with open("results.txt", "a") as file:
    file.write("Точність логістичної регресії:\n")
    file.write(f"{log_reg_accuracy}\n")
    file.write("Класифікаційний звіт для логістичної регресії:\n")
    file.write(classification_report(y_test, log_reg_predictions))
    file.write("\n\n")
        
# Наївний Байєс
nb = GaussianNB()
nb.fit(X_train, y_train)
nb_predictions = nb.predict(X_test)
       
# Оцінка точності наївного Байєса
nb_accuracy = accuracy_score(y_test, nb_predictions)
print("\nТочність наївного Байєса:", nb_accuracy)
       
# Збереження результатів наївного Байєса у файл
with open("results.txt", "a") as file:
    file.write("Точність наївного Байєса:\n")
    file.write(f"{nb_accuracy}\n")
    file.write("Класифікаційний звіт для наївного Байєса:\n")
    file.write(classification_report(y_test, nb_predictions))
    file.write("\n\n")
      
# Вибір найкращої моделі
if log_reg_accuracy > nb_accuracy:
    print("\nНайкраща модель - логістична регресія з точністю:", log_reg_accuracy)
else:
    print("\nНайкраща модель - наївний Байєс з точністю:", nb_accuracy)
      
# Збереження інформації про найкращу модель у файл
with open("results.txt", "a") as file:
    file.write("Найкраща модель:\n")
    if log_reg_accuracy > nb_accuracy:
        file.write(f"Логістична регресія з точністю {log_reg_accuracy}\n")
    else:
        file.write(f"Наївний Байєс з точністю {nb_accuracy}\n")
      