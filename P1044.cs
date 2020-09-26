public class Solution {
    public string LongestDupSubstring(string S) {
        var low = 1;
        var high = S.Length-1;
        var len = S.Length;
        
        
        while(low < high-1){
            var mid = (low+high)/2;
            
            var v = Helper(S,mid,len);
            
            if(v == ""){
                high = mid-1;
            }else{
                low = mid;
            }
        }
        
        var r = Helper(S,high,len);
        if(r == "")
            r = Helper(S,low,len);
        //Console.WriteLine(r.Length);
        return r;
        
        
    }
    
    private string Helper(string s,int t,int len){
        var mapping = new Dictionary<long,HashSet<int>>();
        var m = 1000000007;
        
        long current = 0;
        long b = 1;
        
        for(int i = 0;i<len;i++){
            current = (current * 26 + (s[i]-'a'))%m;
            
            if(i < t){
                b *= 26;
                b %= m;
            }else{
                //Console.WriteLine($"{t},{i},{s[i-t]}");
                current = (current - ( (b * (s[i-t]-'a') ) % m) + m)%m;
            }
            if(i >= t-1){
                if(!mapping.ContainsKey(current)){
                    mapping[current] = new HashSet<int>();
                }else{
                    var bb = s.Substring(i-t+1,t);
                    foreach(var ii in mapping[current]){
                        //Console.WriteLine($"{t} : {i}: {ii} : {ii-t+1}");
                        if(s.Substring(ii-t+1,t) == bb)
                            return bb;
                    }
                }
                mapping[current].Add(i);
            }
        }
        
        return "";
    }
}