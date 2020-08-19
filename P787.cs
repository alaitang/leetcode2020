public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
        K++;
        var mapping = new Dictionary<int,List<int[]>>();
        
        foreach(var f in flights){
            if(!mapping.ContainsKey(f[0]))
                mapping.Add(f[0],new List<int[]>());
            mapping[f[0]].Add(f);
        }
        
        var pool = new List<int[]>();
        pool.Add(new int[]{src,0,0});
        
        while(pool.Any()){
            var top = pool[0];
            if(top[0] == dst)
                return top[2];
            pool.RemoveAt(0);
            if(top[1]+1 <= K && mapping.ContainsKey(top[0])){
                foreach(var item in mapping[top[0]])
                {
                    var arr = new int[]{item[1],top[1]+1,top[2] + item[2]};
                    var index = pool.BinarySearch(arr,Comparer<int[]>.Create((a,b)=>{
                        return a[2]-b[2];
                    }));

                    if(index < 0)
                        index = ~index;

                    pool.Insert(index,arr);
                }
            }
        }
        
        return -1;
        
    }
}