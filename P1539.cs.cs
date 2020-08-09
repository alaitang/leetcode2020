public class Solution {
    public int FindKthPositive(int[] arr, int k) {
        var p = 0;
        var len = arr.Length;
        for(int i=0;i<len && k > 0;i++){
            
            var missed = arr[i] - p - 1;
            
            if(missed < k){
                k-=missed;
            }else{
                break;
            }
            
            p = arr[i];
        }
        
        return p+k;
    }
}