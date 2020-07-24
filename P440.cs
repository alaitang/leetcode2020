public class Solution {
    public int FindKthNumber(int n, int k) {
        long result = 0;
        
        while(result <= n){
            
            for(int i = 0;i<=9;i++){
                if(result == 0 && i == 0)
                    continue;
                var r = Helper(result*10+i,n);
                
                //Console.WriteLine("start with : "+ (result*10+i) + " contains "+r);
                
                if(r < k){
                    k-=r;
                }
                else{
                    result = result*10+i;
                    if(k == 1)
                        return (int)result;
                    k--;
                    //Console.WriteLine("loop end : "+result + ","+k);
                    break;
                }
            }
        }
        return (int)result;
    }
    
    private int Helper(long start,int max){
        if(start > max)
            return 0;
        long result = 0;
        long b = 1;
        while((start+1) * b <= max){
            result += (start+1) * b-start*b;
            b*=10;
        }
        
        if(max >= start*b)
            result += max-start*b+1;
        
        return (int)result;
        
    }
}