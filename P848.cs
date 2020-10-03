public class Solution {
    public string ShiftingLetters(string S, int[] shifts) {
        var len = S.Length;
        
        long current = 0;
        var arr = S.ToCharArray();
        
        for(int i = len-1;i>=0;i--){
            current += shifts[i];
            current %= 26;
            var c = (char)(arr[i] + current);
            
            if(c > 'z')
                c = (char)('a' + (c-'z')-1);
            arr[i]= c;
        }
        
        return string.Join("",arr);
    }
}