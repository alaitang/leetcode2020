public class Solution {
    public int MaxDistance(int[] position, int m) {
        long low = 1;
        long high = position.Max();
        
        position = position.OrderBy(x=>x).ToArray();
        
        while(low < high-1){
            long mid = (low+high)/2;
            
            
            if(!Helper(position,m,mid)){
                high = mid;
            }else{
                low = mid;
            }
        }
        
        if(Helper(position,m,high))
            return (int)high;
        else
            return (int)low;
    }
    
    private bool Helper(int[] position,int t,long mid){
        long p = int.MinValue;
        
        foreach(long item in position){
            if(item-p >= mid){
                t--;
                p = item;
            }

            if(t == 0)
                return true;
        }
        
        return false;
    }
}