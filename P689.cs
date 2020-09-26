public class Solution {
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        var len = nums.Length;
        
        var sums = new long[len];
        
        var dpleft = new int[len];
        
        long sum = 0;
        for(int i = 0;i<len;i++){
            dpleft[i] = -1;
            
            sum += nums[i];
            
            sums[i] = sum;
            
            if(i >= k-1){
                
                var currentSub = sum - (i == k-1 ? 0 : sums[i-k]);
                
                if(i==0 || dpleft[i-1] == -1 || currentSub > sums[dpleft[i-1]] - (dpleft[i-1]-k < 0 ? 0 : sums[dpleft[i-1]-k]) ){
                    dpleft[i] = i;
                }else{
                    dpleft[i] = dpleft[i-1];
                } 
            }
        }
        
        
        var sumsr = new long[len];
        
        var dpright = new int[len];
        
        sum = 0;
        
        long currentmax = 0;
        var index1 = -1;
        var index2 = -1;
        var index3 = -1;
        
        for(int i = len-1;i>=0;i--){
            
            dpright[i] = -1;
            
            sum += nums[i];
            
            sumsr[i] = sum;
            
            if(i <= len-k){
                var currentSub = sum - (i+k >= len ? 0 : sumsr[i+k]);
                
                if(i==len-1 || dpright[i+1] == -1 || currentSub >= sumsr[dpright[i+1]] - (dpright[i+1]+k >= len ? 0 : sumsr[dpright[i+1]+k]) ){
                    dpright[i] = i;
                }else{
                    dpright[i] = dpright[i+1];
                } 
            }
            
            if(i <= len-2*k && i >= k){
                var currentSub = sum - (i+k >= len ? 0 : sumsr[i+k]);
                //Console.WriteLine($"{i},{dpleft[i-1]},{i-1-k}");
                var leftmax = sums[dpleft[i-1]] - (dpleft[i-1]-k < 0 ? 0 : sums[dpleft[i-1]-k]);
                
                var rightmax = sumsr[dpright[i+k]] - (dpright[i+k]+k >= len ? 0 : sumsr[dpright[i+k]+k]);
                
                if(currentSub + leftmax + rightmax >= currentmax ){
                    currentmax = currentSub + leftmax + rightmax;
                    
                    index1 = dpleft[i-1]-k+1;
                    index2 = i;
                    index3 = dpright[i+k];
                }
            }
        }
        
        
        
        return new int[]{index1,index2,index3};
        
    }
}