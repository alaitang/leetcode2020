public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        var result = new int[n];
        
        var ts = new Stack<int>();
        var tt = new Stack<int>();
        
        foreach(var log in logs){
            var arr = log.Split(new char[]{':'});
            
            var id = int.Parse(arr[0]);
            var start = arr[1] == "start";
            var time = int.Parse(arr[2]);
            
            if(start){
                if(ts.Any()){
                    result[ts.Peek()] += time - tt.Peek();
                }
                
                ts.Push(id);
                tt.Push(time);
            }else{
                result[ts.Pop()]+=time - tt.Pop()+1;
                
                if(ts.Any()){
                    tt.Pop();
                    tt.Push(time+1);
                }
            }
        }
        
        return result;
    }
}