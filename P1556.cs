public class Solution {
    public string ThousandSeparator(int n) {
        var result = "";
        while(n > 1000 ){
            result = "."+ (n%1000 + "").PadLeft(3,'0') + result;
            n/=1000;
        }
        
        result = n + result;
        
        return result;
        
    }
}