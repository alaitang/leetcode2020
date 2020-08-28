public class Solution {
    public int FindMaxLength(int[] nums) {
        var mapping = new Dictionary<int,int>();
        var n = 0;
        var m = 0;
        var result = 0;
        var len = nums.Length;
        mapping.Add(0,-1);
        for(var i = 0;i<len;i++){
            var k = nums[i];
            if(k == 0)
                n++;
            else
                m++;
            
            if(!mapping.ContainsKey(n-m))
                mapping[n-m] = i;
            else
                result = Math.Max(i-mapping[n-m],result);
        }
        
        return result;
    }
}