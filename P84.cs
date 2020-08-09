public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var len = heights.Length;
        
        var dpleft = new int[len];
        
        var stack = new Stack<int>();
        
        for(int i = 0;i<len;i++){
            while(stack.Any() && heights[i] <= heights[stack.Peek()]){
                stack.Pop();
            }
            
            dpleft[i] = stack.Any() ? (i-stack.Peek()) : (i+1);
            
            stack.Push(i);
        }
        
        stack = new Stack<int>();
        var result = 0;
        for(int i = len-1;i>=0;i--){
            while(stack.Any() && heights[i] <= heights[stack.Peek()]){
                stack.Pop();
            }
            
            var r = (( stack.Any() ? (stack.Peek()-i-1) : (len-i-1))  + dpleft[i])*heights[i];
            
            result = Math.Max(r,result);
            
            
            stack.Push(i);
        }
        
        return result;
    }
}