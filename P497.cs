public class Solution {

    List<int> list = new List<int>();
    int p = -1;
    Random rand = new Random();
    int[][] rects = null;
    public Solution(int[][] rects) {
        
        var len = rects.Length;
        for(int i = 0;i<len;i++){
            var arr = rects[i];
            p++;
            list.Add(p);
            p += (arr[2]-arr[0]+1)*(arr[3]-arr[1]+1);
        }
        p++;
        this.rects = rects;
    }
    
    public int[] Pick() {
        var n = rand.Next(p);
        
        var index = list.BinarySearch(n);
        
        if(index < 0){
            index = ~index;
            index--;
        }
        
        var r = rects[index];
        
        var x = r[0] + rand.Next(r[2]-r[0]+1);
        var y = r[1] + rand.Next(r[3]-r[1]+1);
        
        return new int[]{x,y};
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(rects);
 * int[] param_1 = obj.Pick();
 */