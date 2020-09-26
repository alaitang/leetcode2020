public class Solution {
    public int MaxDotProduct(int[] nums1, int[] nums2) {
        var len1 = nums1.Length;
        var len2 = nums2.Length;
        
        var dp = new int[len1,len2];
        
        for(int i = 0;i<len1;i++){
            for(int j = 0;j<len2;j++){
                dp[i,j] = nums1[i]*nums2[j];
                
                if(i-1 >=0 && j-1 >=0 ){
                    dp[i,j] += Math.Max(dp[i-1,j-1],0);
                }
            
            
                if(i-1 >=0 ){
                    dp[i,j] = Math.Max(dp[i-1,j],dp[i,j]);
                }
                if(j-1 >=0 ){
                    dp[i,j] = Math.Max(dp[i,j-1],dp[i,j]);
                }
            }
        }
        
        
        return dp[len1-1,len2-1];
    }
}