public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        TrieNode root = new TrieNode();
        
        foreach(var w in wordDict){
            var current = root;
            
            foreach(var c in w){
                if(current.children[c-'a'] == null){
                    current.children[c-'a'] = new TrieNode();
                }
                current = current.children[c-'a'];
            }
            current.isword = true;
        }
        
        return Helper(s,0,new HashSet<int>(),s.Length,root);
        
    }
    
    public bool Helper(string s,int index, HashSet<int> visited,int len,TrieNode root){
        
        if(index >= len)
            return true;
        
        if(!visited.Add(index))
            return false;
        
        var current = root;
        for(int i = index;i<len;i++){
            if(current.children[s[i]-'a'] == null)
                break;
            
            current = current.children[s[i]-'a'];
            
            if(current.isword && Helper(s,i+1,visited,len,root))
                return true;
        }
        
        return false;
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
    public bool isword = false;
}