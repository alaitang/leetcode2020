public class Solution {
    public int MinCost(int n, int[] cuts) {
        var list = cuts.ToList();
        list.Add(n);
        list.Add(0);
        cuts = list.OrderBy(x=>x).ToArray();
        var len = cuts.Length;
        
        var dp = new int[len,len];
        
        for(int i = 0;i<len;i++)
        {
            for(int j = i-2;j>=0;j--)
            {
                dp[j,i] = int.MaxValue;
                for(int k = j+1;k < i;k++){
                    
                    dp[j,i] = Math.Min(dp[j,i], dp[j,k] + dp[k,i] + cuts[i]-cuts[j]);
                }
            }
        }
        
        return dp[0,len-1];
    }
}