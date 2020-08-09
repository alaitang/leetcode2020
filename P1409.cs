public class Solution {
    public int[] ProcessQueries(int[] queries, int m) {
        
        var len = queries.Length;
        var result = new int[len];
        
        for(int i = 0;i<len;i++){
            var v = new HashSet<int>();
            var lv = new HashSet<int>();
            var j = i-1;
            for(;j>=0;j--){
                if(queries[j] == queries[i])
                    break;
                v.Add(queries[j]);
                if(queries[j] > queries[i])
                    lv.Add(queries[j]);
            }
            
            if(j >= 0){
                result[i] = v.Count;
            }else{
                result[i] = queries[i]-1+lv.Count;
            }
        }
        
        return result;
        
        
    }
}