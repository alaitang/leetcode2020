public class Solution {
    public IList<int> GrayCode(int n) {
        if(n == 0)
            return new List<int>(){0};
        var result = new List<int>(){0,1};
        
        for(int i = 2;i<=n;i++){
            var mid = result.Count/2;
            
            var ii = mid-1;
            var b = 1 << (i-1);
            while(ii >=0){
                result.Insert(mid,result[result.Count-ii-1]|b);
                result.Insert(mid,result[ii]|b);
                mid++;
                ii--;
            }
        }
        
        return result;
    }
}