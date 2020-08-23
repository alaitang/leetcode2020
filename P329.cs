public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        int rows = matrix.Length;
        if(rows == 0)
            return 0;
        
        var cols = matrix[0].Length;
        
        var dp = new int[rows,cols];
        var result = 0;
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                if(dp[i,j] == 0){
                    Helper(i,j,rows,cols,dp,matrix[i][j]-1,matrix);
                }
                
                result = Math.Max(dp[i,j],result);
            }
        }
        
        return result;
    }
    
    private int Helper(int i,int j,int rows,int cols,
                        int[,] dp,int p,int[][] matrix){
        if(i < 0 || j < 0 || i >=rows || j >= cols || matrix[i][j] <= p)
            return 0;
        
        if(dp[i,j] == 0)
        {
            var r = 1;
            r = Math.Max(Helper(i+1,j,rows,cols,dp,matrix[i][j],matrix)+1,r);
            r = Math.Max(Helper(i-1,j,rows,cols,dp,matrix[i][j],matrix)+1,r);
            r = Math.Max(Helper(i,j+1,rows,cols,dp,matrix[i][j],matrix)+1,r);
            r = Math.Max(Helper(i,j-1,rows,cols,dp,matrix[i][j],matrix)+1,r);
            
            dp[i,j] = r;
        }
        
        return dp[i,j];
    }
    
}