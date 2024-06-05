using System;
using System.Collections.Generic;
using System.Linq;
public class PriorityQueue<T>
{
    private SortedDictionary<int, Queue<T>> _dict = new SortedDictionary<int, Queue<T>>();
    public void Enqueue(T item, int priority)
    {
        if (!_dict.ContainsKey(priority))
        {
            _dict.Add(priority, new Queue<T>());
        }

        _dict[priority].Enqueue(item);
    }

    public T Dequeue()
    {
        var item = _dict.First();
        var queue = item.Value;

        var dequeuedItem = queue.Dequeue();
        if (queue.Count == 0)
        {
            _dict.Remove(item.Key);
        }

        return dequeuedItem;
    }

    public bool IsEmpty()
    {
        return _dict.Count == 0;
    }

    public int Count()
    {
        int count = 0;
        foreach (var queue in _dict.Values)
        {
            count += queue.Count;
        }
        return count;
    }
}
