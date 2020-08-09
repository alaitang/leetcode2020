public class Solution {
    public int RotatedDigits(int N) {
        
        var mapping = new Dictionary<int,int>(){
            {0,0},
            {1,1},
            {8,8},
            {2,5},
            {5,2},
            {6,9},
            {9,6}
        };
        
        var result = 0;
        
        var pool = new Queue<int>();
        pool.Enqueue(0);
        var rpool = new Queue<int>();
        rpool.Enqueue(0);
        
        while(pool.Any()){
            var top = pool.Dequeue();
            var rt = rpool.Dequeue();
            
            foreach(var kv in mapping){
                var newNum = top*10+kv.Key;
                var newReverNum = rt*10 +kv.Value;
                
                if(newNum <= N && newNum != top ){
                    if(newNum != newReverNum)
                        result++;
                    pool.Enqueue(newNum);
                    rpool.Enqueue(newReverNum);
                }
            }
        }
        
        return result;
    }
}