public class Solution {
    public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges) {
        var rblue = new int[n];
        var rred = new int[n];
        
        for(int i = 0;i<n;i++)
        {
            rblue[i] = -1;
            rred[i] = -1;
        }
        
        rblue[0] = 0;
        rred[0] = 0;
        
        
        var redMapping = new Dictionary<int,List<int>>();
        
        foreach(var arr in red_edges){
            if(!redMapping.ContainsKey(arr[0]))
                redMapping[arr[0]] = new List<int>();
            
            redMapping[arr[0]].Add(arr[1]);
        }
        
        var blueMapping = new Dictionary<int,List<int>>();
        
        foreach(var arr in blue_edges){
            if(!blueMapping.ContainsKey(arr[0]))
                blueMapping[arr[0]] = new List<int>();
            
            blueMapping[arr[0]].Add(arr[1]);
        }
        
        
        var bluePool = new HashSet<int>(){0};
        var redPool = new HashSet<int>(){0};
        
        while(bluePool.Any() || redPool.Any()){
            var newBluePool = new HashSet<int>(); 
            var newRedPool = new HashSet<int>();
            
            foreach(var item in bluePool){
            
                if(blueMapping.ContainsKey(item)){
                    foreach(var c in blueMapping[item]){
                        if(rblue[c] == -1 || rblue[c] > rred[item]+1){
                            rblue[c] = rred[item]+1;
                            newRedPool.Add(c);
                        }
                    }
                }
                
            }
            
            foreach(var item in redPool){
            
                if(redMapping.ContainsKey(item)){
                    foreach(var c in redMapping[item]){
                        if(rred[c] == -1 || rred[c] > rblue[item]+1){
                            rred[c] = rblue[item]+1;
                            newBluePool.Add(c);
                        }
                    }
                }
                
            }
            
            
            bluePool = newBluePool;
            redPool = newRedPool;
        }
        
        var result = new int[n];
        
        
        for(int i = 0;i<n;i++)
        {
            if(rblue[i] == -1 && rred[i] == -1)
                result[i] = -1;
            else if(rblue[i] == -1 && rred[i] != -1)
                result[i] = rred[i];
            else if(rblue[i] != -1 && rred[i] == -1)
                result[i] = rblue[i];
            else
                result[i] = Math.Min(rblue[i],rred[i]);
        }
        
        return result;
    }
}