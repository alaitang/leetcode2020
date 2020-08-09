public class Solution {
    public int LongestAwesome(string s) {
        var len = s.Length;
        
        var current = 0;
        
        var mapping = new Dictionary<int,int>();
        mapping.Add(0,-1);
        var result = 0;
        for(int i = 0;i<len;i++){
            
            current ^= (1 << (s[i]-'0'));
            
            
            for(int j = 0;j<10;j++){
                var d = current ^ (1 << j);
                
                if(mapping.ContainsKey(d)){
                    result = Math.Max(i-mapping[d],result);
                }
            }
            
            
            if(mapping.ContainsKey(current))
                result = Math.Max(i-mapping[current],result);
            else
                mapping[current] = i;
            
        }
        
        return result;
    }
}