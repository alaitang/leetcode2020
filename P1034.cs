
public class Solution {
    public int[][] ColorBorder(int[][] grid, int r0, int c0, int color) {
        var queue = new Queue<int>();
        
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        queue.Enqueue(r0*cols+c0);
        
        var c = grid[r0][c0];
        
        var visited = new HashSet<int>();
        visited.Add(r0*cols+c0);
        
        while(queue.Any()){
            var top = queue.Dequeue();
            
            var i = top/cols;
            var j = top%cols;
            
            if(i == 0 || i == rows-1 || j == 0 || j == cols-1)
                grid[i][j] = color;
            
            if(i-1 >=0 && !visited.Contains((i-1)*cols+j)){
                if(grid[i-1][j] == c){
                    queue.Enqueue((i-1)*cols+j);
                    visited.Add((i-1)*cols+j);
                }
                else
                    grid[i][j] = color;
                    
            }
            
            if(i+1 < rows && !visited.Contains((i+1)*cols+j)){
                if(grid[i+1][j] == c){
                    queue.Enqueue((i+1)*cols+j);
                    visited.Add((i+1)*cols+j);
                }
                else
                    grid[i][j] = color;
            }
            
            if(j-1 >=0 && !visited.Contains(i*cols+j-1)){
                if(grid[i][j-1] == c){
                    queue.Enqueue(i*cols+j-1);
                    visited.Add(i*cols+j-1);
                }
                else
                    grid[i][j] = color;
                
            }
            
            if(j+1 < cols && !visited.Contains(i*cols+j+1)){
                
                if(grid[i][j+1] == c){
                queue.Enqueue(i*cols+j+1);
                    visited.Add(i*cols+j+1);
                }
                else
                    grid[i][j] = color;
                
            }
        }
        
        return grid;
        
    }
}


>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public int[][] ColorBorder(int[][] grid, int r0, int c0, int color) {
        var queue = new Queue<int>();
        
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        queue.Enqueue(r0*cols+c0);
        
        var c = grid[r0][c0];
        
        var visited = new HashSet<int>();
        var visited1 = new HashSet<int>();
        
        while(queue.Any()){
            var top = queue.Dequeue();
            //Console.WriteLine(top);
            
            var i = top/cols;
            var j = top%cols;
            
            if(grid[i][j] != c || visited.Contains(top) || visited1.Contains(top))
                continue;
            
            grid[i][j] = -grid[i][j];
            
            if (i-1 < 0 || grid[i-1][j] != c && grid[i-1][j] != -c
                || i+1 >= rows || grid[i+1][j] != c && grid[i+1][j] != -c
                || j-1 < 0 || grid[i][j-1] != c && grid[i][j-1] != -c
                || j+1 >= cols || grid[i][j+1] != c && grid[i][j+1] != -c)
            {
                grid[i][j] = -c;
                visited1.Add(i*cols+j);
            }else{
                grid[i][j] = -c;
                visited.Add(i*cols+j);
            }
            
            if(i-1 >=0 && grid[i-1][j] == c)
                queue.Enqueue((i-1)*cols+j);
            
            if(i+1 < rows && grid[i+1][j] == c)
                queue.Enqueue((i+1)*cols+j);
            
            if(j-1 >=0 && grid[i][j-1] == c)
                queue.Enqueue(i*cols+j-1);
            
            if(j+1 < cols && grid[i][j+1] == c)
                queue.Enqueue(i*cols+j+1);
        }
        
        foreach(var item in visited){
            grid[item/cols][item%cols] = c;
        }
        
        
        foreach(var item in visited1){
            grid[item/cols][item%cols] = color;
        }
        
        
        return grid;
        
    }
}