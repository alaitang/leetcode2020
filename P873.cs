public class Solution {
    public int LenLongestFibSubseq(int[] A) {
        
        
        var mapping = new Dictionary<int,Dictionary<int,int>>();
        
        var result = 0;
        var len = A.Length;
        
        for(int i = 0;i<len;i++){
            
            
            mapping.Add(A[i],new Dictionary<int,int>());
            for(int j = 0;j<i;j++){
                int n = A[i]+A[j];
                var v = 2;
                if(mapping[A[j]].ContainsKey(A[i]-A[j])){
                    v = mapping[A[j]][A[i]-A[j]]+1;
                }
                
                mapping[A[i]][A[j]] = v;
                
                result = Math.Max(result,v);
            }
        }
        
        //Console.WriteLine(mapping[14][4]);
        
        return result <= 2 ? 0 : result;
    }
}