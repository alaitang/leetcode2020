public class Solution {
    public int FindLatestStep(int[] arr, int m) {
        var n = arr.Length;
        var dp = new int[n+2];
        var result = -1;
        var k = 0;
        for(int i = 0;i<n;i++){
            var left = arr[i];
            var right = arr[i];
            
            if(dp[left-1] != 0){
                if(left-1-dp[left-1]+1 == m)
                    k--;
                left = dp[left-1];
            }
            
            if(dp[right+1] != 0 ){
                if(dp[right+1]-(right+1)+1 == m)
                    k--;
                right = dp[right+1];
            }
            
            dp[left] = right;
            dp[right] = left;
            
            if(right-left+1 == m)
                k++;
            
            
            //Console.WriteLine($"{left} , {right} ,{k}");
            
            if(k > 0)
                result = i+1;
        }
        
        return result;
        
        
    }
}