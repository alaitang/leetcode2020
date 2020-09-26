public class Solution {
    public int DistinctEchoSubstrings(string text) {
        
        var m = 1000000007;
        var len = text.Length;
        
        var mapping = new Dictionary<int,Dictionary<int,long>>();
        
        var visited = new HashSet<string>();
        var result = 0;
        
        for(int i = 0;i<len;i++){
            mapping[i] = new Dictionary<int,long>();
            
            long k = 0;
            
            for(int j = i;j>=0;j--){
                k = k * 26 + (text[j]-'a');
                k %= m;
                
                mapping[i][i-j+1] = k;
                
                if(j-1 >=0 && mapping[j-1].ContainsKey(i-j+1) && k == mapping[j-1][i-j+1]){
                    //visited.Add(text.Substring(j-(i-j+1),i-j+1));
                    visited.Add($"{k},{i-j+1}");
                }
            }
            
            
        }
        return visited.Count;
    }
}