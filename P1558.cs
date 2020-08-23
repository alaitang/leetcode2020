public class Solution {
    public int MinOperations(int[] nums) {
        var result = 0;
        var len = nums.Length;
        while(nums.Any(x=>x > 0)){
            for(int i = 0;i<len;i++){
                if(nums[i] % 2 == 1){
                    result++;
                    nums[i]--;
                }
                nums[i]/=2;
            }
            if(nums.Any(x=>x > 0))
                result++;
        }
        
        return result;
    }
}