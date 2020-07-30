
public class Solution {
    public int MinMoves2(int[] nums) {
        var len = nums.Length;
        var mid = len/2 + (len%2 == 0 ? 0: 1);
        FindN(nums,0,len-1,mid);
        //Console.WriteLine(string.Join(",",nums));
        var result = 0;
        for(int i = 0;i<len;i++)
            result += Math.Abs(nums[i]-nums[mid-1]);
        
        return result;
    }
    
    private void FindN(int[] nums,int low,int high,int k){
        if(low >= high)
            return;
        
        var index= low;
        
        for(int i = low+1;i<=high;i++){
            if(nums[i] <= nums[low])
            {
                swap(nums,i,++index);
            }
        }
        
        swap(nums,low,index);
        
        if(index-low+1 == k)
            return;
        else if(index-low+1 < k){
            FindN(nums,index+1,high,k-(index-low+1));
        }else
            FindN(nums,low,index-1,k);
    }
    
    private void swap(int[] nums,int i,int j){
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public int MinMoves2(int[] nums) {
        nums = nums.OrderBy(x=>x).ToArray();
        
        var low = 0;
        var high = nums.Length-1;
        var result = 0;
        while(low < high){
            result += nums[high--]-nums[low++];
        }
        
        return result;
    }
}