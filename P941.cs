public class Solution {
    public bool ValidMountainArray(int[] A) {
        var len = A.Length;
        
        var increase = true;
        
        for(int i = 1;i<len;i++){
            if(increase){
                if(A[i] < A[i-1]){
                    if(i == 1)
                        return false;
                    increase = false;
                }else if(A[i] == A[i-1]){
                    return false;
                }
            }else if(A[i] >= A[i-1])
                return false;
        }
        
        return increase == false;
    }
}