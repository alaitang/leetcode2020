public class Solution {
    public bool CheckValidString(string s) {
        var min = 0;
        var max = 0;
        
        foreach(var c in s){
            if(c == '('){
                min++;
                max++;
            }else if(c == ')'){
                max--;
                min--;
            }else{
                max++;
                min--;
            }
            
            
            if(min < 0)
                min = 0;
            
            if(max < 0)
                return false;
        }
        
        return min == 0;
    }
}