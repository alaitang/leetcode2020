public class Solution {
    public int MaxScoreWords(string[] words, char[] letters, int[] score) {
        var wLen = words.Length;
        
        var max = (1<<wLen)-1;
        var result = 0;
        
        var basemap = new int[26];
        foreach(var c in letters){
            basemap[c-'a']++;
        }
        
        for(int i = 1;i<=max;i++){
            var m = new int[26];
            
            var n = i;
            var index = 0;
            bool isvalid = true;
            var t = 0;
            while(n > 0 && isvalid){
                if(n %2 == 1){
                    foreach(var c in words[index]){
                        if(++m[c-'a'] > basemap[c-'a'])
                        {
                            isvalid = false;
                            break;
                        }
                        t+= score[c-'a'];
                    }
                }
                index++;
                n/=2;
            }
            
            if(isvalid){
                result = Math.Max(t,result);
            }
        }
        
        return result;
    }
}