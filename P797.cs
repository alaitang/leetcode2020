public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        var pool = new List<IList<int>>();
        
        pool.Add(new List<int>(){0});
        var end = graph.Length-1;
        
        var result = new List<IList<int>>();
        while(pool.Any()){
            var newPool = new List<IList<int>>();
            foreach(var item in pool){
                foreach(var n in graph[item.Last()]){
                    var newlist = item.ToList();
                    newlist.Add(n);
                    if(n == end){
                        result.Add(newlist);
                    }else{
                        newPool.Add(newlist);
                    }
                }
            }
            pool = newPool;
        }
        
        return result;
    }
}