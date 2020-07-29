public class Solution {
    public string FrequencySort(string s) {
        var mapping = new Dictionary<char,int>();
        
        foreach(var c in s){
            if(!mapping.ContainsKey(c))
                mapping[c] = 0;
            mapping[c]++;
        }
        
        var keys = mapping.Keys.OrderBy(x=>-mapping[x]).ToList();
        var sb = new StringBuilder();
        foreach(var k in keys){
            sb.Append("".PadRight(mapping[k],k));
        }
        
        return sb.ToString();
    }
}