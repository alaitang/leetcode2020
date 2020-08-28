public class Solution {
    public int LongestOnes(int[] A, int K) {
        var low = 0;
        var len = A.Length;
        var m = 0;
        var result = 0;
        for(int i = 0;i<len;i++){
            if(A[i] == 0){
                m++;
            }
            
            while(m > K){
                if(A[low] == 0){
                    m--;
                }
                low++;
            }
            
            result = Math.Max(result,i-low+1);
        }
        
        return result;
    }
}