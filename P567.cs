public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var m = new int[26];
        foreach(var c in s1){
            m[c-'a']++;
        }
        
        var len = s1.Length;
        var match = len;
        
        var dp = new int[26];
        
        var len2 = s2.Length;
        
        var currentmatch = 0;
        
        for(int i = 0;i<len2;i++){
            dp[s2[i]-'a']++;
            
            if(dp[s2[i]-'a'] <= m[s2[i]-'a']){
                currentmatch++;
            }
            
            if(i >= len){
                dp[s2[i-len] - 'a']--;
                
                if(dp[s2[i-len] - 'a'] < m[s2[i-len] - 'a']){
                    currentmatch--;
                }
            }
            
            if(i>=len-1 && currentmatch == match)
                return true;
        }
        
        return false;
    }
}


>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var m = new int[26];
        foreach(var c in s1){
            m[c-'a']++;
        }
        
        var len = s1.Length;
        var match = len;
        
        var dp = new int[26];
        
        var len2 = s2.Length;
        
        var currentmatch = 0;
        
        for(int i = 0;i<len2;i++){
            if(++dp[s2[i]-'a'] <= m[s2[i]-'a']){
                currentmatch++;
            }
            
            if(i >= len && --dp[s2[i-len] - 'a'] < m[s2[i-len] - 'a'] ){
                currentmatch--;
            }
            
            if(i>=len-1 && currentmatch == match)
                return true;
        }
        
        return false;
    }
}