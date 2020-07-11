public class Solution {
    public string RemoveKdigits(string num, int k) {
        var stack = new Stack<char>();
        
        var len = num.Length;
        k = len-k;
        if(k == 0)
            return "0";
        for(int i = 0;i<len;i++){
            var c = num[i];
            
            while(stack.Any() && stack.Peek() > c && stack.Count -1 + len-i >= k){
                stack.Pop();
            }
            
            if(stack.Count < k)
                stack.Push(c);
        }
        
        var sb = new StringBuilder();
        
        while(stack.Any())
            sb.Append(stack.Pop());
        
        var result =  string.Join("",sb.ToString().Reverse());
        var index = 0;
        
        while(index < k && result[index] == '0')
            index++;
        
        result = result.Substring(index);
        return result == "" ? "0" : result;
    }
}