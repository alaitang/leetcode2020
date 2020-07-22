public class Solution {
    public int MaxProduct(string[] words) {
        var mapping = new Dictionary<int,int>();
        foreach(var w in words){
            var n = 0;
            foreach(var c in w){
                n |= (1 << (c-'a'));
            }
            
            if(!mapping.ContainsKey(n))
                mapping[n] = 0;
            mapping[n] = Math.Max(mapping[n],w.Length);
        }
        var result = 0;
        foreach(var kv1 in mapping)
        {
            foreach(var kv2 in mapping){
                if((kv1.Key & kv2.Key) == 0){
                    result = Math.Max(result,kv1.Value*kv2.Value);
                }
            }
        }
        
        return result;
    }
}