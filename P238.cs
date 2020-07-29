public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var len = nums.Length;
        int v = 1;
        var result = new int[len];
        for(int i = 0;i<len;i++){
            result[i] = v;
            v *= nums[i];
        }
        v = 1;
        
        for(int i = len-1;i>=0;i--){
            result[i] *= v;
            
            v *= nums[i];
        }
        
        return result;
    }
}