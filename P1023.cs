public class Solution {
    public IList<bool> CamelMatch(string[] queries, string pattern) {
        var result = new List<bool>();
        
        foreach(var w in queries){
            var i = 0;
            var j = 0;
            
            var len1 = w.Length;
            var len2 = pattern.Length;
            var r = true;
            while(i < len1 && r){
                
                if(j < len2 && w[i] == pattern[j]){
                    j++;
                }else if(('A' <= w[i] && w[i] <= 'Z')){
                    r = false;
                }
                
                
                i++;
            }
            
            
            r &= j >= len2;
            
            result.Add(r);
        }
        
        return result;
    }
}