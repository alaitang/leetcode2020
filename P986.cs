public class Solution {
    public int[][] IntervalIntersection(int[][] A, int[][] B) {
        var len1 = A.Length;
        var len2 = B.Length;
        
        var i = 0;
        var j = 0;
        
        var result = new List<int[]>();
        
        while(i < len1 && j < len2){
            if(!(A[i][0] > B[j][1] || A[i][1] < B[j][0])){
                result.Add(new int[]{Math.Max(A[i][0],B[j][0]) , Math.Min(A[i][1],B[j][1]) });
            }
            
            if(A[i][1] <= B[j][1])
                i++;
            else
                j++;
        }
        
        return result.ToArray();
    }
}