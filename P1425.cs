public class Solution {
    public int ConstrainedSubsetSum(int[] nums, int k) {
        
        
        var len = nums.Length;
        
        var list = new List<int>();
        
        var low = 0;
        var result = int.MinValue;
        var dp = new int[len];
        
        for(int i = 0;i<len;i++){
            var currentmax = Math.Max(nums[i] , nums[i] + (list.Any() ? list.First():0) );
            
            while(list.Any() && currentmax > list.Last()){
                list.RemoveAt(list.Count-1);
            }
            
            list.Add(currentmax);
            
            if(i-low+1 > k){
                if(dp[low] == list[0]){
                    list.RemoveAt(0);
                }
                low++;
            }
            
            dp[i] = currentmax;
            
            result = Math.Max(result,currentmax);
            
        }
        
        return result;
        
    }
}