public class Solution {
    public int LongestMountain(int[] A) {
        var len = A.Length;
        
        int up = 0;
        int down = 0;
        var result = 0;
        
        for(int i = 1;i<len;i++){
            if(A[i] > A[i-1]){
                down = 0;
                if(i-1 == 0 || A[i-1] <= A[i-2])
                    up = 0;
                up++;
            }else if(A[i] < A[i-1]){
                down++;
                if(up > 0)
                    result = Math.Max(result,down+up+1);
            }else{
                down = 0;
                up = 0;
            }
        }
        
        return result;
    }
}