public class Solution {
    public int ScoreOfParentheses(string S) {
        var vstack = new Stack<int>();
        vstack.Push(0);
        
        var len = S.Length;
        
        for(int i = 0;i<len;i++){
            if(S[i] == '(' && S[i+1] == ')'){
                vstack.Push(vstack.Pop()+1);
                i++;
            }else if(S[i] == '('){
                vstack.Push(0);
            }else{
                var a = vstack.Pop()*2;
                vstack.Push(vstack.Pop()+a);
            }
        }
        
        return vstack.Pop();
    }
}