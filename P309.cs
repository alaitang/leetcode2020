public class Solution {
    public int MaxProfit(int[] prices) {
        
        var len = prices.Length;
        
        if(len <= 1)
            return 0;
        
        var buy = Math.Max(-prices[0],-prices[1]);
        
        var sell1 = 0;
        var sell2 = Math.Max(0,prices[1]-prices[0]);
        
        
        for(int i = 2;i<len;i++){
            
            var currentSell = buy+prices[i];
            
            buy = Math.Max(sell1 - prices[i],buy);
            
            sell1 = Math.Max(sell1,sell2);
            
            sell2 = Math.Max(sell2,currentSell);
            
        }
        
        return Math.Max(sell1,sell2);
    }
}