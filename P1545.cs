public class Solution {
    public char FindKthBit(int n, int k) {
        var len = 1;
        
        while(len < k){
            len = len * 2 +1;
        }
        var b = 0;
        var result = 0;
        
        while(len > 1){
            var mid = len/2+1;
            if(mid == k){
                result = 1;
                break;
            }else if(mid < k)
            {
                k = mid- (k-mid);
                b++;
            }
            
            len/=2;
        }
        
        if( b % 2 == 0)
            return result == 0 ? '0' : '1';
        else
            return result == 0 ? '1' : '0';
    }
}