public class Solution {
    public int MaxDiff(int num) {
        int result = 0;
        
        var len = (num+"").Length;
        
        var max = 0;
        var min = num;
        
        for(int i = 0;i<=9;i++){
            for(int j = 0;j<=9;j++){
                
                var num1 = Helper(num,i,j);
                
                if($"{num1}".Length !=len|| num1 == 0)
                    continue;
                
                max = Math.Max(max,num1);
                min = Math.Min(min,num1);
                
            }
        }
        
        return max-min;
    }
    
    private int Helper(int num,int i,int j){
        return int.Parse($"{num}".Replace(""+i,""+j));
    }
}



>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public int MaxDiff(int num) {
        if(num < 10)
            return 8;
        
        var str = num+"";
        var max = num;
        var min = num;
        
        foreach(var c in str){
            if(c != '9'){
                max = Helper(str,c,'9');
                break;
            }
        }
        
        if(str[0] != '1'){
            min = Helper(str,str[0], '1'); 
        }else{
            for(int i = 1;i<str.Length;i++){
                if(str[i] != str[0] && str[i] != '0'){
                    min = Helper(str,str[i], '0');
                    break;
                }
            }

        }
        
        return max-min;
    }
    
    private int Helper(string num,char i,char j){
        return int.Parse(num.Replace(i,j));
    }
}