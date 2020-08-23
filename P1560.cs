public class Solution {
    public IList<int> MostVisited(int n, int[] rounds) {
        
        var result = new List<int>();
        var min = rounds.First();
        var max =rounds.Last();
        if(max >= min){
            for(var i = min;i<=max;i++)
            {
                result.Add(i);
            }
        }else{
            for(var i = 1;i<=max;i++)
            {
                result.Add(i);
            }
            for(var i = min;i<=n;i++)
            {
                result.Add(i);
            }
        }
        
        return result;
    }
}