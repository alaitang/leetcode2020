public class Solution {
    public int[] CountBits(int num) {
        var result = new int[num+1];
        
        for(int i = 1;i<=num;i++){
            if(i%2 == 0){
                result[i] = result[i/2];
            }else{
                result[i] = result[i-1]+1;
            }
        }
        return result;
    }
}