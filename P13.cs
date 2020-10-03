public class Solution {
    public int RomanToInt(string s) {
        var mapping = new Dictionary<char,int>(){
            {'I',1},  
            {'V',5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000}
        };
        
        var result = 0;
        var p = 0;
        
        var len = s.Length;
        
        for(int i = 0;i<len;i++){
            var c = s[i];
            
            result += mapping[c];
            
            if(i-1 >=0 && mapping[c] > mapping[s[i-1]]){
                result -= 2*p;
                p = mapping[c];
            }else if(i-1 >=0 && mapping[c] == mapping[s[i-1]]){
                p += mapping[c];
            }else{
                p = mapping[c];
            }
        }
        
        return result;
    }
}