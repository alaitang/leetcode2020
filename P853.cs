public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var len = speed.Length;
        var list = new List<int>();
        
        for(int i = 0;i<len;i++){
            list.Add(i);
        }
        
        list = list.OrderBy(x=>target-position[x]).ToList();
        
        
        double maxTime = 0;
        var result = len;
        
        for(int i = 0;i<len;i++){
            var arrived = (target-position[list[i]])*1.0/speed[list[i]];
            if(arrived <= maxTime){
                result--;
            }else{
                maxTime = arrived;
            }
        }
        
        return result;
    }
}