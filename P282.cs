public class Solution {
    public IList<string> AddOperators(string num, int target) {
        var result = new List<string>();
        
        Helper(num,0,num.Length,0,0,target, result,"");
        
        return result;
    }
    
    private void Helper(string num, int index,int len,long p,long current, int target, List<string> result, string c){
        if(index >= len){
            if(c != "" && current == target){
                result.Add(c.Substring(1));
            }
            return;
        }
        
        long n = 0;
        
        for(int i = index;i<len;i++){
            n = n*10 + (num[i]-'0');
            
            Helper(num, i+1,len, n,current+n,target, result, $"{c}+{n}");
            
            if(index != 0){
            
                Helper(num, i+1,len, -n,current-n,target, result, $"{c}-{n}");
                Helper(num, i+1,len, p*n,current-p+p*n,target, result, $"{c}*{n}");
            }
            
            if(num[index] == '0')
                break;
        }
    }
}