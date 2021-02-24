using System.Xml.Linq;
using System.Collections.Generic;
class LFU<T, F>{
    public int capacity;
    protected int count;

    private int minCount;
    public LFU(int c=16){
        capacity = c;
        count = 0;
        minCount = 0;
        elements = new Dictionary<T, LRU<T, F>>();
        counter = new Dictionary<T, int>();
        chains = new Dictionary<int, LRU<T, F>>();
    }
    protected Dictionary<T, LRU<T, F>> elements;
    protected Dictionary<T, int> counter;
    /* count: LRU */
    protected Dictionary<int, LRU<T, F>> chains;
    

    public void put(T key, F value){
        if (elements.ContainsKey(key)){
            elements[key].put(key, value);
            moveForward(key);
        }
        else
        {
            if (!chains.ContainsKey(1)){
                chains[1] = new LRU<T, F>();
                minCount = 1;
            }
            chains[1].put(key, value);
            elements[key] = chains[1];
            counter[key] = 1;
            count ++;
            while (count > capacity){
                deleteLastOne(); 
                count --;
            }
        }
    }

    public void deleteLastOne(){
        if (minCount == 0){
            return;
        }
        var lru = chains[minCount];
        var node = lru.deleteLastOne();
        elements.Remove(node.key);
        counter.Remove(node.key);
    }

    public F Get(T key){
        if (!elements.ContainsKey(key)){
            return default(F);
        }
        moveForward(key);
        return elements[key].Get(key);
    }

    protected void moveForward(T key){
        var lru = elements[key];
        var value = elements[key].Get(key);
        lru.remove(key);
        if (lru.Count == 0){
            chains.Remove(counter[key]);
            if (counter[key] == minCount){
                minCount ++;
            }
        }
        counter[key] ++;
        if (!chains.ContainsKey(counter[key])){
            chains[counter[key]] = new LRU<T, F>(capacity);
        }
        chains[counter[key]].put(key, value);
        elements[key] = chains[counter[key]];
    }


}