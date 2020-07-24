public class Solution {
    public bool CircularArrayLoop(int[] nums) {
        var len = nums.Length;
        
        for(int i = 0;i<len;i++){
            nums[i] %= len;
        }
        
        
        var t = 1;
        
        for(int i = 0;i<len;i++){
            if(nums[i] == 0 || nums[i] > 1000)
                continue;
            
            var current = i;
            var add = nums[i] > 0 ? 1 : -1;
            while(true){
                var n = nums[current];
                if(n == 1000+t)
                    return true;
                else if(n > 1000){
                    nums[current] = 1000+t;
                    break;
                }
                else if(n*add <=0)
                    break;
                nums[current] = 1000+t;
                current = (current+n+len)%len;
            }
            
            t++;
        }
        
        return false;
    }
}