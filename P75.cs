public class Solution {
    public void SortColors(int[] nums) {
        var fistIndex = -1;
        var lastIndex = nums.Length;
        
        for(int i = 0;i<lastIndex;i++){
            if(nums[i] == 0){
                swap(nums,i, ++fistIndex);
                if(nums[i] == 2)
                    i--;
            }else if(nums[i] == 2){
                swap(nums,i, --lastIndex);
                i--;
            }
        }
        
        
    }
    
    private void swap(int[] nums,int i,int j){
        var t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}