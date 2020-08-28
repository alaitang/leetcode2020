public class Solution {
    public int MaxDistance(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        var pool = new HashSet<int>();
        var dp = new int[rows,cols];
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                if(grid[i][j] == 1){
                    pool.Add(i*cols+j);
                }
            }
        }
        
        while(pool.Any()){
            var newPool = new HashSet<int>();
            
            foreach(var item in pool){
                var i = item/cols;
                var j = item%cols;
                
                Helper(i+1,j,rows,cols,dp,dp[i,j]+1,grid,newPool);
                Helper(i-1,j,rows,cols,dp,dp[i,j]+1,grid,newPool);
                Helper(i,j+1,rows,cols,dp,dp[i,j]+1,grid,newPool);
                Helper(i,j-1,rows,cols,dp,dp[i,j]+1,grid,newPool);
            }
            
            pool = newPool;
        }
        var result = -1;
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                
                result = Math.Max(dp[i,j],result);
            }
        }
        
        return result == 0? -1 : result;
        
    }
    
    private void Helper(int i,int j,int rows,int cols,int[,] dp, int step, int[][] grid, HashSet<int> newPool){
        
        if(i < 0 || j < 0 || i >= rows || j >= cols ||grid[i][j] == 1 || dp[i,j] != 0 && dp[i,j] < step)
            return;
        
        dp[i,j] = step;
        
        newPool.Add(i*cols+j);
        
    }
}