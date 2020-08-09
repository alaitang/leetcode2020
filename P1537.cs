public class Solution {
    public int MaxSum(int[] nums1, int[] nums2) {
        var i = nums1.Length-1;
        var j = nums2.Length-1;
        
        long max1 = 0;
        long max2 = 0;
        
        while(i>=0 || j >=0){
            if(i >=0 && j >=0){
                if(nums1[i] == nums2[j]){
                    max1 = Math.Max(max1,max2)+nums1[i];
                    max2 = max1;
                    i--;
                    j--;
                }else if(nums1[i] > nums2[j]){
                    max1+=nums1[i--];
                }else{
                    max2+=nums2[j--];
                }
            }else if(i >=0 ){
                max1+=nums1[i--];
            }else{
                max2+= nums2[j--];
            }
        }
        
        return (int)(Math.Max(max1,max2)%1000000007 );
    }
}