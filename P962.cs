public class Solution {
    public int MaxWidthRamp(int[] A) {
        var stack = new Stack<int>();
        
        var len = A.Length;
        
        for(int i = 0;i<len;i++){
            if(!stack.Any() || A[stack.Peek()] > A[i] )
                stack.Push(i);
        }
        var result = 0;
        for(int i = len-1;i>=0;i--){
            while(stack.Any() && A[stack.Peek()] <= A[i]){
                result = Math.Max(result,i-stack.Pop());
            }
        }
        
        return result;
    }
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public int MaxWidthRamp(int[] A) {
        var len = A.Length;
        var list = new List<int>();
        for(int i = 0;i<len;i++)
            list.Add(i);
        
        list = list.OrderBy(x=>A[x]).ToList();
        var result = 0;
        var minIndex = len;
        foreach(var item in list){
            result = Math.Max(result,item-minIndex);
            minIndex = Math.Min(minIndex,item);
        }
        
        return result;
    }
}