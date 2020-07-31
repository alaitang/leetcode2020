public class Solution {
    public int Clumsy(int N) {
        
        if(N == 1)
            return 1;
        else if(N == 2)
            return 2;
        else if(N == 3)
            return 6;
        
        int result = 0;
        
        var index = 0;
        
        for(int i = N;i>=1;i-=4){
            if(i >= 4){
                if(i == N){
                    result = i*(i-1)/(i-2)+i-3;
                }else{
                    result = result - i*(i-1)/(i-2)+i-3;
                }
            }else if(i == 3){
                result -= 6;
            }else if(i==2){
                result -= 2;
            }else{
                result--;
            }
        }
        
        return result;
    }
}



public class Solution {
    public int Clumsy(int N) {
        
        if (N == 1) return 1;
        if (N == 2) return 2;
        if (N == 3) return 6;
        if (N == 4) return 7;
        if (N % 4 == 1) return N + 2;
        if (N % 4 == 2) return N + 2;
        if (N % 4 == 3) return N - 1;
        return N + 1;
    }
}