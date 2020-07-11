public class Solution {
    public bool CheckStraightLine(int[][] p) {
        var len = p.Length;
        
        if(len <= 2)
            return true;
        double pp = double.MinValue;
        if(p[0][0] != p[1][0] )
            pp = (p[1][1]-p[0][1])*1.0/(p[1][0]-p[0][0]);
        
        for(int i = 2;i<len;i++){
            
            if(p[0][0] == p[i][0]){
                if(p[0][0] != p[1][0])
                    return false;
            }else if( (p[i][1]-p[0][1])*1.0/(p[i][0]-p[0][0]) != pp)
                return false;
                
        }
        
        return true;
    }
}