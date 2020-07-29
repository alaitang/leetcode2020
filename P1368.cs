public class Solution {
    public int MinCost(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        var p = new int[][]{
            new int[]{0,1},
            new int[]{0,-1},
            new int[]{1,0},
            new int[]{-1,0},
        };
        
        var dp = new int[rows,cols];
        
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                dp[i,j] = -1;
            }
        }
        
        dp[0,0] = 0;
        
        var queue = new HashSet<int>(){0};
        
        while(queue.Any()){
            
            var newQueue = new HashSet<int>();
            
            foreach(var top in queue){
                
                var i = top/cols;
                var j = top%cols;
                var pp = dp[i,j];
                var visited = new HashSet<int>();
                while(true){
                    var k = grid[i][j];
                    if(!visited.Add(i*cols+j))
                        break;
                    for(var kk = 0;kk<4;kk++){
                        if(kk+1 != k){
                            var next_i = i+p[kk][0];
                            var next_j = j+p[kk][1];

                            if(next_i >=0 && next_i < rows && next_j >=0 && next_j < cols){
                                if(dp[next_i,next_j] > pp+1 || dp[next_i,next_j] == -1){
                                    dp[next_i,next_j] = pp+1;
                                    //Console.WriteLine($"add set : {next_i},{next_j} = {pp+1}");
                                    if(! (next_i == rows-1 && next_j == cols-1))
                                        newQueue.Add(next_i*cols+next_j);
                                }
                            }
                        }
                    }

                    i+= p[k-1][0];
                    j+= p[k-1][1];

                    if(i >=0 && i < rows && j >=0 && j < cols){
                        if(dp[i,j] > pp || dp[i,j] == -1){
                            dp[i,j] = pp;
                            //Console.WriteLine($"move set : {i},{j} = {pp}");
                            if(! (i == rows-1 && j == cols-1))
                                newQueue.Add(i*cols+j);
                        }else{
                            break;
                        }
                    }else{
                        break;
                    }

                }
            }
            
            queue = newQueue;
            
        }
        
        
        return dp[rows-1,cols-1];
    }
}