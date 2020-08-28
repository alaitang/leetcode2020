public class Solution {
    public int ThreeSumMulti(int[] A, int target) {
        var max = A.Max();
        var m = new long[max+1];
        foreach(var a in A){
            m[a]++;
        }
        long result = 0;
        var M = 1000000007;
        for(int i = 0;i<=max;i++)
        {
            if(m[i] >= 3 && i+i+i == target)
            {
              result += m[i]*(m[i]-1)*(m[i]-2) / 6;
                    result %= M;
                //Console.WriteLine(i+"->" + (m[i]*(m[i]-1)*(m[i]-2) / 6));
            }else if(m[i] >= 2 &&target-i-i != i  && target-i-i >=0 && target-i-i <= max && m[target-i-i] > 0){
              result += m[i]*(m[i]-1)*(m[target-i-i])/2;
                    result %= M;
                //Console.WriteLine(i+"-->" + (m[i]*(m[i]-1)*(m[target-i-i])/2));
            }
            
            for(int j = i+1;j<=max && (i+j) <= target;j++)
            {
                for(int k = j+1;k<=max && i+j+k <= target;k++)
                {
                    if(m[i] == 0 || m[j] ==0 || m[k] == 0 || i+j+k != target)
                        continue;
                    
                    result += m[i]*m[j]*m[k];
                    result %= M;
                }
            }
        }
        
        
        return (int)result;
    }
}