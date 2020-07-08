public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        var minList = new List<int>();
        
        var maxList = new List<int>();
        
        var low = 0;
        var len = nums.Length;
        
        var result = 0;
        
        
        for(int i = 0;i<len;i++){
            
            var n = nums[i];
            
            while(minList.Any() && minList[0] > n)
                minList.RemoveAt(0);
            minList.Insert(0,n);
            
            
            while(maxList.Any() && maxList[0] < n)
                maxList.RemoveAt(0);
            maxList.Insert(0,n);
            
            while(low < i && maxList.Last() - minList.Last() > limit ){
                
                if(maxList.Last() == nums[low])
                    maxList.RemoveAt(maxList.Count-1);
                
                
                if(minList.Last() == nums[low])
                    minList.RemoveAt(minList.Count-1);
                
                low++;
            }
            
            result = Math.Max(result,i-low+1);
        }
        
        return result;
    }
}