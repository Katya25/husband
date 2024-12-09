/*
Вот задача, которая может вам понравиться, чтобы подумать:
Задача: Дизайн структуры данных для частотного кэша (LFU Cache)
Вам нужно создать класс LFUCache, который поддерживает следующие операции с временной сложностью O(1):
Get(int key): Если ключ существует, вернуть его значение. Иначе вернуть -1.
Put(int key, int value): Вставить пару ключ-значение. Если кэш уже заполнен (достигнут лимит размера), 
удалить элемент с наименьшей частотой использования (если таких элементов несколько, удалить самый старый).
*/
using System;
using System.Collections.Generic;

public class LFUCache
{
    private class Node
    {
        public int Key;
        public int Value;
        public int Frequency;
        public Node(int key, int value)
        {
            Key = key;
            Value = value;
            Frequency = 1;
        }
    }

    private int _capacity;
    private int _size;
    private Dictionary<int, Node> _cache; // Для хранения ключ-значение
    private Dictionary<int, LinkedList<Node>> _frequencyList; // Для хранения элементов по частоте
    private int _minFrequency; // Для отслеживания минимальной частоты

    public LFUCache(int capacity)
    {
        _capacity = capacity;
        _size = 0;
        _cache = new Dictionary<int, Node>();
        _frequencyList = new Dictionary<int, LinkedList<Node>>();
        _minFrequency = 0;
    }

    public int Get(int key)
    {
        if (!_cache.ContainsKey(key))
            return -1;

        var node = _cache[key];
        // Увеличиваем частоту этого элемента
        IncreaseFrequency(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_capacity == 0)
            return;

        if (_cache.ContainsKey(key))
        {
            var node = _cache[key];
            node.Value = value; // Обновляем значение
            IncreaseFrequency(node); // Увеличиваем частоту
        }
        else
        {
            if (_size == _capacity)
                Evict();

            var newNode = new Node(key, value);
            _cache[key] = newNode;
            if (!_frequencyList.ContainsKey(newNode.Frequency))
                _frequencyList[newNode.Frequency] = new LinkedList<Node>();

            _frequencyList[newNode.Frequency].AddLast(newNode);
            _minFrequency = 1; // Минимальная частота всегда 1, если только что добавили новый элемент
            _size++;
        }
    }

    private void IncreaseFrequency(Node node)
    {
        // Убираем из списка старой частоты
        _frequencyList[node.Frequency].Remove(node);
        if (_frequencyList[node.Frequency].Count == 0)
        {
            _frequencyList.Remove(node.Frequency);
            if (_minFrequency == node.Frequency)
                _minFrequency++;
        }

        // Добавляем в новый список с увеличенной частотой
        node.Frequency++;
        if (!_frequencyList.ContainsKey(node.Frequency))
            _frequencyList[node.Frequency] = new LinkedList<Node>();

        _frequencyList[node.Frequency].AddLast(node);
    }

    private void Evict()
    {
        // Удаляем элемент с минимальной частотой
        var nodeToEvict = _frequencyList[_minFrequency].First.Value;
        _cache.Remove(nodeToEvict.Key);
        _frequencyList[_minFrequency].RemoveFirst();
        if (_frequencyList[_minFrequency].Count == 0)
            _frequencyList.Remove(_minFrequency);

        _size--;
    }
}
