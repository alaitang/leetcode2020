public class Solution {
    public int MaxProfit(int[] prices) {
        
        var buy1 = int.MinValue;
        var sell1 = 0;
        
        var buy2 = int.MinValue;
        var sell2 = 0;
        
        foreach(var p in prices){
            sell2 = Math.Max(sell2,buy2+p);
            
            buy2 = Math.Max(sell1-p,buy2);
            
            sell1 = Math.Max(sell1,buy1+p);
            
            buy1 = Math.Max(buy1,-p);
        }
        
        
        return Math.Max(sell1,sell2);
    }
}