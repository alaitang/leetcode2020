public class Solution {
    public int MinAddToMakeValid(string S) {
        var n = 0;
        var result = 0;
        foreach(var c in S){
            if(c == '(')
                n++;
            else if(n > 0){
                n--;
            }else{
                result++;
            }
        }
        return result+n;
    }
}