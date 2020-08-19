public class Solution {
    public bool CanConstruct(string s, int k) {
        if(s.Length < k)
            return false;
        var dp = new int[26];
        var n = 0;
        foreach(var c in s){
            dp[c-'a'] ^= 1;
            
            if(dp[c-'a'] == 0)
                n--;
            else
                n++;
        }
        
        return n <= k;
    }
}