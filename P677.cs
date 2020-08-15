public class MapSum {
private TrieNode root = new TrieNode();
    private Dictionary<string,int> mapping = new Dictionary<string,int>();
    /** Initialize your data structure here. */
    public MapSum() {
        
    }
    
    public void Insert(string key, int val) {
        var current = root;
        
        var updateVal = val;
        
        if(mapping.ContainsKey(key)){
           updateVal = val- mapping[key];
        }
        mapping[key] = val;
        root.total+=updateVal;
        
        foreach(var c in key){
            if(current.children[c-'a'] == null)
                current.children[c-'a'] = new TrieNode();
            current = current.children[c-'a'];
            current.total+=updateVal;
        }
    }
    
    public int Sum(string prefix) {
        var current = root;
        
        foreach(var c in prefix){
            if(current.children[c-'a'] == null)
                return 0;
            current = current.children[c-'a'];
        }
        
        return current.total;
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
    public int total = 0;
}

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */