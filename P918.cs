public class Solution {
    public int MaxSubarraySumCircular(int[] A) {
        long min = 0;
        long result = int.MinValue;
        long sum = 0;
        
        long minSum = int.MaxValue;
        long maxSum = int.MinValue;
        foreach(var a in A){
            sum+=a;
            result = Math.Max(sum-min,result);
            min = Math.Min(min,sum);
            
            minSum = Math.Min(sum-maxSum,minSum);
            maxSum = Math.Max(sum,maxSum);
        }
        
        result = Math.Max(result,sum-minSum);
        
        
        return (int)result;
        
    }
}