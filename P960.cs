public class Solution {
    public int MinDeletionSize(string[] A) {
        var cols = A[0].Length;
        var rows = A.Length;
        var dp = new int[cols];
        var result = cols-1;
        
        
        for(int j = 1;j<cols;j++)
        {
            dp[j] = j;
            
            for(int j1 = j-1;j1>=0;j1--)
            {
                var valid = true;
                for(int i = 0;i<rows;i++){
                    
                    if(A[i][j1] > A[i][j]){
                        valid = false;
                        break;
                    }
                }
                
                if(valid){
                    dp[j] = Math.Min(dp[j1]+j-j1-1,dp[j]);
                }
            }
            
            result = Math.Min(dp[j]+cols-j-1,result);
        }
        return result;
    }
}