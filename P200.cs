public class Solution {
    public int NumIslands(char[][] grid) {
        var rows = grid.Length;
        if(rows == 0)
            return 0;
        var cols = grid[0].Length;
        var result = 0;
        for(int i = 0;i<rows;i++)
        {
            for(int j = 0;j<cols;j++)
            {
                if(grid[i][j] == '1'){
                    var pool = new Queue<int>();
                    pool.Enqueue(i*cols+j);
                    
                    while(pool.Any()){
                        var top = pool.Dequeue();
                        
                        var ii = top/cols;
                        var jj = top%cols;
                        grid[ii][jj] = '0';
                           
                        Helper(rows,cols,ii+1,jj,grid,pool);
                        Helper(rows,cols,ii-1,jj,grid,pool);
                        Helper(rows,cols,ii,jj+1,grid,pool);
                        Helper(rows,cols,ii,jj-1,grid,pool);
                    }
                    result++;
                }
                
            }
        }
        
        return result;
    }
    
    private void Helper(int rows,int cols,int i,int j, char[][] grid, Queue<int> pool){
        if(i < 0 || i >= rows || j <0 || j >= cols || grid[i][j] == '0')
            return;
        grid[i][j] = '0';
        pool.Enqueue(i*cols+j);
    }
}