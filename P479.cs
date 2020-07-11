public class Solution {
    public int LargestPalindrome(int n) {
        
        if (n==1) return 9;
        int max=(int)Math.Pow(10, n)-1;
        for (int v=max-1;v>max/10;v--) {
            long u=long.Parse(v+new string(v.ToString().Reverse().ToArray()));
            for (long x=max;x*x>=u;x--)
                if (u%x==0)
                    return (int)(u%1337);
        }
        return 0;
    }
}