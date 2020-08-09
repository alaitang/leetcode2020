public class Solution {
    public int MinDistance(string word1, string word2) {
        var rows = word1.Length;
        var cols = word2.Length;
        
        var dp = new int[rows+1,cols+1];
        
        for(int i = 1;i<=rows;i++)
            dp[i,0] = i;
        for(int i = 1;i<=cols;i++)
            dp[0,i] = i;
        
        for(int i = 1;i<=rows;i++)
        {
            for(int j = 1;j<=cols;j++){
                dp[i,j] = Math.Min(dp[i-1,j],dp[i,j-1])+1;
                dp[i,j] = Math.Min(dp[i-1,j-1] + (word1[i-1] == word2[j-1] ? 0 : 2), dp[i,j]);
            }
        }
        
        return dp[rows,cols];
    }
}