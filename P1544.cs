public class Solution {
    public string MakeGood(string s) {
        var sb = new StringBuilder();
        
        foreach(var c in s){
            if(sb.Length == 0  || Math.Abs(sb[sb.Length-1]-c) != 32)
            {
                sb.Append(c);
            }else if(sb.Length > 0){
                sb.Length--;
            }
        }
        
        return sb.ToString();
    }
}