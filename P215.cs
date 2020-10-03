public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        Helper(nums,0,nums.Length-1,k);
        
        return nums[k-1];
    }
    
    private void Helper(int[] nums,int low,int high,int k){
        if(low >= high)
            return;
        
        var ii = low;
        
        for(int i = low+1;i<=high;i++){
            if(nums[i] >= nums[low])
                Swap(nums,i,++ii);
        }
        
        Swap(nums,low,ii);
        
        if(ii-low+1 == k)
            return;
        else if(ii - low +1 > k){
            Helper(nums,low,ii-1,k);
        }else
            Helper(nums,ii+1,high,k-(ii-low+1));
    }
    
    private void Swap(int[] nums,int i, int j){
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}