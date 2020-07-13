public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
        var mapping = new Dictionary<int,Dictionary<int,double>>();
        var len = edges.Length;
        
        for(int i = 0;i<len;i++){
            var a = edges[i][0];
            var b = edges[i][1];
            
            if(!mapping.ContainsKey(a))
                mapping[a]= new Dictionary<int,double>();
            
            mapping[a][b] = succProb[i]; 
            
            if(!mapping.ContainsKey(b))
                mapping[b]= new Dictionary<int,double>();
            
            mapping[b][a] = succProb[i]; 
        }
        
        var pool = new HashSet<int>();
        var dp = new double[n];
        dp[start] = 1;
        
        pool.Add(start);
        
        while(pool.Any()){
            var newpool = new HashSet<int>();
            foreach(var item in pool){
                var p = dp[item];

                if(mapping.ContainsKey(item)){
                    foreach(var kv in mapping[item]){
                        if(kv.Value * p > dp[kv.Key]){
                            dp[kv.Key]  = kv.Value * p;
                            newpool.Add(kv.Key);
                        }
                    }
                }
            }
            pool = newpool;
        }
        
        return dp[end];
    }
}