public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        
        var min = matrix[0][0];
        var max = matrix[rows-1][cols-1];
        
        while(min < max-1){
            var mid = (min+max)/2;
            var count = Helper(matrix,mid,rows,cols);
            if(count < k){
                min = mid;
            }else{
                max = mid;
            }
        }
        
        if(Helper(matrix,min,rows,cols) >= k)
            return min;
        else
            return max;
        
    }
    
    private int Helper(int[][] m,int n, int rows,int cols){
        var result = 0;
        
        var i = rows-1;
        var j = 0;
        
        while(i >=0 && j < cols){
            if(m[i][j] <= n){
                result += i+1;
                j++;
            }else{
                i--;
            }
        }
        
        return result;
    }
}