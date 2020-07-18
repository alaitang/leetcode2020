public class Solution {
    public string RemoveDuplicates(string s, int k) {
        var slen = new Stack<int>();
        var stack = new Stack<char>();
        
        foreach(var c in s){
            if(stack.Any() && stack.Peek() == c){
                slen.Push(slen.Pop()+1);
            }else{
                stack.Push(c);
                slen.Push(1);
            }
            
            if(slen.Any() && slen.Peek() == k){
                slen.Pop();
                stack.Pop();
            }
        }
        
        var sb = new StringBuilder();
        
        while(stack.Any()){
            sb.Insert(0,("").PadRight(slen.Pop(),stack.Pop()));
        }
        
        return sb.ToString();
    }
}