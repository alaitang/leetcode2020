public class Solution {
    public bool ParseBoolExpr(string expression) {
        
        var v = new Stack<int>();
        v.Push(0);
        var op = new Stack<char>();
        op.Push('|');
        
        var len = expression.Length;
        for(int i = 0;i<len;i++){
            var c = expression[i];
            if(c == 't' || c == 'f'){
                if(op.Peek() == '|'){
                    v.Push(v.Pop() | (c == 't' ? 1 : 0));
                }else if(op.Peek() == '&'){
                    v.Push(v.Pop() & (c == 't' ? 1 : 0));
                }else if(op.Peek() == '!'){
                    v.Push((c == 't' ? 0 : 1));
                }
            }else if( c == '!'){
                op.Push(c);
                i++;
            }else if (c == '&' || c == '|'){
                op.Push(c);
                v.Push(c == '&' ? 1 : 0);
                i++;
            }else if(c == ')'){
                var vv = v.Pop();
                var oop = op.Pop();
                
                if(op.Peek() == '|'){
                    v.Push(v.Pop() | vv);
                }else if(op.Peek() == '&'){
                    v.Push(v.Pop() & vv);
                }else if(op.Peek() == '!'){
                    v.Push(vv == 1 ? 0 : 1);
                }
                
                //Console.WriteLine(oop+","+v.Peek()+","+vv);
            }
        }
        
        return v.Pop() == 1;
    }
}