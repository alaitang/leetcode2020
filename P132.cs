public class Solution {
    public int MinCut(string s) {
        var len = s.Length;
        var dp = new bool[len,len];
        var r = new int[len];
        
        
        for(int i = 0;i<len;i++)
        {
            r[i] = i;
            for(int j = i;j>=0;j--){
                dp[j,i] = s[i] == s[j] && (i-j <= 2 || dp[j+1,i-1]);
                if(dp[j,i])
                {
                    r[i] = Math.Min( j ==0 ? 0 : (r[j-1]+1),r[i]);
                }
            }
        }
        
        return r[len-1];
    }
}