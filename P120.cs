public class Solution {
    public int MinimumTotal(IList<IList<int>> t) {
        var depth = t.Count;
        
        depth-=2;
        
        while(depth >= 0){
            var len = t[depth].Count;
            
            for(int i = 0;i<len;i++){
                t[depth][i] += Math.Min(t[depth+1][i],t[depth+1][i+1]);
            }
            depth--;
        }
        
        return t[0][0];
    }
}