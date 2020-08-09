public class Solution {
    public int FindMaxValueOfEquation(int[][] points, int k) {
        var len = points.Length;
        var list = new List<int>();
        var low = 0;
        var result = int.MinValue;
        for(int i = 0;i<len;i++){
            while(low < i && points[i][0] - points[low][0] > k){
                if(list.Any() && list[0] == low)
                    list.RemoveAt(0);
                low++;
            }
            
            if(list.Any()){
                result = Math.Max(result,points[i][1] + points[i][0]+points[list[0]][1] - points[list[0]][0]);
            }
            
            while(list.Any() && points[list.Last()][1] - points[list.Last()][0]
                 <= points[i][1] - points[i][0] )
            {
                list.RemoveAt(list.Count-1);
            }
            
            list.Add(i);
        }
        
        return result;
    }
}