public class Solution {
    public int MaxRepOpt1(string text) {
        var dp2 = new int[26];
        var t = new int[26];
        foreach(var cc in text)
            t[cc-'a']++;
        
        var len = text.Length;
        
        var c = text[0];
        var n = 1;
        var result = 0;
        for(int i = 1;i<len;i++){
            if(c == text[i]){
                n++;
            }else{
                var currentmax = n;
                
                if(i-n-2 >=0 && text[i-n-2] == c){
                    currentmax += dp2[c-'a'];
                }
                
                if(currentmax < t[c-'a'])
                    currentmax++;
                
                result = Math.Max(result,currentmax);
                
                dp2[c-'a'] = n;
                    
                c = text[i];
                n = 1;
            }
            
            if(i == len-1){
                var currentmax = n;

                if(i-n-1 >=0 && text[i-n-1] == c){
                    currentmax += dp2[c-'a'];
                }
                
                if(currentmax < t[c-'a'])
                    currentmax++;

                result = Math.Max(result,currentmax);
            }
        }
        
        return result;
        
    }
}