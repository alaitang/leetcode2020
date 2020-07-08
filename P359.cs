public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        var list = timePoints.Select(x=>{
            var arr = x.Split(new char[]{':'});
            return int.Parse(arr[0])*60+int.Parse(arr[1]);
        }).OrderBy(x=>x).ToList();
        var result = 24*60+list[0]-list.Last();
        for(int i = 1;i<timePoints.Count;i++){
            result = Math.Min(result,list[i]-list[i-1]);
        }
        
        return result;
    }
}

public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        var dp = new int[60*24];
        
        foreach(var item in timePoints){
            var arr = item.Split(new char[]{':'});
            var v =  int.Parse(arr[0])*60+int.Parse(arr[1]);;
            dp[v]++;
        }
        
        var p = -1;
        var first = -1;
        var result = 200000;
        for(int i = 0 ;i<24*60;i++){
            if(dp[i] > 1)
                return 0;
            else if(dp[i] == 1)
            {
                if(p == -1){
                    p = i;
                    first = i;
                }
                else{
                    result = Math.Min(result,i-p);
                    p = i;
                }
            }
        }
        
        result = Math.Min(result,first+24*60-p);
        
        return result;
    }
}