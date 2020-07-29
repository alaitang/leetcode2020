public class Solution {
    public int FindBestValue(int[] arr, int target) {
        var list  = arr.OrderBy(x=>x).ToList();
        var len = arr.Length;
        var dp = new int[len];
        
        for(int i = 0 ;i<len;i++)
        {
            dp[i] = list[i] + (i==0?0:dp[i-1]);
        }
        
        var low = 0;
        var high = list.Last();
        
        while(low < high-1){
            var mid = (low+high)/2;
            
            var v = Helper(list,dp,mid,len);
            
        //Console.WriteLine($"{mid},{v}");
            if(v == target)
                return mid;
            else if(v < target)
                low = mid;
            else
                high = mid;
        }
        
        var v1 = Helper(list,dp,low,len);
        var v2 = Helper(list,dp,high,len);
        //Console.WriteLine($"{low},{high},{v1},{v2}");
        
        if(Math.Abs(v1-target) <= Math.Abs(v2-target))
            return low;
        else
            return high;
    }
    
    public int Helper(List<int> arr,int[] dp,int v,int len){
        var index = arr.BinarySearch(v);
        
        if(index < 0)
            index = ~index;
        
        while(index < len && arr[index] <= v){
            index++;
        }
        
        
        
        return (index == 0? 0:dp[index-1]) + v * (len-index);
        
    }
}