public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        var len = nums.Length;
        var result = new int[len];
        for(int i = 0;i<len;i++)
            result[i] = -1;
        var stack = new Stack<int>();
        for(int i = 0;i<2*len;i++){
            while(stack.Any() && nums[stack.Peek()%len] < nums[i%len] ){
                result[stack.Pop()%len] = nums[i%len];
            }
            
            stack.Push(i);
        }
        
        return result;
    }
}