public class Solution {
    public int NumDupDigitsAtMostN(int N) {
        if(N <= 10)
            return 0;
        
        var s = $"{N}";
        int result = 0;
        for(int i = 1;i<s.Length;i++){
            result += 9* Helper(9,i-1);
        }
        
        var pool = new HashSet<char>();
        var len = s.Length;
        var isvalid = true;
        for(int i = 0;i<len;i++){
            
            var b = 0;
            for(char c = '1';c<s[i];c++){
                if(!pool.Contains(c))
                    b++;
            }
            
            if(s[i] != '0' && i != 0 && !pool.Contains('0'))
                b++;
            
            result += b*Helper(10-(i+1),len-(i+1));
            
            //Console.WriteLine();
            
            if(!pool.Add(s[i])){
                isvalid = false;
                break;
            }
        }
        
        if(isvalid)
            result++;
        
        return N - result;
    }
    
    private int Helper(int n,int m){
        if(m == 0)
            return 1;
        
        int result = 1;
        for(int i = 0;i<m;i++)
            result *= (n-i);
        return result;
    }
}