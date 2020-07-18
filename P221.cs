public class Solution {
    public int MaximalSquare(char[][] matrix) {
        var rows = matrix.Length;
        if(rows == 0)
            return 0;
        var cols = matrix[0].Length;
        
        var dp = new int[cols];
        var dpcols = new int[cols];
        
        var result = 0;
        
        for(int i = 0;i<rows;i++){
            var r = 0;
            var newdp = new int[cols];
            for(int j = 0;j<cols;j++){
                if(matrix[i][j] == '0'){
                    r = 0;
                    dpcols[j] = 0;
                    newdp[j] = 0;
                }else{
                    r++;
                    dpcols[j]++;
                    
                    if(j-1 < 0 || dp[j-1] == 0)
                        newdp[j] = 1;
                    else{
                        newdp[j] = Math.Min(dpcols[j],r);
                        newdp[j] = Math.Min(newdp[j],dp[j-1]+1);
                    }
                }
                
                result = Math.Max(newdp[j],result);
            }
            dp = newdp;
        }
        
        return result * result;
    }
}