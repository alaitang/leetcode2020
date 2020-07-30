public class Solution {
    public int NetworkDelayTime(int[][] times, int N, int K) {
        var dp = new int[N+1];
        
        for(int i = 1;i<=N;i++)
            dp[i] = -1;
        
        dp[K]=0;
        
        var mapping = new Dictionary<int,Dictionary<int,int>>();
        
        foreach(var arr in times){
            if(!mapping.ContainsKey(arr[0]))
                mapping[arr[0]] = new Dictionary<int,int>();
            
            mapping[arr[0]][arr[1]] = arr[2];
        }
        
        
        var pool = new HashSet<int>(){K};

        while(pool.Any()){
            var newpool = new HashSet<int>();

            foreach(var item in pool){
                if(!mapping.ContainsKey(item))
                    continue;
                foreach(var kv in mapping[item]){
                    if(dp[kv.Key] == -1 || dp[kv.Key] > dp[item]+kv.Value  )
                    {
                        dp[kv.Key] = dp[item]+kv.Value;
                        newpool.Add(kv.Key);
                    }
                }
            }


            pool = newpool;
        }
        var result = -1;
        for(int i = 1;i<=N;i++)
        {
            if(dp[i] == -1)
                return -1;
            result = Math.Max(result,dp[i]);
        }
        
        return result;
    }
    
    
}
