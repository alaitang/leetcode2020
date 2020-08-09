
public class Solution {
    public int MinScoreTriangulation(int[] A) {
        var len = A.Length;
        
        var dp = new int[len,len];
        
        
        for(int i = 2;i<len;i++){
            
            for(int j = i-2;j>=0;j--){
                
                dp[j,i] = A[j]*A[i]*A[i-1] + dp[j,i-1];
                
                for(int k = j+1;k<i;k++){
                    var v = A[j]*A[i]*A[k] + dp[j,k] + dp[k,i];
                    dp[j,i] = Math.Min(v,dp[j,i]);
                }
                
                //Console.WriteLine(j+","+i+" = "+  dp[j,i]);
                
            }
        }
        
        return dp[0,len-1];
        
    }
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public int MinScoreTriangulation(int[] A) {
        var len = A.Length;
        
        var dp = new int[len,len];
        
        return Helper(A,0,len-1,dp);
    }
    
    private int Helper(int[] A,int low,int high,int[,] dp){
        if(low > high-2)
            return 0;
        
        if(dp[low,high] == 0){
            dp[low,high] = int.MaxValue;
            for(int i = low+1;i<high;i++){
                dp[low,high] = Math.Min(dp[low,high], Helper(A,low,i,dp)
                    + Helper(A,i,high,dp) + A[low]*A[i]*A[high]);
            }
        }
        
        return dp[low,high];
    }
}