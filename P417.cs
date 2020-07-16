public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] matrix) {
        var result = new List<IList<int>>();
        
        var rows = matrix.Length;
        if(rows == 0)
            return result;
        var cols = matrix[0].Length;
        
        var visited1 = new HashSet<int>();
        var visited2 = new HashSet<int>();
        
        var pool = new HashSet<int>();
        
        for(int i = 0;i<rows;i++){
            visited1.Add(i*cols);
            pool.Add(i*cols);
        }
        
        for(int i = 0;i<cols;i++){
            visited1.Add(i);
            pool.Add(i);
        }
        
        Helper(matrix,rows,cols,visited1,pool);
        
        //Console.WriteLine(string.Join(" , ",visited1.Select(x=>$"[{x/cols},{x%cols}]")));
        
        pool = new HashSet<int>();
        
        for(int i = 0;i<rows;i++){
            visited2.Add(i*cols+cols-1);
            pool.Add(i*cols+cols-1);
        }
        
        for(int i = 0;i<cols;i++){
            visited2.Add(cols*(rows-1)+i);
            pool.Add(cols*(rows-1)+i);
        }
        Helper(matrix,rows,cols,visited2,pool);
        
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                var n = i*cols+j;
                if(visited1.Contains(n)
                  && visited2.Contains(n)){
                    result.Add(new List<int>{i,j});
                }
            }
        }
        
        return result;
    }
    
    private void Helper(int[][] matrix,int rows,int cols, HashSet<int> visited, HashSet<int> pool){
        while(pool.Any()){
            var newPool = new HashSet<int>();
            foreach(var item in pool){
                var i = item/cols;
                var j = item%cols;
                
                Helper(matrix,i+1,j,rows,cols,visited,newPool, matrix[i][j]);
                Helper(matrix,i-1,j,rows,cols,visited,newPool, matrix[i][j]);
                Helper(matrix,i,j+1,rows,cols,visited,newPool, matrix[i][j]);
                Helper(matrix,i,j-1,rows,cols,visited,newPool, matrix[i][j]);
            }
            pool = newPool;
        }
    }
    
    private void Helper(int[][] matrix,int i,int j,int rows,int cols, HashSet<int> visited, HashSet<int> newPool,int p){
        if(i < 0 || i >= rows || j <0 || j>=cols || matrix[i][j] < p || !visited.Add(i*cols+j))
            return ;
        
        newPool.Add(i*cols+j);
    }
}