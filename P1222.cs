public class Solution {
    public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king) {
        var result = new List<IList<int>>();
        
        var visited = new HashSet<int>();
        
        foreach(var q in queens){
            visited.Add(q[0]*8+q[1]);
        }
        
        var dp_i = new int[]{-1,1,0,0,-1,1,1,-1};
        var dp_j = new int[]{0,0,-1,1,-1,1,-1,1};
        
        for(int ii = 0;ii<8;ii++){
            var i = king[0];
            var j = king[1];
            
            while(i >=0 && j >=0 && i < 8 && j < 8){
                
                if(visited.Contains(i*8+j)){
                    result.Add(new List<int>(){i,j});
                    break;
                }
                i += dp_i[ii];
                j += dp_j[ii];
            }
        }
        
        
        return result;
    }
}