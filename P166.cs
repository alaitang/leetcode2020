public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        if(numerator == 0)
            return "0";
        var b = "";
        if(numerator < 0 && denominator > 0 || denominator < 0 && numerator > 0)
            b = "-";
        
        var N = Math.Abs((long)numerator);
        var M = Math.Abs((long)denominator);
        
        var n = N/M;
        
        N = N%M;
        
        if(N == 0)
            return b+n;
        
        var r = "";
        var visited = new Dictionary<long,int>();
        visited.Add(N,0);
        
        while(N != 0){
            N *= 10;
            r += N/M;
            N = N%M;
            if(!visited.ContainsKey(N))
                visited.Add(N,r.Length);
            else{
                r = r.Substring(0,visited[N]) + "(" + r.Substring(visited[N]) + ")";
                break;
            }
        }
        
        return  $"{b}{n}.{r}";
    }
}