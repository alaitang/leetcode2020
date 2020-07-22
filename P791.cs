public class Solution {
    public string CustomSortString(string S, string T) {
        var mapping = new int[26];
        var t =1;
        foreach(var c in T){
            mapping[c-'a']++;
        }
        
        var sb = new StringBuilder();
        
        foreach(var c in S){
            sb.Append("".PadRight(mapping[c-'a'],c));
            mapping[c-'a'] = 0;
        }
        
        for(int i = 0;i<26;i++)
        {
            if(mapping[i] != 0)
                sb.Append("".PadRight(mapping[i],(char)('a'+i)));
        }
        
        return sb.ToString();
    }
}


public class Solution {
    public string CustomSortString(string S, string T) {
        var mapping = new int[26];
        var t =1;
        foreach(var c in S){
            mapping[c-'a'] = t++;
        }
        
        return string.Join("",T.OrderBy(x=>mapping[x-'a']));
    }
}