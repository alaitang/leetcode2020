public class Solution {
    public int[] RearrangeBarcodes(int[] barcodes) {
        var mapping = new Dictionary<int,int>();
        foreach(var n in barcodes){
            if(!mapping.ContainsKey(n))
                mapping[n] = 0;
            mapping[n]++;
        }
        
        var keys = mapping.Keys.OrderBy(x=>-mapping[x]).ToList();
        
        var index = 0;
        var len = barcodes.Length;
        var result = new int[len];
        foreach(var k in keys){
            for(int i= 0 ;i<mapping[k];i++){
                result[index] = k;
                index+=2;
                if(index >= len)
                    index = 1;
            }
        }
        
        return result;
    }
}