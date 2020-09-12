public class Solution {
    public int RectangleArea(int[][] rectangles) {
        var list = new List<int>();
        
        var mapping = new Dictionary<int,List<int>>();
        var len = rectangles.Length;
        for(int i = 0;i<len;i++){
            var r = rectangles[i];
            
            if(!mapping.ContainsKey(r[0]))
                mapping[r[0]] = new List<int>();
            mapping[r[0]].Add(i+1);
            
            if(!mapping.ContainsKey(r[2]))
                mapping[r[2]] = new List<int>();
            mapping[r[2]].Add(-(i+1));
        }
        
        var keys = mapping.Keys.OrderBy(x=>x).ToList();
        
        len = keys.Count;
        
        long p = 0;
        
        long result = 0;
        
        for(int i = 0;i<len;i++){
            
            var k = keys[i];
            if(i != 0){
                result += p*(k-keys[i-1]);
                result %= 1000000007;
            }
            
            
            foreach(var r in mapping[k]){
                
                if(r > 0){
                    var index = list.BinarySearch(r-1,Comparer<int>.Create((a,b)=>{
                        var rr =  rectangles[a][1] - rectangles[b][1];
                        if(rr == 0)
                            rr = rectangles[a][3] - rectangles[b][3];
                        return rr;
                    }));
                    if(index < 0)
                        index = ~index;
                    list.Insert(index,r-1);
                }else{
                    list.RemoveAt(list.IndexOf(-r-1));
                }
            }
            
            p = 0;
            int pp = -1;
            foreach(var item in list){
                var low = rectangles[item][1];
                var high = rectangles[item][3];
                
                low = Math.Max(low,pp);
                p += Math.Max(high-low,0);
                
                pp = Math.Max(high,pp);
            }
        }
        
        return (int)result;
    }
}