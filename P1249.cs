public class Solution {
    public string MinRemoveToMakeValid(string s) {
        
        var len = s.Length;
        var sb = new StringBuilder();
        var n = 0;
        for(int i = 0;i<len;i++){
            if(s[i] == '('){
                n++;
                sb.Append(s[i]);
            }else if(s[i] == ')'){
                if(n > 0){
                    sb.Append(s[i]);
                    n--;
                }
            }else{
                sb.Append(s[i]);
            }
        }
        
        len = sb.Length-1;
        n = 0;
        while(len >=0 ){
            if(sb[len] == ')'){
                n++;
            }else if(sb[len] == '('){
                if(n > 0)
                    n--;
                else{
                    sb.Remove(len,1);
                }
            }
            len--;
        }
        
        return sb.ToString();
    }
}