public class Solution {
    public int IslandPerimeter(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var result = 0;
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                if(grid[i][j] == 1){
                    result+=4;
                    if(i-1 >=0 && grid[i-1][j] == 1)
                        result-=2;

                    if(j-1 >=0 && grid[i][j-1] == 1)
                        result-=2;
                }
                
            }
        }
        
        return result;
    }
}