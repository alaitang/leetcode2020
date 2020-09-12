public class Solution {
    public int MaxProfit(int k, int[] prices) {
        
        var len = prices.Length;
        if(k*2 >= len){
            var result = 0;
            for(int i = 1;i<len;i++){
                result += Math.Max(0,prices[i]-prices[i-1]);
            }
            return result;
        }
        
        var selldp = new long[k+1];
        var buydp = new long[k+1];
        
        for(int i = 1;i<=k;i++)
            buydp[i] = int.MinValue;
        
        foreach(var p in prices){
            for(int i = k;i>=1;i--){
                selldp[i] = Math.Max(selldp[i],p+buydp[i]);
                
                buydp[i] = Math.Max(selldp[i-1]-p,buydp[i]);
            }
        }
        
        return (int)selldp.Max();
    }
}