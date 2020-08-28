public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        var n1 = 0;
        var c1 = 0;
        
        var n2 = 0;
        var c2 = 0;
        
        foreach(var n in nums){
            
            if(n1 == n){
                c1++;
            }else if(n2 == n){
                c2++;
            }else if(c1 == 0){
                n1 = n;
                c1 = 1;
            }else if(c2 == 0){
                n2 = n;
                c2 = 1;
            }else {
                c1--;
                c2--;
            }
        }
        
        c1 = 0;
        c2 = 0;
        
        foreach(var n in nums){
            if(n == n1)
                c1++;
            else if(n == n2)
                c2++;
        }
        var result = new List<int>();
        
        if(c1 > nums.Length/3)
            result.Add(n1);
        if(c2 > nums.Length/3)
            result.Add(n2);
        
        return result;
        
    }
}