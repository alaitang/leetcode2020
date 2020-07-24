public class Solution {
    public int NthSuperUglyNumber(int n, int[] primes) {
        var list = new List<int>(){1};
        var visited = new HashSet<int>(){1};
        var len = primes.Length;
        var dp = new int[len];
        
        var pool = new List<int>();
        
        for(int i = 0;i<len;i++){
            var index = pool.BinarySearch(i,Comparer<int>.Create((a,b)=>{
                return primes[a]*list[dp[a]] - primes[b]*list[dp[b]];
            }));
            
            if(index < 0)
                index = ~index;
            pool.Insert(index,i);
        }
        
        while(list.Count < n){
            var top = pool[0];
            pool.RemoveAt(0);
            
            var v = primes[top]*list[dp[top]];
            
            if(visited.Add(v)){
                list.Add(v);
            }
            dp[top]++;

            var index = pool.BinarySearch(top,Comparer<int>.Create((a,b)=>{
                return primes[a]*list[dp[a]] - primes[b]*list[dp[b]];
            }));

            if(index < 0)
                index = ~index;
            pool.Insert(index,top);
        }
        
        return list.Last();
    }
}