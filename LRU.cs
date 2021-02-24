using System.Collections.Generic;
public class LRU<T, F>{
    int capacity{get;set;}
    LinkedList<T, F> head;
    LinkedList<T, F> end;
    public int Count{ get; set; }
    public LRU(int c=16){
        head = new LinkedList<T, F>();
        end = new LinkedList<T, F>();
        head.next = end;
        end.previous = head;
        capacity = c;
        dic = new Dictionary<T, LinkedList<T, F>>();
        Count = 0;
    }

    public Dictionary<T, LinkedList<T, F>> dic;
    public void moveToHead(LinkedList<T, F> node){
        head.addToLater(node);
    }

    public LinkedList<T, F> deleteLastOne(){
        if (head.next == end){
            return null;
        }
        dic.Remove(end.previous.key);
        var node = end.previous;
        end.previous.remove();
        Count --;
        return node;
    }

    public void remove(T key){
        if (dic.ContainsKey(key)){
            dic[key].remove();
        }
    }

    public void put(T key, F val){
        if (dic.ContainsKey(key)){
            dic[key].value = val;
            dic[key].remove();
            moveToHead(dic[key]);
            return;
        }
        var newNode = new LinkedList<T, F>(key, val);
        moveToHead(newNode);
        dic[key] = newNode;
        Count ++;
        while (Count > capacity){
            deleteLastOne();
        }
    }

    public F Get(T key){
        if (dic.ContainsKey(key)){
            moveToHead(dic[key]);
            return dic[key].value;
        }
        return default(F);
    }
}

public class LinkedList<T, F>{
    public T key{get;set;}
    public F value{get;set;}
    public LinkedList<T, F> next;
    public LinkedList<T, F> previous;
    public LinkedList(T k=default(T), F val=default(F)){
        key = k;
        value = val;
    }

    public void remove(){
        if (previous != null){
            previous.next = null;
        }
        if (next != null){
            next.previous = null;
        }
        if (previous != null && next != null){
            previous.next = next;
            next.previous = previous;
        }
    }

    public void addToFormer(LinkedList<T, F> node){
        node.remove();
        if (previous == null){
            node.next = this;
            previous = node;
        }
        else
        {
            var front = previous;
            front.next = node;
            node.previous = front;
            node.next = this;
            previous = node;
        }
    }

    public void addToLater(LinkedList<T, F> node)
    {
        node.remove();
        if (next == null)
        {
            node.previous = this;
            next = node;
        }
        else
        {
            var behind = next;
            behind.previous = node;
            node.next = behind;
            node.previous = this;
            next = node;
        }
    }
}

