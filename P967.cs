public class Solution {
    public int[] NumsSameConsecDiff(int N, int K) {
        if(N == 1)
            return new int[]{0,1,2,3,4,5,6,7,8,9};
        
        var pool = new List<int>{1,2,3,4,5,6,7,8,9};
        
        for(int i = 1;i<N;i++){
            var newPool = new List<int>();
            foreach(var item in pool){
                var last = item%10;
                if(last+K <= 9 && item *10 + last+K >= item){
                    newPool.Add(item *10 + last+K);
                }
                
                if(K != 0 && last-K >= 0 && item *10 + last-K >= item){
                    newPool.Add(item *10 + last-K);
                }
            }
            pool = newPool;
        }
        
        return pool.ToArray();
    }
}