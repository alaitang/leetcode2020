public class RLEIterator {
    private int[] A = null;
    private int index = 0;
    private int len = 0;
    public RLEIterator(int[] A) {
        this.A = A;
        len = A.Length;
        index = 0;
    }
    
    public int Next(int n) {
        while(index < len && A[index] < n){
            n-=A[index];
            A[index] = 0;
            index+=2;
        }
        
        if(index  >= len)
            return -1;
        else if(A[index] == n){
            var r = A[index+1];
            index+=2;
            return r;
        }else{
            var r = A[index+1];
             A[index] -= n;
            
            return r;
        }
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(A);
 * int param_1 = obj.Next(n);
 */