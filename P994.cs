public class Solution {
    public int OrangesRotting(int[][] grid) {
        var result = 0;
        var rows = grid.Length;
        var cols = grid[0].Length;
        var pool = new HashSet<int>();
        var t = 0;
        for(var i = 0;i<rows;i++){
            for(var j = 0;j<cols;j++){
                if(grid[i][j] == 1){
                    t++;
                }else if(grid[i][j] == 2){
                    pool.Add(i*cols+j);
                }
            }
        }
        
        if(t == 0)
            return 0;
        
        while(pool.Any() && t > 0){
            var newPool = new HashSet<int>();
            
            foreach(var item in pool){
                var i = item/cols;
                var j = item%cols;
                
                if(Helper(grid,i+1,j,rows,cols,newPool))
                    t--;
                
                if(Helper(grid,i-1,j,rows,cols,newPool))
                    t--;
                if(Helper(grid,i,j+1,rows,cols,newPool))
                    t--;
                if(Helper(grid,i,j-1,rows,cols,newPool))
                    t--;
            }
            
            pool = newPool;
            result++;
        }
        
        if(t == 0)
            return result;
        return -1;
    }
    
    private bool Helper(int[][] grid,int i,int j,int rows,int cols,HashSet<int> newPool){
        if(i < 0 || j <0 || i>=rows || j >= cols || grid[i][j] != 1)
            return false;
        newPool.Add(i*cols+j);
        grid[i][j] = 2;
        return true;
    }
}