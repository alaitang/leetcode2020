public class Solution {
    public int MaximumSum(int[] arr) {
        var len = arr.Length;
        
        var m1 = int.MinValue; // max remove one
        var m2 = arr[0]; // max continue
        
        var result = m2;
        
        for(int i = 1;i<len;i++){
            
            m1 = m1 == int.MinValue ? Math.Max(m2,arr[i]) :  Math.Max(m1+arr[i],m2);
            
            m2 = Math.Max(m2+arr[i],arr[i]);
            
            result = Math.Max(result,Math.Max(m1,m2));
            
        }
        
        
        return result;
    }
}