public class Solution {
    public int MinimumLengthEncoding(string[] words) {
        var result = 0;
        //words = words.OrderBy(x=>-x.Length).ToArray();
        var root = new TrieNode();
        foreach(var w in words){
            var current = root;
            
            TrieNode newNode = null;
            var k = 0;
            for(int i = w.Length-1;i>=0;i--){
                var c = w[i];
                
                if(current.children[c-'a'] == null)
                {
                    if(newNode == null)
                        newNode = current;
                    current.children[c-'a'] = new TrieNode();
                    k++;
                }
                
                current = current.children[c-'a'];
            }
            current.isword = true;
            
            if(newNode != null){
                if(newNode.isword){
                    result += k;
                    newNode.isword = false;
                }else{
                    result += w.Length+1;
                }
            }else{
                current.isword = false;
            }
        }
        
        return result;
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
    public bool isword = false;
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public int MinimumLengthEncoding(string[] words) {
        var result = 0;
        words = words.OrderBy(x=>-x.Length).ToArray();
        var root = new TrieNode();
        foreach(var w in words){
            var current = root;
            var newNode = false;
            for(int i = w.Length-1;i>=0;i--){
                var c = w[i];
                
                if(current.children[c-'a'] == null)
                {
                    current.children[c-'a'] = new TrieNode();
                    newNode = true;
                }
                
                current = current.children[c-'a'];
            }
            
            if(newNode)
                result += w.Length+1;
        }
        
        return result;
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
}