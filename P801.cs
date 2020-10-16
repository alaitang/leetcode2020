public class Solution {
    public int MinSwap(int[] A, int[] B) {
        var len = A.Length;
        
        var n = 0;
        var m = 1;
        
        for(int i = 1;i<len;i++){
            var nextn = int.MaxValue;
            var nextm = int.MaxValue;
            
            if(A[i] > A[i-1] && B[i] > B[i-1]){
                nextn = Math.Min(nextn, n);
                nextm = Math.Min(nextm, m+1);
            }
            
            if(A[i] > B[i-1] && B[i] > A[i-1]){
                nextn = Math.Min(nextn, m);
                nextm = Math.Min(nextm, n+1);
            }
            
            n = nextn;
            m = nextm;
        }
        
        return Math.Min(n,m);
    }
}