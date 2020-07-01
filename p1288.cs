public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        
        var len = intervals.Length;
        
        var result = len;
        
        var list = intervals.OrderBy(x=>x[0]).ThenBy(x=>-x[1]).ToList();
        
        var high = -1;
        foreach(var item in list){
            if(item[1] <= high){
                result--;
            }else{
                high = item[1];
            }
        }
        
        return result;
    }
}