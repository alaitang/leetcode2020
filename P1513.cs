public class Solution {
    public int NumSub(string s) {
        var low = -1;
        
        var len = s.Length;
        long result = 0;
        for(int i = 0;i<len;i++){
            if(s[i] == '0'){
                low = i;
            }else{
                result += i-low;
                result %= 1000000007;
            }
        }
        return (int)result;
    }
}