public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix) {
        var rows = matrix.Length;
        if(rows == 0)
            return new int[]{};
        var cols = matrix[0].Length;
        
        var index = 0;
        
        var result = new int[rows*cols];
        
        var i = 0;
        var j = 0;
        
        while(index < rows*cols){
            result[index] = matrix[i][j];
            
            if((i+j) % 2 == 0){
                if( i == 0 && j == cols-1){
                    i++;
                }else if(i == 0){
                    j++;
                }else if(j == cols-1){
                    i++;
                }else{
                    i--;j++;
                }
            }else{
                if(i == rows-1 && j == 0){
                    j++;
                }else if(j == 0){
                    i++;
                }else if(i == rows-1){
                    j++;
                }else{
                    i++;
                    j--;
                }
            }
            
            index++;
        }
        
        return result;
    }
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix) {
        var rows = matrix.Length;
        if(rows == 0)
            return new int[]{};
        var cols = matrix[0].Length;
        
        var index = 0;
        
        var result = new int[rows*cols];
        
        var i = 0;
        var j = 0;
        
        var b = 0;
        
        while(index < rows*cols){
            result[index] = matrix[i][j];
            
            if(b % 2 == 0){
                i--;
                j++;
            }else{
                i++;
                j--;
            }
            
            if(i < 0){
                i++;
                if(j >= cols){
                    j = cols-1;
                    i++;
                }
                b++;
            }else if( j >= cols){
                j = cols-1;
                i+=2;
                b++;
            }else if (j < 0){
                j++;
                if(i >= rows){
                    i = rows-1;
                    j++;
                }
                b++;
            }else if(i >= rows){
                i = rows-1;
                j+=2;
                b++;
            }
            index++;
        }
        
        return result;
    }
}