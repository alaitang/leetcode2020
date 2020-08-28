public class Solution {
    public int SuperPow(int a, int[] b) {
        
        long result = 1;
        var M = 1337;
        
        for(int i = b.Length-1;i>=0;i--){
            long basea = 1;
            for(int j = 0;j<b[i];j++)
            {
                basea*=a;
                basea%=M;
            }
            
            result *= basea;
            result %= M;
            
            basea = 1;
            for(int j = 0;j<10;j++){
                basea*=a;
                basea%=M;
            }
            a = (int)basea;
        }
        
        return (int)result;
    }
}