public class Solution {
    public int MinOperations(int n) {
        if(n == 1)
            return 0;
        if(n % 2 == 0){
            n = n/2;
            return (1+(n*2)-1)*(n)/2;
        } else{
            n = n/2;
            return (2+2*n)*n/2;
        }
    }
}