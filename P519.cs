public class Solution {

    int rows = 0;
    int cols = 0;
    Dictionary<int,int> mapping = new Dictionary<int,int>();
    int total = 0;
    Random rand = new Random();
    public Solution(int n_rows, int n_cols) {
        rows = n_rows;
        cols = n_cols;
        total = rows * cols;
    }
    
    public int[] Flip() {
        var index = rand.Next(total);
        //Console.WriteLine(index);
        var result = new int[2];
        
        var oi = index;
        while(mapping.ContainsKey(index)){
            index = mapping[index];
        }
        //Console.WriteLine($"Get : {index}");
        result[0] = index/cols;
        result[1] = index%cols;
        
        if(oi < total-1){
            index = total-1;
            while(mapping.ContainsKey(index)){
                index = mapping[index];
            }
            //Console.WriteLine($"set : {oi} to {index}");
            mapping[oi] = index;
        }
        
        total--;
        return result;
        
    }
    
    public void Reset() {
        
        total = rows * cols;
        mapping = new Dictionary<int,int>();
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(n_rows, n_cols);
 * int[] param_1 = obj.Flip();
 * obj.Reset();
 */