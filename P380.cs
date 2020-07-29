public class RandomizedSet {

    private List<int> list = new List<int>();
    private Dictionary<int,int> mapping = new Dictionary<int,int>();
    private Random rand = new Random();
    
    /** Initialize your data structure here. */
    public RandomizedSet() {
        
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(mapping.ContainsKey(val))
            return false;
        list.Add(val);
        mapping.Add(val,list.Count-1);
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!mapping.ContainsKey(val))
            return false;
        
        var index = mapping[val];
        
        if(index != list.Count-1){
            list[index] = list.Last();
            mapping[list.Last()] = index;
        }
        
        list.RemoveAt(list.Count-1);
        mapping.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        return list.Any() ? list[rand.Next(list.Count)] : -1;
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */