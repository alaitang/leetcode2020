public class Solution {
    public int FindDerangement(int n) {
        if(n <= 2)
            return n-1;
        long r = 1;
        long p = 0;
        for(int i = 3;i<=n;i++){
            var nextp = r;
            r = r* (i-1) + p * (i-1);
            
            r %= 1000000007;
            
            p = nextp;
        }
        
        return (int)r;
    }
}