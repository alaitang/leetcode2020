public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        var index = -1;
        var i = 0;
        var j = 0;
        var len1 = pushed.Length;
        var len2 = popped.Length;
        
        while(i < len1){
            while(index >= 0 && j < len2 && pushed[index] == popped[j]){
                index--;
                j++;
            }
            
            pushed[++index] = pushed[i];
            i++;
        }
        
        while(j < len2 && index >=0 &&  pushed[index] == popped[j]){
            index--;
            j++;
        }
        
        return index < 0 && i >= len1 && j >= len2;
    }
}


public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        var stack = new Stack<int>();
        
        var i = 0;
        var j = 0;
        var len1 = pushed.Length;
        var len2 = popped.Length;
        
        while(i < len1){
            while(stack.Any() && j < len2 && stack.Peek() == popped[j]){
                stack.Pop();
                j++;
            }
            
            stack.Push(pushed[i]);
            i++;
        }
        
        while(j < len2 && stack.Any() && stack.Peek() == popped[j]){
            stack.Pop();
            j++;
        }
        
        return !stack.Any() && i >= len1 && j >= len2;
    }
}