public class Solution {
    public int BestRotation(int[] A) {
        var len = A.Length;
        var dp = new int[len+1];
        
        var current = 0;
        var rr = 0;
        
        for(int i = 0;i<len;i++){
            if(A[i] <= i){
                current++;
                dp[i-A[i]+1]--;
                dp[i+1]++;
            }else if(A[i] != len){
                dp[i+1]++;
                dp[len-(A[i]-i)+1]--;
            }
        }
        var result = current;
            //Console.WriteLine(current + ":" + 0);
        for(int i = 1;i< len;i++){
            current += dp[i];
            if(current > result){
                rr = i;
                result = current;
            }
            //Console.WriteLine(current + ":" + i);
        }
        
        return rr;
    }
}