public class Solution {
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        var n = startTime.Length;
        
        var list = new List<int>();
        
        for(int i = 0;i<n;i++){
            var index = list.BinarySearch(i,Comparer<int>.Create((a,b)=>{
                var r = endTime[a]-endTime[b];
                if(r == 0)
                    r = startTime[a]-startTime[b];
                return r;
            }));
            
            if(index < 0)
                index = ~index;
            list.Insert(index, i);
        }
        
        var pool = new List<int>();
        var mapping = new Dictionary<int,int>();
        var result = 0;
        for(int ii = 0;ii<n;ii++){
            var i = list[ii];
            
            var index = pool.BinarySearch(startTime[i]);
            
            if(index < 0){
                index = ~index;
            }else{
                index++;
            }
            
            var currentmax = profit[i];
            
            if(index-1 >=0){
                currentmax += mapping[pool[index-1]];
            }
            
            if(pool.Any()){
                currentmax = Math.Max(currentmax,mapping[pool.Last()]);
            }
            
            if(mapping.ContainsKey(endTime[i])){
                mapping[endTime[i]] = Math.Max(mapping[endTime[i]],currentmax);
            }else{
                mapping[endTime[i]] = currentmax;
            }
            
            if(!pool.Any()  || pool.Last() != endTime[i]){
                pool.Add(endTime[i]);
            }
            
            
            result = Math.Max(currentmax,result);
        }
        
        return result;
        
    }
}