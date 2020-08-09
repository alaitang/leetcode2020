public class Solution {
    public int ShortestSubarray(int[] A, int K) {
        var list = new List<int>(){-1};
        
        long sum = 0;
        
        var len = A.Length;
        var dp  = new long[len];
        int result = len+1;
        for(int i = 0;i<len;i++){
            sum+=A[i];
            
            while(list.Any() && sum- (list[0] == -1? 0 :  dp[list[0]]) >= K){
                result = Math.Min(result,i-list[0]);
                list.RemoveAt(0);
            }
            
            while(list.Any() && sum <= (list.Last() == -1? 0 :  dp[list.Last()])){
                list.RemoveAt(list.Count-1);
            }
            
            list.Add(i);
            dp[i] = sum;
        }
        
        
        return (result == len+1) ? -1 : result;
    }
}