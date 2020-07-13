public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        var len = nums.Length;
        var list = new List<int>();
        for(int i = 0;i<len;i++){
            var sum = 0;
            for(int j = i;j>=0;j--){
                sum += nums[j];
                var index = list.BinarySearch(sum);
                if(index < 0)
                    index = ~index;
                
                list.Insert(index,sum);
                
                if(list.Count > right)
                    list.RemoveAt(right);
            }
        }
        //Console.WriteLine(string.Join(",",list));
        var result = 0;
        for(int i = right-1;i>=left-1;i--){
            result += list[i];
            result %= 1000000007;
        }
        
        return result;
    }
}