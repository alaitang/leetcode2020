public class Solution {
    public int CountGoodTriplets(int[] arr, int a, int b, int c) {
        var len = arr.Length;
        var result = 0;
        
        for(int k = 2;k<len;k++){
            for(int j = k-1;j>=1;j--){
                for(int i = j-1;i>=0;i--){
                    if(Math.Abs(arr[k]-arr[i]) <= c
                      && Math.Abs(arr[k]-arr[j]) <= b
                      && Math.Abs(arr[j]-arr[i]) <= a){
                        result++;
                    }
                }
            }
        }
        
        return result;
    }
}