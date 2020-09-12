public class Solution {
    public bool HasValidPath(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        if(rows == 1 && cols == 1)
            return true;
        
        var mapping = new bool[7,4];
        
        mapping[1,0] = true; mapping[1,2] = true;
        mapping[2,1] = true; mapping[2,3] = true;
        mapping[3,0] = true; mapping[3,3] = true;
        mapping[4,2] = true; mapping[4,3] = true;
        mapping[5,0] = true; mapping[5,1] = true;
        mapping[6,1] = true; mapping[6,2] = true;
        
        var dp_i = new int[]{0,-1,0,1};
        var dp_j = new int[]{-1,0,1,0};
        
        var connect = new Dictionary<int,int>()
        {
            {0,2},
            {2,0},
            {1,3},
            {3,1}  
        };
        
        
        var pool = new HashSet<int>(){0};
        var visited = new HashSet<int>(){0}; 
        
        while(pool.Any()){
            var newPool = new HashSet<int>();
            
            foreach(var item in pool){
                var i = item/cols;
                var j = item%cols;
                
                for(int ii = 0;ii<4;ii++){
                    if(mapping[grid[i][j],ii]){
                        var nexti = i + dp_i[ii];
                        var nextj = j + dp_j[ii];
                        
                            //Console.WriteLine($"Verify {ii} {nexti},{nextj}");
                        if(nexti >=0 && nexti < rows && nextj >=0  && nextj < cols && visited.Add(nexti*cols+nextj)
                          && mapping[grid[nexti][nextj], connect[ii]] ){
                            //Console.WriteLine($"Add {nexti},{nextj}");
                            if(nexti*cols+nextj == rows*cols-1)
                                return true;
                            newPool.Add(nexti*cols+nextj);
                        }
                    }
                }
            }
            
            pool = newPool;
        }
        
        return false;
    }
}