public class Solution {
    public int Candy(int[] ratings) {
        var len = ratings.Length;
        if(len <= 1)
            return len;
        var dp = new int[len];
        dp[0] = 1;
        for(int i = 1;i<len;i++){
            if(ratings[i] > ratings[i-1]){
                dp[i] = dp[i-1]+1;
            }else{
                dp[i] = 1;
            }
        }
        
        var p = 0;
        var result = 0;
        for(int i = len-1;i>=0;i--){
            if(i < len-1 && ratings[i] > ratings[i+1]){
                p++;
            }else{
                p = 1;
            }
            
            result += Math.Max(dp[i],p);
        }
        
        return result;
    }
}