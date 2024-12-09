public class Lottery {
    List<string> list;
    Dictionary<string, int> dict;
    Random rnd;
    
    public Lottery() {
        list = new List<string>();
        dict = new Dictionary<string, int>();
        rnd = new Random();
    }
    
    public void Add(string name) {
        if (dict.ContainsKey(name)) {
            Console.WriteLine("User already exists");
        } else {
            list.Add(name);
            int index = list.Count - 1;
            dict.Add(name, index);
        }
    }
    
    public string RandomSelect() {
        if (list.Count == 0) {
            Console.WriteLine("No participants available");
            return null;
        }
        
        int len = list.Count;
        int index = rnd.Next(0, len);
        
        return list[index];
    }
    
    public void DeleteUser(string name) {
        if (dict.ContainsKey(name)) {
            int index = dict[name];
            if (index != list.Count-1) {
                string last = list[list.Count - 1];
                list[index] = last;
                dict[last] = index;
            }
            dict.Remove(name);
            list.RemoveAt(list.Count - 1);
        } else {
            Console.WriteLine("User was not found");
        }
    }
}