public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        people = people.OrderBy(x=>x).ToArray();
        
        var low = 0;
        var high = people.Length-1;
        
        var result = 0;
        
        while(low <= high){
            if(people[low] + people[high] <= limit){
                result++;
                low++;
                high--;
            }else if(people[low]+people[high] > limit){
                result++;
                
                if(low == high)
                    break;
                high--;
            }
        }
        
        return result;
    }
}