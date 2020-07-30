public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var low = 0;
        var len = nums.Length;
        var list = new List<int>();
        var result = new List<int>();
        for(int i = 0;i<len;i++){
            var li = list.Count;
            while(li > 0 && list[li-1] < nums[i]){
                list.RemoveAt(li-1);
                li--;
            }
            
            list.Add(nums[i]);
            
            if(i-low+1 > k){
                if(nums[low] == list[0])
                    list.RemoveAt(0);
                low++;
            }
            
            if(i >= k-1)
                result.Add(list[0]);
        }
        
        return result.ToArray();
    }
}