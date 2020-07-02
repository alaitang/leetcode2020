public class Solution {
    public bool IsPossibleDivide(int[] nums, int k) {
        
        nums = nums.OrderBy(x=>x).ToArray();
        var mapping = new Dictionary<int,Dictionary<int,int>>();
        foreach(var n in nums){
            
            if(mapping.ContainsKey(n) && mapping[n].Keys.Any()){
                var kk =  mapping[n].Keys.ToList()[0];
                if(kk + 1 < k){
                    if(!mapping.ContainsKey(n+1))
                        mapping[n+1] = new Dictionary<int,int>();
                    if(!mapping[n+1].ContainsKey(kk+1))
                        mapping[n+1][kk+1] = 0;
                    mapping[n+1][kk+1]++;
                }
                
                if(--mapping[n][kk] == 0)
                    mapping[n].Remove(kk);
            }else{
                if(!mapping.ContainsKey(n+1))
                    mapping[n+1] = new Dictionary<int,int>();
                if(!mapping[n+1].ContainsKey(1))
                    mapping[n+1][1] = 0;
                mapping[n+1][1]++;
            }
        }
        
        return mapping.Values.All(x=>!x.Values.Any());
    }
}