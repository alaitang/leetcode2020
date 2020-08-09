public class Solution {
    public int LongestStrChain(string[] words) {
        words = words.OrderBy(x=>x.Length).ToArray();
        var result = 0;
        var mapping = new Dictionary<string,int>();
        foreach(var w in words){
            var m = new int[26];
            foreach(var c in w){
                m[c-'a']++;
            }
            
            var key = string.Join(",",m);
            
            if(mapping.ContainsKey(key))
                continue;
            
            var max = 1;
            
            for(int i = 0;i<26;i++){
                if(m[i] > 0){
                    m[i]--;
                    var newKey = string.Join(",",m);
                    if(mapping.ContainsKey(newKey))
                        max = Math.Max(mapping[newKey]+1,max);
                    m[i]++;
                }
            }
            
            mapping[key] = max;
            
            result = Math.Max(max,result);
        }
        
        return result;
    }
}