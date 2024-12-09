import pandas as pd
    
file_path = './1.csv'
data = pd.read_csv(file_path)
data.head()

     
categorical_columns = ['Обрамлення', 'Охоронний статус', 'Ступінь небезпеки', 'Матеріал', 'Статус проєкта']
unique_values = {col: data[col].unique() for col in categorical_columns}
unique_values
    

# Ordinal encoding для 'Ступінь небезпеки'
ordinal_mapping = {'Безпечний': 0, 'Помірна': 1, 'Висока': 2}
data_encoded['Ступінь небезпеки'] = data_encoded['Ступінь небезпеки'].map(ordinal_mapping)
      
# One-Hot Encoding для інших змінних
one_hot_columns = ['Обрамлення', 'Охоронний статус', 'Матеріал']
data_encoded = pd.get_dummies(data_encoded, columns=one_hot_columns, drop_first=True)



from sklearn.model_selection import train_test_split
    
X = data_encoded.drop('Статус проєкта', axis=1)
y = data_encoded['Статус проєкта']
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)


from sklearn.linear_model import LogisticRegression
from sklearn.naive_bayes import GaussianNB
from sklearn.metrics import accuracy_score
    
# Логістична регресія
log_reg = LogisticRegression()
log_reg.fit(X_train, y_train)
log_reg_predictions = log_reg.predict(X_test)
log_reg_accuracy = accuracy_score(y_test, log_reg_predictions)
    
# Наївний Баєс
nb = GaussianNB()
nb.fit(X_train, y_train)
nb_predictions = nb.predict(X_test)
nb_accuracy = accuracy_score(y_test, nb_predictions)
    
log_reg_accuracy, nb_accuracy