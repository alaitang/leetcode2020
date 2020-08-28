public class Solution {
    public string ReorganizeString(string S) {
        var dp = new int[26];
        
        foreach(var c in S){
            dp[c-'a']++;
        }
        var len = S.Length;
        var result = new char[len];
        var index = 0;
        var list = new List<char>();
        for(var c = 'a';c<='z';c++){
            list.Add(c);
        }
        list = list.OrderBy(x=>-dp[x-'a']).ToList();
        foreach(var c in list){
            
            for(int j = 0;j<dp[c-'a'];j++){
                if(index-1 >=0 && result[index-1] == c
                  || index +1 < len && result[index+1] == c)
                    return "";
                result[index] = c;
                index+=2;
                if(index >= len)
                    index = 1;
            }
        }
        
        return string.Join("",result);
    }
}