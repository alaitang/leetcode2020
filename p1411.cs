public class Solution {
    public int NumOfWays(int n) {
        long n1 = 6;
        long n2 = 6;
        
        for(int i = 2;i<=n;i++){
            var nextn1 = n1*3+n2*2;
            var nextn2 = n1*2+n2*2;
            
            n1 = nextn1 % 1000000007;
            n2 = nextn2 % 1000000007;
        }
        
        return (int)((n1+n2)%1000000007);
    }
}