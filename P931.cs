public class Solution {
    public int MinFallingPathSum(int[][] A) {
        var rows = A.Length;
        var cols = A[0].Length;
        
        for(int i = 1;i<rows;i++)
        {
            for(int j = 0;j<cols;j++){
                var v = A[i-1][j];
                if(j-1 >= 0)
                    v = Math.Min(v,A[i-1][j-1]);
                if(j+1  < cols)
                    v = Math.Min(v,A[i-1][j+1]);
                
                A[i][j] += v;
            }
        }
        
        
        return A.Last().Min();
        
    }
}