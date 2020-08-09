public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var baseM = new int[26];
        var tm = 26;
        foreach(var c in p){
            if(baseM[c-'a']++ == 0)
                tm--;
        }
        
        var m = new int[26];
        var low = 0;
        var len = s.Length;
        
        var result = new List<int>();
        
        for(int i = 0;i<len;i++){
            var c = s[i];
            m[c-'a']++;
            
            if(m[c-'a'] == baseM[c-'a'])
                tm++;
            
            while(m[c-'a'] > baseM[c-'a']){
                if(m[s[low]-'a']-- ==  baseM[s[low]-'a'])
                    tm--;
                low++;
            }
            
            if(tm == 26){
                result.Add(i-p.Length+1);
            }
        }
        
        return result;
    }
}