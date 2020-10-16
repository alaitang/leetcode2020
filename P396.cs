public class Solution {
    public int MaxRotateFunction(int[] A) {
        var current = 0;
        var len = A.Length;
        var sum = 0;
        for(int i = 0;i<len;i++){
            current += A[i] * i;
            sum += A[i];
        }
        
        var result = current;
        
        for(int i = len-1;i>=1;i--){
            current = current - (len-1) * A[i] + sum - A[i];
            result = Math.Max(result,current);
        }
        
        return result;
        
        
    }
}