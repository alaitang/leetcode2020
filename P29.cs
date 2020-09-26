public class Solution {
    public int Divide(int dividend, int divisor) {
        if(divisor == 0)
            return (int)(Math.Pow(2,31)-1);
        else if(dividend == 0)
            return 0;
        long r = Helper(Math.Abs((long)dividend),Math.Abs((long)divisor));
        
        if(dividend > 0 && divisor < 0
          || dividend < 0 && divisor > 0)
            r = -r;
        
        if(r > int.MaxValue || r < int.MinValue)
            return (int)(Math.Pow(2,31)-1);
        
        return (int)r;
    }
    
    private long Helper(long a,long b){
        long result = 0;
        
        while(a >= b){
            long t = 1;
            var bb = b;
            while(a >= bb){
                bb+=bb;
                t+=t;
            }
            
            a-=bb/2;
            result += t/2;
        }
        
        return result;
    }
}