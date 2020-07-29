public class Solution {
    public int CountVowelPermutation(int n) {
        long a = 1;
        long e = 1;
        long i = 1;
        long o = 1;
        long u = 1;
        
        for(int m  = 2;m<=n;m++){
            var nexta = e+i+u;
            var nexte = a+i;
            var nexti = e+o;
            var nexto = i;
            var nextu = i+o;
            
            a = nexta%1000000007;
            e = nexte%1000000007;
            i = nexti%1000000007;
            o = nexto%1000000007;
            u = nextu%1000000007;
        }
        
        return (int)((a+e+i+o+u)%1000000007);
    }
}