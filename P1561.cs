public class Solution {
    public int MaxCoins(int[] piles) {
        var max = piles.Max();
        var dp = new int[max+1];
        
        foreach(var p in piles)
            dp[p]++;
        
        var len = piles.Length;
        
        var n = len/3;
        
        var result = 0;
        bool f = false;
        for(int i = max;i>=0 && n > 0 ;i--){
            if(dp[i] == 0)
                continue;
            var maxcoise = 0;
            if(f){
                maxcoise = dp[i]/2 + (dp[i] % 2 == 0 ? 0 : 1);
            }else{
                maxcoise = dp[i]/2;
            }
            
            maxcoise = Math.Min(maxcoise,n);
            
            result += maxcoise * i;
            
            n-=maxcoise;
            
            if(dp[i] % 2 == 1)
                f = !f;
        }
        
        return result;
    }
}