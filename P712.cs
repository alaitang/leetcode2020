public class Solution {
    public int MinimumDeleteSum(string s1, string s2) {
        var len1 = s1.Length;
        
        var len2 = s2.Length;
        
        var dp = new int[len1+1,len2+1];
        
        for(int i = 1;i<=len1;i++)
        {
            dp[i,0] = dp[i-1,0] + (int)s1[i-1];
        }
        
        for(int i = 1;i<=len2;i++)
        {
            dp[0,i] = dp[0,i-1] + (int)s2[i-1];
        }
        
        for(int i = 1;i<=len1;i++)
        {
            for(int j = 1;j<=len2;j++)
            {
                dp[i,j] = Math.Min(dp[i,j-1]+(int)s2[j-1],dp[i-1,j]+(int)s1[i-1]);
                
                
                dp[i,j] = Math.Min(dp[i,j],dp[i-1,j-1] + (s1[i-1] == s2[j-1] ? 0 : ((int)s1[i-1]+ (int)s2[j-1])));
            }
        }
        
        //Console.WriteLine(dp[2,3]);
        
        return dp[len1,len2];
    }
}