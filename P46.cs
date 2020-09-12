public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        var len = 0;
        foreach(var n in nums){
            if(result.Count == 0){
                result.Add(new List<int>(){n});
            }else{
                var newResult = new List<IList<int>>();
                
                foreach(var r in result){
                    for(int i = 0;i<=len;i++){
                        var newR = r.ToList();
                        
                        newR.Insert(i,n);
                        
                        newResult.Add(newR);
                    }
                }
                
                result = newResult;
            }
            len++;
        }
        
        return result;
    }
}