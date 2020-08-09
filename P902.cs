public class Solution {
    public int AtMostNGivenDigitSet(string[] D, int N) {
        var result = 0;
        var s = N+"";
        var len = s.Length;
        
        var dp = new int[len];
        dp[0] = 1;
        var dlen = D.Length;
        for(int i=1;i<=len-1;i++){
            dp[i] = dp[i-1] * dlen;
            result += dp[i];
        }
        
        var kmatch = 0;
        for(int i = 0;i<len;i++){
            if(s[i] < D[0][0])
                break;
            bool hasmatch = false;
            for(int j = 0;j<dlen;j++){
                if(s[i] > D[j][0]){
                    result += dp[len-i-1];
                }else if(s[i] == D[j][0]){
                    hasmatch = true;
                    kmatch++;
                    break;
                }
            }
            
            if(!hasmatch)
                break;
        }
        
        return result + (kmatch == len ? 1 : 0);
    }
}