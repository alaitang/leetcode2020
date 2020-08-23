public class Solution {
    public bool ContainsCycle(char[][] grid) {
        
        
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        var dp = new bool[rows,cols];
        
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                if(dp[i,j])
                    continue;
                
                if(Helper(i,j,grid,dp,rows,cols))
                    return true;
            }
        }
        
        return false;
    }
    
    private bool Helper(int i,int j,char[][] grid, bool[,] dp,int rows,int cols){
        var c = grid[i][j];
        dp[i,j] = true;
        var queue = new Queue<int>();
        queue.Enqueue(i*cols+j);
        
        while(queue.Any()){
            var top = queue.Dequeue();
            var ii = top/cols;
            var jj = top%cols;
            
            var k = Helper(ii+1,jj,c,dp,grid,rows,cols,queue)
                + Helper(ii-1,jj,c,dp,grid,rows,cols,queue)
                + Helper(ii,jj+1,c,dp,grid,rows,cols,queue)
                + Helper(ii,jj-1,c,dp,grid,rows,cols,queue);
            
            if(k > 1)
                return true;
        }
        
        return false;
    }
    
    private int Helper(int i,int j, char c, bool[,] dp ,char[][] grid,int rows,int cols, Queue<int> queue ){
        if(i < 0 || j < 0 || i >= rows || j >= cols || grid[i][j] != c )
            return 0;
        
        if(dp[i,j])
            return 1;
        dp[i,j] = true;
        queue.Enqueue(i*cols+j);
        return 0;
    }
}