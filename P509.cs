public class Solution {
    public int Fib(int N) {
        if(N == 0)
            return 0;
        else if(N == 1)
            return 1;
        N-=2;
        var result = 1;
        var r1 = 0;
        while(N >=0){
            var n = result+r1;
            r1 = result;
            result = n;
            N--;
        }
        return result;
    }
}