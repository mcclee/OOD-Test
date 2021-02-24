public class LRUCache : LRU<int, int>
{

    public LRUCache(int capacity) : base(capacity)
    {

    }

    new public int Get(int key)
    {
        if (dic.ContainsKey(key))
        {
            moveToHead(dic[key]);
            return dic[key].value;
        }
        return -1;
    }
}