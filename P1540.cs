public class Solution {
    public bool CanConvertString(string s, string t, int k) {
        var len = s.Length;
        if(len != t.Length)
            return false;
        
        var dp = new long[26];
        for(int i = 0;i<len;i++){
            int diff = (t[i]-s[i] + 26) % 26;
            
            if(diff == 0)
                continue;
            
            if(diff > k)
                return false;
            
            if(dp[diff] == 0){
                dp[diff] = diff;
            }else if(dp[diff] + 26 <= k){
                dp[diff] += 26;
            }else{
                return false;
            }
        }
        
        return true;
    }
}