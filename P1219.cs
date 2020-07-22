public class Solution {
    public int GetMaximumGold(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var result = 0;
        var visited = new bool[rows,cols];
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                result = Math.Max(result,Helper(grid,rows,cols,i,j,visited));
            }
        }
        return result;
    }
    
    private int Helper(int[][] grid,int rows,int cols,int i,int j,bool[,] visited){
        if(i <0 || i >= rows || j <0 || j >= cols || visited[i,j] || grid[i][j] == 0)
            return 0;
        
        var result = 0;
        visited[i,j] = true;
        result = Math.Max(result,Helper(grid,rows,cols,i+1,j,visited));
        result = Math.Max(result,Helper(grid,rows,cols,i-1,j,visited));
        result = Math.Max(result,Helper(grid,rows,cols,i,j+1,visited));
        result = Math.Max(result,Helper(grid,rows,cols,i,j-1,visited));
        visited[i,j] = false;
        
        return result + grid[i][j];
    }
}