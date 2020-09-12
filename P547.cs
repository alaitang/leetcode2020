public class Solution {
    public int FindCircleNum(int[][] M) {
        var N = M.Length;
        
        var visited = new HashSet<int>();
        var result = 0;
        
        for(int i = 0;i<N;i++){
            if(visited.Add(i)){
                var pool = new HashSet<int>(){i};
                while(pool.Any()){
                    var newPool = new HashSet<int>(); 
                    foreach(var item in pool){
                        for(int j = 0;j<N;j++){
                            if(M[item][j] == 1 && visited.Add(j)){
                                newPool.Add(j);
                            }
                        }
                    }
                    pool = newPool;
                }
                result++;
            }
        }
        
        return result;
    }
}