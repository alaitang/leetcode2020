public class WordDictionary {
TrieNode root = new TrieNode();
    /** Initialize your data structure here. */
    public WordDictionary() {
        
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        var current = root;
        foreach(var c in word){
            if(current.children[c-'a'] == null)
                current.children[c-'a'] = new TrieNode();
            
            current = current.children[c-'a'];
        }
        current.isword = true;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return Helper(word,root,0,word.Length);
    }
    
    private bool Helper(string word,TrieNode current, int index,int len){
        for(int i = index;i<len;i++){
            var c = word[i];
            if(c == '.'){
                foreach(var item in current.children){
                    if(item != null && Helper(word,item,i+1,len))
                        return true;
                }
                return false;
            }else if(current.children[c-'a'] == null)
                return false;
            
            current = current.children[c-'a'] ;
        }
        
        return current.isword;
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
    public bool isword=false;
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */