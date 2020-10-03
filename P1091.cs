public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        if(rows==1 && cols == 1)
            return 1;
        
        if(grid[0][0] == 1 || grid[rows-1][cols-1] == 1)
            return -1;
        var visited = new HashSet<int>();
        visited.Add(0);
        
        var result = 1;
        var pool = new HashSet<int>();
        pool.Add(0);
        
        while(pool.Any()){
            var newPool = new HashSet<int>();
            foreach(var item in pool){
                var i = item/cols;
                var j = item%cols;
                if(Helper(i+1,j,rows,cols,visited,newPool,grid)
                  || Helper(i-1,j,rows,cols,visited,newPool,grid)
                  || Helper(i,j+1,rows,cols,visited,newPool,grid)
                  || Helper(i,j-1,rows,cols,visited,newPool,grid)
                  || Helper(i+1,j+1,rows,cols,visited,newPool,grid)
                  || Helper(i+1,j-1,rows,cols,visited,newPool,grid)
                  || Helper(i-1,j+1,rows,cols,visited,newPool,grid)
                  || Helper(i-1,j-1,rows,cols,visited,newPool,grid)){
                    return result+1;
                }
            }
            
            pool = newPool;
            result++;
        }
        
        
        return -1;
    }
    
    private bool Helper(int i,int j,int rows,int cols,HashSet<int> visited,HashSet<int> pool,int[][] grid){
        if(i <0 || j < 0 || i >= rows || j >= cols || grid[i][j] == 1 || !visited.Add(i*cols+j))
            return false;
        
        pool.Add(i*cols+j);
        
        return i==rows-1 && j == cols-1;
    }
}