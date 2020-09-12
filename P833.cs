public class Solution {
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
        var mapping = new Dictionary<int,string[]>();
        var len = indexes.Length;
        
        for(int i = 0;i<len;i++){
            mapping.Add(indexes[i],new string[]{sources[i],targets[i]});
        }
        
        len = S.Length;
        
        var sb = new StringBuilder();
        
        for(int i = 0;i<len;i++){
            if(mapping.ContainsKey(i)){
                var ii = i;
                var j = 0;
                
                while(ii < len && j < mapping[i][0].Length
                     && S[ii] == mapping[i][0][j]){
                    ii++;
                    j++;
                }
                
                if(j >= mapping[i][0].Length){
                    sb.Append(mapping[i][1]);
                    i = ii-1;
                }else{
                    sb.Append(S[i]);
                }
            }else{
                sb.Append(S[i]);
            }
        }
        
        return sb.ToString();
    }
}