public class Solution {
    public int NextGreaterElement(int n) {
        var s = (n+"").ToArray();
        
        var i = s.Length-2;
        
        while(i>=0 && s[i] >= s[i+1])
        {
            i--;
        }
        
        if(i < 0)
            return -1;
        
        var j = i+1;
        
        while(j<s.Length && s[i] < s[j]){
            j++;
        }
        
        j--;
        
        swap(s,i,j);
        
        i++;
        j = s.Length-1;
        
        while(j > i){
            swap(s,i,j);
            i++;
            j--;
        }
        
        var r = long.Parse(string.Join("",s));
        
        if(r <= int.MaxValue)
            return (int)r;
        
        return -1;
        
        
    }
    
    private void swap(char[] s,int i,int j){
        var t = s[i];
        s[i] = s[j];
        s[j] = t;
    }
}