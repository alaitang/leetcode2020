public class Solution {
    public int ShortestPath(int[][] grid, int k) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        var mapping = new Dictionary<int,Dictionary<int,int>>();
        
        mapping.Add(0,new Dictionary<int,int>());
        mapping[0][0] = 0;
        
        var pool = new Queue<int>();
        var stepPool = new Queue<int>();
        var kpool = new Queue<int>();
        
        pool.Enqueue(0);
        stepPool.Enqueue(0);
        kpool.Enqueue(0);
        
        while(pool.Any()){
            var index = pool.Dequeue();
            var steps = stepPool.Dequeue();
            var rk = kpool.Dequeue();
            
            var i = index/cols;
            var j = index%cols;
            
            Helper(pool,stepPool,kpool,k,i+1,j,rows,cols,steps+1,rk,grid,mapping);
            Helper(pool,stepPool,kpool,k,i-1,j,rows,cols,steps+1,rk,grid,mapping);
            Helper(pool,stepPool,kpool,k,i,j+1,rows,cols,steps+1,rk,grid,mapping);
            Helper(pool,stepPool,kpool,k,i,j-1,rows,cols,steps+1,rk,grid,mapping);
        }
        
        var endIndex = rows*cols-1;
        if(!mapping.ContainsKey(endIndex))
            return -1;
        
        return mapping[endIndex].Values.Min();
        
    }
    
    private void Helper(Queue<int> pool, Queue<int> stepPool, Queue<int> kpool,
                        int k, int i,int j,int rows,int cols, int step,int rk, int[][] grid, 
                       Dictionary<int,Dictionary<int,int>> mapping){
        if(i < 0 || j < 0 || i >= rows || j >= cols){
            return;
        }
        
        if(grid[i][j] == 1)
            rk++;
        if(rk > k)
            return;
        
        var index = i*cols+j;
        if(mapping.ContainsKey(index) 
           && mapping[index].ContainsKey(rk) 
           && mapping[index][rk] <= step )
            return;
        
        if(!mapping.ContainsKey(index))
            mapping[index] = new Dictionary<int,int>();
        
        mapping[index][rk] = step;
        
        pool.Enqueue(index);
        stepPool.Enqueue(step);
        kpool.Enqueue(rk);
    }
}