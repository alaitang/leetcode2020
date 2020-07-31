public class Solution {
    public IList<bool> CanMakePaliQueries(string s, int[][] queries) {
        var len = s.Length;
        var dp = new int[len];
        var b = 0;
        for(int i = 0;i<len;i++){
            b ^= (1 << (s[i]-'a'));
            dp[i] = b;
            
        }
        
        
        var result = new List<bool>();
        
        foreach(var q in queries){
            
            var n = dp[q[1]] ^ (q[0] == 0 ? 0 : dp[q[0]-1]);
            var diff = Convert.ToString(n,2).Where(x=>x=='1').Count();
            
            //Console.WriteLine(diff);
            var ll = q[1]-q[0]+1;
            if(ll % 2 == 0){
                result.Add(diff - q[2]*2 <= 0);
            }else{
                result.Add(diff - q[2]*2 <= 1);
            }
            
        }
        
        return result;
    }
}