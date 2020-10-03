public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        var rightSum = 0;
        var len = cardPoints.Length;
        for(int i = len-1;i>=len-k;i--){
            rightSum += cardPoints[i];
        }
        
        var result = rightSum;
        var current = rightSum;
        var right = len-k;
        for(int i = 0;i<k;i++){
            current -= cardPoints[right++];
            current += cardPoints[i];
            result = Math.Max(current,result);
        }
        
        return result;
    }
}