public class Solution {
    public int CheckRecord(int n) {
        
        long no_a_p = 1;
        long no_a_l = 1;
        long no_a_ll = 0;
        
        long a = 1;
        
        long a_l = 0;
        long a_p = 0;
        long a_ll = 0;
        
        int M = 1000000007;
        
        
        for(int i = 2;i<=n;i++){
            var next_no_a_p = no_a_l+no_a_ll+no_a_p;
            var next_no_a_l = no_a_p;
            var next_no_a_ll = no_a_l;
            
            var next_a = no_a_l+no_a_ll+no_a_p;
            
            var next_a_l = a+a_p;
            var next_a_p = a_l+a_ll+a+a_p;
            var next_a_ll = a_l;
            
            
            no_a_p = next_no_a_p %M;
            no_a_l = next_no_a_l %M;
            no_a_ll = next_no_a_ll %M;
            a = next_a %M;
            a_l = next_a_l %M;
            a_p = next_a_p %M;
            a_ll = next_a_ll %M;
        }
        
        return (int)((no_a_p+no_a_l+no_a_ll+a+a_l+a_p+a_ll) %M);
    }
}