public class Solution {
    public int MinInsertions(string s) {
        var m = 0;
        var result = 0;
        var len = s.Length;
        
        for(int i = 0;i<len;i++){
            if(s[i] == '('){
                m+=2;
            }else if(i+1 < len && s[i+1] == ')'){
                i++;
                if(m > 0)
                    m-=2;
                else
                    result++;
            }else if(m > 0){
                result++;
                m-=2;
            }else{
                result += 2;
            }
        }
        
        return result + m;
        
    }
}