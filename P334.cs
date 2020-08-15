public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        var min = int.MaxValue;
        var min1 = int.MaxValue;
        
        
        foreach(var n in nums){
            if(n > min1)
                return true;
            
            if(n > min)
                min1 = Math.Min(min1,n);
            
            min = Math.Min(min,n);
        }
        
        return false;
        
    }
}