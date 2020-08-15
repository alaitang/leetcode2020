public class Solution {
    public int MinJumps(int[] arr) {
        var mapping = new Dictionary<int,List<int>>();
        var len = arr.Length;
        if(len == 1)
            return 0;
        var dp = new int[len];
        for(int i = 0;i<len;i++){
            if(!mapping.ContainsKey(arr[i]))
                mapping[arr[i]] = new List<int>();
            
            mapping[arr[i]].Add(i);
            
            dp[i] = -1;
        }
        dp[0] = 0;
        
        var pool = new HashSet<int>(){0};
        
        var result = 0;
        while(pool.Any()){
            var newPool = new HashSet<int>();
            var visitedVal = new HashSet<int>();
            foreach(var item in pool){
                if(item+1 == len -1 || arr[item] == arr[len-1])
                    return result+1;
                
                if(item +1 < len && (dp[item+1] == -1 || dp[item+1] > result+1 ) ){
                    dp[item+1] = result+1;
                    newPool.Add(item+1);
                }
                if(item -1 >=0  && (dp[item-1] == -1 || dp[item-1] > result+1 ) ){
                    dp[item-1] = result+1;
                    newPool.Add(item-1);
                }
                
                if(visitedVal.Add(arr[item])){
                    
                    foreach(var ii in mapping[arr[item]]){
                        if(dp[ii] == -1 || dp[ii] > result+1 ){
                            dp[ii] = result+1;
                            newPool.Add(ii);
                        }
                    }
                }
                
            }
            
            pool = newPool;
            
            result++;
            if(pool.Contains(len-1))
                return result;
        }
        
        return 0;
    }
}