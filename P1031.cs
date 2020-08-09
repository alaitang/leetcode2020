public class Solution {
    public int MaxSumTwoNoOverlap(int[] A, int L, int M) {
        
        return Math.Max(Helper(A,L,M),Helper(A,M,L));
    }
    
    private int Helper(int[] A,int L,int M){
        
        var min = 0;
        var len = A.Length;
        var leftsum = 0;
        var rightsum = 0;
        var leftmax = 0;
        var result = 0;
        for(int i = 0;i<len;i++){
            if(i < L)
                leftsum+=A[i];
            else if(L<=i && i < L+M)
                rightsum+=A[i];
            else{
                leftsum-=A[i-L-M];
                leftsum+=A[i-M];
                
                rightsum+=A[i];
                rightsum-=A[i-M];
            }
            
            if(i >= L+M-1){
                leftmax = Math.Max(leftmax,leftsum);
                result = Math.Max(leftmax+rightsum,result);
            }
        }
        
        return result;
    }
}


>>>>>>>>>>>>>>>>>>>

public class Solution {
    public int MaxSumTwoNoOverlap(int[] A, int L, int M) {
        
        
        var len = A.Length;
        
        var leftsum = 0;
        var rightsum = 0;
        var leftmax = 0;
        
        var leftsum1 = 0;
        var rightsum1 = 0;
        var leftmax1 = 0;
        
        
        var result = 0;
        for(int i = 0;i<len;i++){
            if(i < L)
                leftsum+=A[i];
            else if(L<=i && i < L+M)
                rightsum+=A[i];
            else{
                leftsum-=A[i-L-M];
                leftsum+=A[i-M];
                
                rightsum+=A[i];
                rightsum-=A[i-M];
            }
            
            
            if(i < M)
                leftsum1+=A[i];
            else if(M<=i && i < L+M)
                rightsum1+=A[i];
            else{
                leftsum1-=A[i-L-M];
                leftsum1+=A[i-L];
                
                rightsum1+=A[i];
                rightsum1-=A[i-L];
            }
            
            if(i >= L+M-1){
                leftmax1 = Math.Max(leftmax1,leftsum1);
                leftmax = Math.Max(leftmax,leftsum);
                result = Math.Max(leftmax1+rightsum1,result);
                result = Math.Max(leftmax+rightsum,result);
            }
        }
        
        return result;
    }
}