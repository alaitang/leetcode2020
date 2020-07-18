public class Solution {
    public int MaxJumps(int[] arr, int d) {
        var len = arr.Length;
        var dp = new int[len];
        
        var list = new List<int>();
        for(int i = 0;i<len;i++){
            list.Add(i);
        }
        list = list.OrderBy(x=>arr[x]).ToList();
        var result = 0;
        foreach(var index in list){
            
            var max = 1;
            
            var ii = index-1;
            while(ii >=0 && ii >= index-d && arr[ii] < arr[index]){
                max = Math.Max(dp[ii]+1,max);
                ii--;
            }
            
            ii = index+1;
            while(ii <len && ii <= index+d && arr[ii] < arr[index]){
                max = Math.Max(dp[ii]+1,max);
                ii++;
            }
            
            dp[index] = max;
            
            result = Math.Max(max,result);
        }
        return result;
    }
}