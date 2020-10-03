public class Solution {
    public int NumDecodings(string s) {
        
        long s2 = 1;
        long s1 = 0;
        
        if(s[0] == '0')
            return 0;
        else if(s[0] == '*'){
            s1 = 9;
        }else{
            s1 = 1;
        }
        
        var len = s.Length;
        
        
        for(int i = 1;i<len;i++){
            long nexts1 = 0;
            long nexts2 = 0;
            if(s[i] == '0'){
                if(s[i-1] == '1' || s[i-1] == '2'){
                    nexts1 = s2;
                }else if(s[i-1] == '*'){
                    nexts1 = s2 * 2;
                }
            }else if(s[i] == '*'){
                nexts1 = s1 * 9;
                if(s[i-1] == '*'){
                    nexts1 += s2 * 15;
                }else if(s[i-1] == '1'){
                    nexts1 += s2 * 9;
                }else if(s[i-1] == '2'){
                    nexts1 += s2 * 6;
                }
            }else{
                nexts1 = s1;
                if(s[i-1] == '*'){
                    nexts1 += s2;
                    if(s[i] <= '6')
                        nexts1 += s2;
                }else if(s[i-1] == '1'){
                    nexts1 += s2;
                }else if(s[i-1] == '2' && s[i] <= '6'){
                    nexts1 += s2;
                }
            }
            
            s2 = s1;
            s1 = nexts1 % 1000000007;
            
            //Console.WriteLine(s1+","+s2);
        }
        
        return (int)s1;
        
    }
}