public class Solution {
    public int[] ClosestDivisors(int num) {
        num++;
        var mid = (long)Math.Floor(Math.Sqrt(num))+1;
        
        while(num % mid != 0)
            mid--;
        
        var low = mid;
        var high = num/mid;
        num++;
        mid = (long)Math.Floor(Math.Sqrt(num))+1;
        
        while(num % mid != 0)
            mid--;
        var low1 = mid;
        var high1 = num/mid;
        
        if(Math.Abs(high1 - low1) < Math.Abs(high - low)){
            high = high1;
            low = low1;
        }
        
        return new int[]{(int)low,(int)high};
    }
}