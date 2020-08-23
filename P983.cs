public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        var len = days.Length;
        var dp = new int[len];
        
        for(int i = 0;i<len;i++){
            
            var index = i;
            var min1 = costs.Min()+ (i == 0? 0 : dp[i-1]);
            var min2 = Math.Min(costs[1],costs[2])+ (i == 0? 0 : dp[i-1]);
            var min3 = costs[2]+ (i == 0? 0 : dp[i-1]);
            
            for(int j = days[i];j< days[i]+30 && index < len;j++){
                if(j == days[index]){
                    
                    var min = j-days[i]+1 <= 1 ? min1 : (j-days[i]+1 <= 7 ? min2 : min3);
                    
                    if(dp[index] == 0 || dp[index] > min){
                        dp[index] = min;
                    }
                    
                    index++;
                }
            }
        }
        
        
        return dp[len-1];
    }
}