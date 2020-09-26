public class Solution {
    public int Calculate(string s) {
        s = s.Replace(" ","");
        var result = 0;
        var sign = 1;
        
        var stack  = new Stack<int>();
        stack.Push(1);
        var p = 0;
        
        foreach(var c in s){
            if(c == '+'){
                sign = stack.Peek()*1;
                p = 0;
            }else if(c == '-'){
                sign = stack.Peek()*-1;
                p = 0;
            }else if(c == '('){
                stack.Push(sign);
                p = 0;
            }else if(c == ')'){
                stack.Pop();
                p = 0;
            }else{
                result -= p;
                result += p*10 + sign*(c-'0');
                p = p*10 + sign*(c-'0');
            }
        }
        return result;
    }
}