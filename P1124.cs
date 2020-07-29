public class Solution {
    public int LongestWPI(int[] hours) {
        var mapping = new Dictionary<int,int>();
        var len = hours.Length;
        var t = 0;
        mapping.Add(0,-1);
        var result = 0;
        for(int i = 0;i<len;i++){
            if(hours[i] > 8)
                t++;
            else
                t--;
            
            if(t > 0)
                result = i+1;
            else if(mapping.ContainsKey(t-1))
                result = Math.Max(i-mapping[t-1],result);
            
            if(!mapping.ContainsKey(t))
                mapping[t] = i;
        }
        
        return result;
    }
}