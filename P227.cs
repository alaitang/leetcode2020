/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    public int FindCelebrity(int n) {
        var result = 0;
        
        for(int i = 1;i<n;i++){
            if(!Knows(i,result)){
                result = i;
            }
        }
        
        for(int i = 0;i<n;i++){
            if(i != result && (!Knows(i,result) || Knows(result,i)) )
                return -1;
        }
        
        return result;
    }
}