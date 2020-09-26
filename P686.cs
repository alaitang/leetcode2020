public class Solution {
    public int RepeatedStringMatch(string a, string b) {
        long t = 0;
        long m = 1000000007;
        
        long cc = 1;
        
        foreach(var c in b){
            t = t * 26 + (c-'a');
            t %= m;
            cc *= 26;
            cc %= m;
        }
        
        var a_len = a.Length;
        
        var b_len = b.Length;
        
        long tt = 0;
        
        var sb = new StringBuilder();
        
        for(int i = 0; i-b_len+1 < a_len;i++){
            tt = tt * 26 + (a[i%a_len]-'a');
            
            tt %= m;
            sb.Append(a[i%a_len]);
            
            if(i >= b_len){
                tt = (tt - cc * (a[ (i-b_len)%a_len ] -'a') % m + m) % m;
                sb.Remove(0,1);
            }
            
            if(i >= b_len-1 && tt == t && sb.ToString() == b){
                return (i+1)/a_len + ((i+1)%a_len == 0 ? 0 : 1);
            }
        }
        //Console.WriteLine(sb.ToString());
        //Console.WriteLine(b);
        return -1;
        
        
    }
}