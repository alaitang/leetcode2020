public class Solution {
    public int LargestIsland(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        var heads = new int[rows*cols];
        var counts = new int[rows*cols];
        for(int i = 0;i<rows*cols;i++){
            heads[i] = i;
            counts[i] = 1;
        }
                        //Console.WriteLine(string.Join(",",heads));
        var result = 0;
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                if(grid[i][j] == 1){
                    var h = FindHead(heads, i*cols+j);
                    if(i-1 >=0 && grid[i-1][j] == 1){
                        var hh = FindHead(heads,(i-1)*cols+j);
                        if(hh != h){
                            counts[h]+=counts[hh];
                            heads[hh] = h;
                        }
                    }
                    if(i+1 < rows && grid[i+1][j] == 1){
                        var hh = FindHead(heads,(i+1)*cols+j);
                        if(hh != h){
                            counts[h]+=counts[hh];
                            heads[hh] = h;
                        }
                    }
                    if(j-1 >=0 && grid[i][j-1] == 1){
                        var hh = FindHead(heads,(i)*cols+j-1);
                        if(hh != h){
                            counts[h]+=counts[hh];
                            heads[hh] = h;
                        }
                    }
                    if(j+1 < cols && grid[i][j+1] == 1){
                        var hh = FindHead(heads,(i)*cols+j+1);
                        if(hh != h){
                            counts[h]+=counts[hh];
                            heads[hh] = h;
                        }
                    }
                    result = Math.Max(result,counts[h]);
                }
            }
        }
        
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                if(grid[i][j] == 0){
                    var visitedHead = new HashSet<int>();
                    var r = 1;
                    if(i-1 >=0 && grid[i-1][j] == 1){
                        var hh = FindHead(heads,(i-1)*cols+j);
                        if(visitedHead.Add(hh)){
                            r+=counts[hh];
                        }
                    }
                    if(i+1 < rows && grid[i+1][j] == 1){
                        var hh = FindHead(heads,(i+1)*cols+j);
                        if(visitedHead.Add(hh)){
                            r+=counts[hh];
                        }
                    }
                    if(j-1 >=0 && grid[i][j-1] == 1){
                        var hh = FindHead(heads,(i)*cols+j-1);
                        if(visitedHead.Add(hh)){
                            r+=counts[hh];
                        }
                    }
                    if(j+1 < cols && grid[i][j+1] == 1){
                        var hh = FindHead(heads,(i)*cols+j+1);
                        if(visitedHead.Add(hh)){
                            r+=counts[hh];
                        }
                    }
                    result = Math.Max(result,r);
                }
            }
        }
        
        
        return result;
    }
    
    private int FindHead(int[] heads,int i){
        if(heads[i] == i)
            return i;
        return FindHead(heads,heads[i]);
    }
}