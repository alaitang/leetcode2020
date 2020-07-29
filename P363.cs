public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var result = int.MinValue;
        var dp = new int[rows][];
        if(rows <= cols){
            
            for(int i = 0;i<rows;i++){
                dp[i] = new int[cols];
                for(int j = 0;j<cols;j++){
                    dp[i][j] = (i == 0 ? 0 : dp[i-1][j])+matrix[i][j];
                }
            }
            
            for(int i = 0;i<rows;i++){
                for(int ii = i;ii<rows;ii++){
                    var list = new List<int>(){k};
                    var sum = 0;
                    for(int j = 0;j<cols;j++){
                        sum += dp[ii][j] -  (i ==0 ? 0 : dp[i-1][j]);
                        
                        var index = list.BinarySearch(sum);
                        
                        
                        if(index < 0)
                            index = ~index;
                        
                        if(index < list.Count && sum-(list[index]-k) <= k)
                            result = Math.Max(sum-(list[index]-k),result);
                        
                        if(index-1 >=0 && sum- (list[index-1]-k) <= k)
                            result = Math.Max(sum-(list[index-1]-k),result);
                        
                        index = list.BinarySearch(sum+k);
                        
                        if(index < 0)
                            index = ~index;
                        
                        list.Insert(index,sum+k);
                    }
                }
            }
        }else{
            
            for(int i = 0;i<rows;i++){
                dp[i] = new int[cols];
                for(int j = 0;j<cols;j++){
                    dp[i][j] = (j == 0 ? 0 : dp[i][j-1])+matrix[i][j];
                }
            }
            
            for(int i = 0;i<cols;i++){
                for(int ii = i;ii<cols;ii++){
                    var list = new List<int>(){k}; 
                    var sum = 0;
                    for(int j = 0;j<rows;j++){
                        sum += dp[j][ii] -  (i ==0 ? 0 : dp[j][ii-1]);
                        
                        var index = list.BinarySearch(sum);
                        
                        if(index < 0)
                            index = ~index;
                        
                        if(index < list.Count && sum-(list[index]-k) <= k)
                            result = Math.Max(sum-(list[index]-k),result);
                        
                        if(index-1 >=0 && sum- (list[index-1]-k) <= k)
                            result = Math.Max(sum-(list[index-1]-k),result);
                        
                        index = list.BinarySearch(sum+k);
                        
                        if(index < 0)
                            index = ~index;
                        
                        list.Insert(index,sum+k);
                    }
                    
                }
            }
        }
        
        return result;
    }
    
}