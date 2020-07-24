public class Solution {
    public int MinPatches(int[] nums, int n) {
        
        long max = 0;
        var result = 0;
        var index = 0;
        var len = nums.Length;
        for(int i = 1;i<=n && index < len;i++)
        {
            while(index < len && i == nums[index]){
                max+=i;
                index++;
            }
            
            
            if(i > max){
                max+=i;
                result++;
            }
            
            if(max >= n)
                break;
            
        }
        
        while(max < n){
            result++;
            max+=max+1;
        }
        
        return result;
    }
}