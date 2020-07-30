public class Solution {
    public int NumDecodings(string s) {
        var len = s.Length;
        
        if(len == 0 || s[0] == '0')
            return 0;
        
        var p = 1;
        var p1 = 1;
        
        for(int i = 1;i<len && p !=0;i++){
            var nextp = 0;
            var nextp1 = 0;
            
            if(s[i] =='0'){
                nextp1 = 0; 
            }else{
                nextp1 = p;
                nextp = p;
            }
            
            var n = (s[i-1]-'0')*10 + (s[i]-'0');
            if( n >= 1 && n <= 26)
            {
                nextp += p1;
            }
            
            p = nextp;
            p1 = nextp1;
        }
        
        return p;
    }
}