public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        var index = arr.ToList().BinarySearch(x);
        var len = arr.Length;
        if(index < 0)
            index = ~index;
        
        if(index >= len){
            index--;
        }
        
        
        var result = new List<int>();
        
        var low = index-1;
        var high = index;
        
        while(k>0){
            if(low < 0 || high < len && Math.Abs(arr[low]-x) > Math.Abs(arr[high]-x) ){
                result.Add(arr[high++]);
            }else{
                result.Insert(0,arr[low--]);
            }
            k--;
        }
        
        return result;
    }
}