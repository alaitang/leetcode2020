public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);
        
        var i = rows-1;
        var j = 0;
        
        while(i >=0 && j < cols){
            if(matrix[i,j] == target)
                return true;
            else if(matrix[i,j] > target){
                i--;
            }else
                j++;
        }
        return false;
    }
}