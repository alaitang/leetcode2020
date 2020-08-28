public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        var maxstack = new Stack<int>();
        var minstack = new Stack<int>();
        
        foreach(var item in arr){
            var min = item;
            var max = item;
            while(maxstack.Any() && maxstack.Peek() > min ){
                min = Math.Min(min,minstack.Pop());
                max = Math.Max(max,maxstack.Pop());
            }
            minstack.Push(min);
            maxstack.Push(max);
        }
        
        return minstack.Count;
    }
}