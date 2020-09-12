public class Solution {
    public int MaxProfit(int[] prices) {
        var result = 0;
        
        var len = prices.Length;
        
        for(int i = 1;i<len;i++){
            result += Math.Max(0,prices[i]-prices[i-1]);
        }
        
        return result;
    }
}