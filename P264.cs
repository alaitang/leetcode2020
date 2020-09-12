public class Solution {
    public int NthUglyNumber(int n) {
        if(n == 1)
            return 1;
        
        var n2 = 0;
        var n3 = 0;
        var n5 = 0;
        n--;
        
        var list = new List<int>(){1};
        
        var result = 0;
        
        while(n > 0){
            var next2 = list[n2] * 2;
            var next3 = list[n3] * 3;
            var next5 = list[n5] * 5;
            
            var min = Math.Min(next2,Math.Min(next3,next5));
            
            if(min == list[n2] * 2){
                n2++;
            }
            if(min == list[n3] * 3){
                n3++;
            }
            if(min == list[n5] * 5){
                n5++;
            }
            
            result = min;
            
            list.Add(min);
            
            n--;
        }
        
        return result;
    }
}