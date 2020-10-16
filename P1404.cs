public class Solution {
    public int NumSteps(string s) {
        var list = s.Select(x=>x-'0').ToList();
        var result = 0;
        while(list.Count > 1){
            result++;
            if(list.Last() == 1){
                var add = 1;
                for(int i = list.Count-1;i>=0 && add == 1;i--){
                    list[i]++;
                    if(list[i] == 2){
                        list[i] = 0;
                    }else{
                        add = 0;
                        break;
                    }
                }
                if(add == 1)
                    list.Insert(0,1);
            }else{
                list.RemoveAt(list.Count-1);
            }
        }
        
        return result;
        
    }
}