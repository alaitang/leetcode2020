public class Solution {
    public string Multiply(string num1, string num2) {
        var len1 = num1.Length;
        var len2 = num2.Length;
        
        var arr = new int[len1+len2];
        
        for(int i = 0;i<len1;i++)
        {
            for(int j = 0;j<len2;j++)
            {
                var r = (num1[len1-1-i] - '0') * (num2[len2-1-j] - '0');
                
                arr[len1+len2-1-i-j] += r;
            }
        }
        
        var add = 0;
        
        for(int i = len1+len2-1;i>=0;i--){
            arr[i]+=add;
            add = arr[i] / 10;
            arr[i] %= 10;
        }
        
        var result = add + string.Join("",arr);
        
        var index = 0 ;
        while(index < result.Length && result[index] == '0'){
            index++;
        }
        
        if(index >= result.Length)
            return "0";
        return result.Substring(index);
    }
}