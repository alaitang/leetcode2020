public class Solution {
    public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration) {
        var len1 = slots1.Length;
        
        var len2 = slots2.Length;
        
        var i = 0;
        var j = 0;
        
        slots1 = slots1.OrderBy(x=>x[0]).ToArray();
        slots2 = slots2.OrderBy(x=>x[0]).ToArray();
        
        while(i < len1 && j < len2){
            if(!(slots1[i][1] < slots2[j][0] || slots1[i][0] > slots2[j][1]) ){
                var high = Math.Min(slots1[i][1],slots2[j][1]);
                var low = Math.Max(slots1[i][0],slots2[j][0]);
                if(high - low >= duration){
                    return new List<int>(){low,low+duration};
                }
            }
            
            if(slots1[i][1] <= slots2[j][1]){
                i++;
            }else{
                j++;
            }
        }
        
        return new List<int>();
    }
}