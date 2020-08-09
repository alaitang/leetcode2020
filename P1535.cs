public class Solution {
    public int GetWinner(int[] arr, int k) {
        var len = arr.Length;
        
        var max = arr[0];
        var t = 0;
        for(int i = 1;i<len && t < k;i++){
            if(arr[i] > max){
                t = 1;
                max = arr[i];
            }else{
                t++;
            }
        }
        
        return max;
        
    }
}