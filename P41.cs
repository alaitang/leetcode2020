public class Solution {
    public int FirstMissingPositive(int[] nums) {
        var len = nums.Length;
        
        for(int i = 0;i<len;i++){
            if(0 < nums[i] && nums[i] <= len ){
                if(nums[nums[i]-1] != nums[i]){
                    swap(nums,i,nums[i]-1);
                    i--;
                }
            }
        }
        var result = len+1;
        for(int i = 0;i<len;i++){
            if(nums[i] != i+1)
                return i+1;
        }
        return result;
    }
    
    private void swap(int[] nums,int i,int j){
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}