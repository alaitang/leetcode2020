public class Solution {
    public int LongestArithSeqLength(int[] A) {
        
        var len = A.Length;
        var result = 0;
        var mapping = new Dictionary<int,Dictionary<int,int>>();
        for(int i = 0 ;i<len;i++){
            mapping[i] = new Dictionary<int,int>();
            for(int j = i-1;j>=0;j--){
                
                var diff = A[i]-A[j];
                if(!mapping[i].ContainsKey(diff))
                    mapping[i][diff] = 0;
                
                if(mapping[j].ContainsKey(diff)){
                     mapping[i][diff] = Math.Max( mapping[i][diff],mapping[j][diff]+1);
                }else{
                     mapping[i][diff] = Math.Max( mapping[i][diff],2);
                }
                
                result = Math.Max( mapping[i][diff],result);
            }
        }
        
        return result;
    }
}