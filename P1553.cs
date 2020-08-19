public class Solution {
    Dictionary<int, int> dp = new Dictionary<int, int>();
    public int MinDays(int n) {
        if(n == 1)
            return 1;
        else if(n == 2)
            return 2;
        else if(n == 3)
            return 2;
        
         if (!dp.ContainsKey(n))
                dp.Add(n, 1 + Math.Min(n % 2 + MinDays(n / 2), n % 3 + MinDays(n / 3)));

        return dp[n];
    }
}