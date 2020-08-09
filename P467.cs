public class Solution {
    public int FindSubstringInWraproundString(string p) {
        var low = 0;
        var len = p.Length;
        var result = 0;
        
        var dp = new int[26];
        
        for(int i = 0;i<len;i++){
            if(i == low || p[i]-p[i-1] == 1 || p[i-1] == 'z' && p[i] == 'a'){
                var ll = i-low+1;
                if(ll > dp[p[i]-'a']){
                    result+= ll-dp[p[i]-'a'];
                    dp[p[i]-'a'] = ll;
                }
            }else{
                low = i;
                if(dp[p[i]-'a'] == 0){
                    result++;
                    dp[p[i]-'a'] = 1;
                }
            }
        }
        
        return result;
    }
}