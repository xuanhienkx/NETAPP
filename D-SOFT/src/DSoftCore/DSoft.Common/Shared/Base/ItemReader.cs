namespace DSoft.Common.Shared.Base;

public class ItemReader<T>
{
    private readonly IList<T> items;
    private int index;
    public ItemReader(IList<T> items)
    {
        this.items = items;
        this.index = -1;
    }

    public T Current { get; private set; }
    public T Next { get; private set; }

    public bool MoveNext()
    {
        ++index;
        if (index >= items.Count)
        {
            Current = Next = default(T);
            return false;
        }

        Current = items[index];
        Next = index == items.Count - 1 ? default(T) : items[index + 1];
        return true;
    }
}