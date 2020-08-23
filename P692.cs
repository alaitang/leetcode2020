public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        var mapping = new Dictionary<string,int>();
        
        foreach(var w in words){
            if(!mapping.ContainsKey(w))
                mapping[w] = 0;
            mapping[w]++;
        }
        
        var result = new List<string>();
        
        foreach(var kv in mapping){
            var index= result.BinarySearch(kv.Key, Comparer<string>.Create((a,b)=>{
                var r = mapping[b]-mapping[a];
                if(r == 0)
                    r = a.CompareTo(b);
                return r;
            }));
            
            if(index < 0)
                index=~index;
            result.Insert(index,kv.Key);
            
            if(result.Count > k)
                result.RemoveAt(k);
        }
        
        return result;
        
    }
}