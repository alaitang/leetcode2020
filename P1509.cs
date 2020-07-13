public class Solution {
    public int MinDifference(int[] nums) {
        var len = nums.Length;
        
        if(len <= 4)
            return 0;
        
        var minArr = new int[4]{int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue};
        var maxArr = new int[4]{int.MinValue,int.MinValue,int.MinValue,int.MinValue};
        
        foreach(var item in nums){
            if(item <= minArr[0]){
                minArr[3] = minArr[2];
                minArr[2] = minArr[1];
                minArr[1] = minArr[0];
                minArr[0] = item;
            }else if(item <= minArr[1]){
                minArr[3] = minArr[2];
                minArr[2] = minArr[1];
                minArr[1] = item;
            }else if(item <= minArr[2]){
                minArr[3] = minArr[2];
                minArr[2] = item;
            }else if(item < minArr[3]){
                minArr[3] = item;
            }
            
            
            if(item >= maxArr[0]){
                maxArr[3] = maxArr[2];
                maxArr[2] = maxArr[1];
                maxArr[1] = maxArr[0];
                maxArr[0] = item;
            }else if(item >= maxArr[1]){
                maxArr[3] = maxArr[2];
                maxArr[2] = maxArr[1];
                maxArr[1] = item;
            }else if(item >= maxArr[2]){
                maxArr[3] = maxArr[2];
                maxArr[2] = item;
            }else if(item > maxArr[3]){
                maxArr[3] = item;
            }
        }
        
        var result = int.MaxValue;
        result = Math.Min(maxArr[0]-minArr[3],result);
        result = Math.Min(maxArr[1]-minArr[2],result);
        result = Math.Min(maxArr[2]-minArr[1],result);
        result = Math.Min(maxArr[3]-minArr[0],result);
        
        return result;
    }
    
}