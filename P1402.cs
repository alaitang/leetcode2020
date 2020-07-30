public class Solution {
    public int MaxSatisfaction(int[] satisfaction) {
        var arr = satisfaction.OrderBy(x=>x).ToArray();
        var result = 0;
        var sum = 0;
        var r = 0;
        for(int i = arr.Length-1;i>=0;i--){
            sum += arr[i];
            r += sum;
            if(r < result)
                break;
            result = r;
        }
        
        return result;
    }
}