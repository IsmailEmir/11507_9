namespace VariantThree;

public class SimpleStorage<T>
{
    private List<T> _data = new List<T>();
    public void Add(T item) { _data.Add(item); }
    public List<T> FindAll(Func<T, bool> predicate)
    {
        List<T> result = new List<T>();
        foreach (T item in _data)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public int RemoveAll(Func<T, bool> predicate)
    {
        int count = 0;
        for (int i = _data.Count - 1; i >= 0; i--)
        {
            if (predicate(_data[i]))
            {
                _data.RemoveAt(i);
                count++;
            }
        }
        return count;
    }
}
