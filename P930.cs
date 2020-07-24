public class Solution {
    public int NumSubarraysWithSum(int[] A, int S) {
        var mapping = new Dictionary<int,int>();
        mapping.Add(0,1);
        
        var sum = 0;
        var result = 0;
        foreach(var item in A){
            sum+=item;
            
            if(mapping.ContainsKey(sum-S))
                result += mapping[sum-S];
            
            if(!mapping.ContainsKey(sum))
                mapping[sum] = 0;
            mapping[sum]++;
        }
        return result;
    }
}