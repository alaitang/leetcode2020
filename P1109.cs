public class Solution {
    public int[] CorpFlightBookings(int[][] bookings, int n) {
        var result = new int[n];
        
        foreach(var b in bookings){
            result[b[0]-1]+=b[2];
            if(b[1] < n)
                result[b[1]] -= b[2];
        }
        
        var r = 0;
        
        for(int i = 0;i<n;i++){
            r+=result[i];
            result[i] = r;
        }
        return result;
    }
}