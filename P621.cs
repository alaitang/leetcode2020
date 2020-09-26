public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        if(n == 0)
            return tasks.Length;
        var dp = new int[26];
        
        foreach(var t in tasks){
            dp[t-'A']++;
        }
        n++;
        var result = 0;
        while(dp.Any(x=>x>1)){
            //Console.WriteLine(result + " : "+string.Join(".",dp));
            FindKth(dp,0,25,n);
            for(int i = 0;i<n && i < 26;i++){
                if(dp[i] >0 ){
                    dp[i]--;
                }
            }
            result+=n;
        }
        
        result+=dp.Sum();
        
        return result;
    }
    
    private void FindKth(int[] dp,int low,int high,int k){
        if(low >= high || k >= high-low+1)
            return;
        
        var ll = low;
        
        for(int i = low+1;i<=high;i++){
            if(dp[i] >= dp[low]){
                swap(dp,i,++ll);
            }
        }
        
        swap(dp,low,ll);
        
        if(ll+1-low == k)
            return;
        else if(ll+1-low > k){
            FindKth(dp,low,ll-1,k);
        }else{
            FindKth(dp,ll+1,high,k- (ll+1-low));
        }
        
    }
    
    private void swap(int[] dp,int i,int j){
        int t = dp[i];
        dp[i] = dp[j];
        dp[j] = t;
    }
}