public class Solution {
    public bool CanIWin(int maxChoosableInteger, int desiredTotal) {
        
        if(maxChoosableInteger >= desiredTotal)
            return true;
        
        if((1+maxChoosableInteger)*maxChoosableInteger/2 <  desiredTotal)
            return false;
        
        
        return Helper(maxChoosableInteger,0,desiredTotal,0,new HashSet<int>());
    }
    
    private bool Helper(int maxChoosableInteger,int total,int desiredTotal, int current, 
                        HashSet<int> visited){
        
        if(visited.Contains(current))
            return false;
        
        for(int i = 1;i<=maxChoosableInteger;i++){
            if((current & (1 << i)) == 0 &&
               (total+i >= desiredTotal ||
               !Helper(maxChoosableInteger, total+i,desiredTotal , (current | (1 << i)), visited )) ){
                return true;
            }
            
        }
        
        visited.Add(current);
        
        return false;
        
    }
}