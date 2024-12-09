enum Category {electronics, groceries}

/*Вам нужно написать класс InventoryManager, который будет управлять товарами на складе. 
Каждый товар имеет уникальное имя, количество, и категорию (например, "electronics", "groceries").
Класс должен поддерживать следующие функции:
1) Добавление нового товара:
Добавить товар с указанным количеством и категорией. Если товар с таким именем уже существует, 
увеличить его количество.
2) Удаление товара:
Удалить товар полностью с учетом его имени. Если товара нет, ничего не делать.
3) Фильтрация товаров по категории:
Вернуть все товары, относящиеся к заданной категории.
4) Получение общего количества товара:
Вернуть общее количество всех товаров на складе.
5) Поиск товара по имени:
Вернуть информацию о товаре по его имени.
*/
public class Product {
    public string name { get; private set; }
    public int count { get; private set; }
    public Category category {get; private set; }

    public Product (string name, int count, Category category) {
        this.name = name;
        this.count = count;
        this.category = category;
    }

   public void AddCount(int count)
    {
        Count += count;
    }

}
public class InventoryManager {
    public Dictionary<string, Product> productByName;
    public Dictionary<Category, HashSet<Product>> productByCategory;

    public InventoryManager () {
        productByName = new Dictionary<string, Product>();
        productByCategory = new Dictionary<Category, HashSet<Product>>();

        foreach (Category category in Enum.GetValues(typeof(Category))) {
            productByCategory.Add(category, new HashSet<Product>());
        }
    }

    public void AddProduct (string name, int count, Category category) {
        if (!productByName.ContainsKey(name)) {
            Product product = new Product(name, count, category);
            productByName.Add(product);
            productByCategory[category].Add(product);
        } else {
            // Увеличиваем количество
            var existingProduct = productByName[name];
            existingProduct.AddCount(count);
        }
    }

    public bool DeleteProduct(string name) {
        if (productByName.ContainsKey(name)) {
            Product product = productByName[name];
            productByName.Remove(name);
            productByCategory[product.category].Remove(product);
            return true;
        } 
        return false;
    }

    public IEnumerable<Product> ReturnByCategory(Category category) {
        return productByCategory[category];
    }

    public Product FindByName(string name) {
        if (productByName.ContainsKey(name)) {
            return productByName[name];
        }
        throw new KeyNotFoundException($"Product with name '{name}' not found.");
    }

    public int productCountTotal() {
        int count = 0;
        if (productByName.Count < 1) {
            Console.WriteLine("No elements");
            return count;
        } else {
            foreach (Product product in productByName.Values) {
                count += product.count;
            }
            return count;
        }
    }
}