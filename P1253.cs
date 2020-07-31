public class Solution {
    public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum) {
        var result = new List<IList<int>>(){new List<int>(),new List<int>()};
        
        var cols = colsum.Length;
        
        for(int i = 0;i<cols;i++){
            if(colsum[i] == 0){
                result[0].Add(0);
                result[1].Add(0);
            }else if(colsum[i] == 2){
                if(upper <= 0 || lower <= 0)
                    return  new List<IList<int>>();
                result[0].Add(1);
                result[1].Add(1);
                upper--;
                lower--;
            }else{
                if(upper > 0 && upper >= lower ){
                    result[0].Add(1);
                    result[1].Add(0);
                    upper--;
                }else if(lower > 0 && upper <= lower ){
                    result[0].Add(0);
                    result[1].Add(1);
                    lower--;
                }else{
                    return  new List<IList<int>>();
                }
            }
        }
        
        if(lower !=0 || upper != 0)
            return  new List<IList<int>>();
        return result;
        
    }
}