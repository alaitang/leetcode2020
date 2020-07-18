public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var root = new TrieNode();
        
        var current = root;
        foreach(var item in products){
            current = root;
            foreach(var c in item){
                if(current.children[c-'a'] == null)
                    current.children[c-'a'] = new TrieNode();
                current = current.children[c-'a'];
                Helper(current.words, item);
            }
        }
        
        var result = new List<IList<string>>();
        
        current = root;
        foreach(var c in searchWord){
            
            if(current != null)
                current = current.children[c-'a'];
            
            if(current != null)
                result.Add(current.words);
            else
                result.Add(new List<string>());
        }
        
        return result;
    }
    
    private void Helper(List<string> list,string item){
        if(list.Count >= 1 && item.CompareTo(list[0]) < 0)
            list.Insert(0,item);
        else if(list.Count >= 2 && item.CompareTo(list[1]) < 0)
            list.Insert(1,item);
        else if(list.Count >= 3 && item.CompareTo(list[2]) < 0)
            list.Insert(2,item);
        else{
            list.Add(item);
        }
        
        if(list.Count > 3)
            list.RemoveAt(3);
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
    public List<string> words = new List<string>();
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var result = new List<IList<string>>();
        
        var len = searchWord.Length;
        
        for(int i = 0;i<len;i++){
            result.Add(new List<string>());
        }
        
        foreach(var p in products){
            for(int i = 0;i<p.Length && i < len;i++){
                var c = p[i];
                
                if(searchWord[i] == c){
                    Helper(result[i],p);
                }else{
                    break;
                }
            }
        }
        
        return result;
    }
    
    private void Helper(IList<string> list,string item){
        if(list.Count >= 1 && item.CompareTo(list[0]) < 0)
            list.Insert(0,item);
        else if(list.Count >= 2 && item.CompareTo(list[1]) < 0)
            list.Insert(1,item);
        else if(list.Count >= 3 && item.CompareTo(list[2]) < 0)
            list.Insert(2,item);
        else{
            list.Add(item);
        }
        
        if(list.Count > 3)
            list.RemoveAt(3);
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
    public List<string> words = new List<string>();
}