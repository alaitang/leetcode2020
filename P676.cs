public class MagicDictionary {

    Dictionary<string,string> pool = new Dictionary<string,string>();
    /** Initialize your data structure here. */
    public MagicDictionary() {
        
    }
    
    public void BuildDict(string[] dictionary) {
        foreach(var w in dictionary){
            var arr = w.ToArray();
            
            var len = arr.Length;
            
            var sb = new StringBuilder();
            foreach(var c in w){
                sb.Append(c);
            }
            
            for(int i = 0;i<len;i++){
                var c = w[i];
                
                sb.Replace(c,'*',i,1);
                
                var newstr = sb.ToString();
                
                if(!pool.ContainsKey(newstr))
                    pool[newstr] = w;
                else
                    pool[newstr] = "";
                
                sb.Replace('*',c,i,1);
            }
        }
    }
    
    public bool Search(string searchWord) {
        var arr = searchWord.ToArray();
            
            var len = arr.Length;
        
            var sb = new StringBuilder();
            foreach(var c in searchWord){
                sb.Append(c);
            }
            
            for(int i = 0;i<len;i++){
                var c = searchWord[i];
                
                sb.Replace(c,'*',i,1);
                
                var newstr = sb.ToString();
                
                if(pool.ContainsKey(newstr) && (pool[newstr] != searchWord ))
                {
                    return true;
                }
                
                sb.Replace('*',c,i,1);
            }
        
        return false;
    }
}

/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dictionary);
 * bool param_2 = obj.Search(searchWord);
 */