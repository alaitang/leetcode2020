public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        
        var visited = new HashSet<int>();
        
        if(nums.Length < 2)
            return false;
        
        visited.Add(0);
        int sum = nums[0];
        var preSum = nums[0];
        
        for(int i = 1;i<nums.Length ;i++){
            var item = nums[i];
            sum += item;
            
            if(k != 0)
                sum %= k;
            
            if(visited.Contains(sum))
                return true;
            
            visited.Add(k == 0?preSum : preSum%k);
            
            preSum = sum;
        }
        
        return false;
    }
}