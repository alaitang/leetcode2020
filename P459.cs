public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        var len = s.Length;
        
        for(int i = 1;i<len;i++)
        {
            var v = true;
            for(int j = i;len % i == 0 && v && j<len;j++){
                v &= s[j] == s[j%i];
            }
            
            if(len % i == 0 && v){
                //Console.WriteLine(i);
                return true;
            }
        }
        return false;
    }
}