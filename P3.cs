public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var mapping = new Dictionary<char,int>();
        
        var low = 0;
        var result = 0;
        
        var len = s.Length;
        
        for(int i = 0;i<len;i++){
            var c = s[i];
            
            while(mapping.ContainsKey(c)){
                mapping.Remove(s[low++]);
            }
            
            mapping[c] = i;
            
            result = Math.Max(result,i-low+1);
        }
        
        return result;
    }
}