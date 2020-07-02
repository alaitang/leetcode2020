public class Solution {
    public string LargestNumber(int[] cost, int target) {
        var dp = new int[5001][];
        
        for(int i = 0;i<=target;i++){
            if(i == 0){
                dp[i] = new int[9];
            }else if(dp[i] == null){
                continue;
            }
            
            for(int j = 0;j<9;j++){
                if(i+cost[j]> target)
                    continue;
                
                if(dp[i+cost[j]] == null){
                    dp[i+cost[j]] = dp[i].ToArray();
                    //Console.WriteLine($"{i} -> set to {i+cost[j]}");
                    dp[i+cost[j]][j]++;
                }else{
                    dp[i][j]++;
                    
                    if(!Compare(dp[i+cost[j]],dp[i])){
                        dp[i+cost[j]] = dp[i].ToArray();
                        //Console.WriteLine($"{i} add {j+1} -> set to {i+cost[j]}");
                    }
                    
                    dp[i][j]--;
                }
            }
        }
        
        if(dp[target] == null)
            return "0";
        
        var sb = new StringBuilder();
        
        for(int i = 8;i>=0;i--){
            sb.Append("".PadRight(dp[target][i],(char)('1'+i)));
        }
        
        
        
        return sb.ToString();
    }
    
    private bool Compare(int[] a1,int[] a2){
        
        var sumdiff = a1.Sum() - a2.Sum();
        if(sumdiff < 0)
            return false;
        else if(sumdiff > 0)
            return true;
        
        for(int i = 8;i>=0;i--){
            if(a1[i] < a2[i])
                return false;
            else if(a1[i] > a2[i])
                return true;
        }
        
        return true;
    }
}