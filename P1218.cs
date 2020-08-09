public class Solution {
    public int LongestSubsequence(int[] arr, int diff) {
        var result = 0;
        var mapping = new Dictionary<int,int>();
        
        foreach(var item in arr){
            var r = 1;
            if(mapping.ContainsKey(item-diff)){
                r = mapping[item-diff]+1; 
            }
            
            if(!mapping.ContainsKey(item))
                mapping[item] = r;
            else
                mapping[item] = Math.Max(r,mapping[item]);
            result = Math.Max(result,r);
        }
        return result;
    }
}