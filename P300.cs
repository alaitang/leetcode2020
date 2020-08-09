public class Solution {
    public int LengthOfLIS(int[] nums) {
        
        var list = new List<int>();
        
        foreach(var item in nums){
            var index = list.BinarySearch(item);
            if(index < 0)
                index = ~index;
            
            if(index < list.Count)
                list[index] = item;
            else
                list.Add(item);
            
        }
        
        return list.Count;
    }
}


public class Solution {
    public int LengthOfLIS(int[] nums) {
        
        var len = nums.Length;
        var dp = new int[len];
        var result = 0;
        for(int i = 0;i<len;i++){
            dp[i] = 1;
            for(int j = i-1;j>=0;j--){
                if(nums[i] > nums[j]){
                    dp[i] = Math.Max(dp[i],dp[j]+1);
                }
            }
            
            result = Math.Max(dp[i],result);
        }
        
        return result;
    }
}