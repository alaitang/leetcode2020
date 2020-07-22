public class Solution {
    public string AlphabetBoardPath(string target) {
        var p = 'a';
        
        var sb = new StringBuilder();
        
        foreach(var c in target){
            var pi = (p-'a')/5;
            var pj = (p-'a')%5;
            
            
            var ci = (c-'a')/5;
            var cj = (c-'a')%5;
            
            
            if(c == 'z'){
                sb.Append("".PadRight( Math.Abs(cj-pj) , (cj > pj ? 'R' : 'L' ) ));
                sb.Append("".PadRight( Math.Abs(ci-pi), (ci > pi ? 'D' : 'U' ) ));
            }else{
                sb.Append("".PadRight( Math.Abs(ci-pi), (ci > pi ? 'D' : 'U' ) ));
                sb.Append("".PadRight( Math.Abs(cj-pj) , (cj > pj ? 'R' : 'L' ) ));
            }
            
            sb.Append("!");
            
            p = c;
        }
        
        
        return sb.ToString();
    }
}