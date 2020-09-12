public class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        var mapping = new Dictionary<string,int>();
        var result = 0;
        var cols = matrix[0].Length;
        var t = 0;
        foreach(var arr in matrix){
            
            var k = string.Join("",arr);
            if(!mapping.ContainsKey(k))
                mapping[k] = 0;
            mapping[k]++;
            result = Math.Max(result,mapping[k]);
            
            k = string.Join("",arr.Select(x=>x == 0? 1 : 0));
            if(!mapping.ContainsKey(k))
                mapping[k] = 0;
            mapping[k]++;
            
            result = Math.Max(result,mapping[k]);
            
            var sum = arr.Sum();
            
            if(sum == 0 || sum == cols)
                t++;
        }
        
        return Math.Max(t,result);
    }
}