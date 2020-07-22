public class Solution {
    public IList<int> PathInZigZagTree(int label) {
        var level = 1;
        while(Math.Pow(2,level-1) <= label){
            level++;
        }
        
        level--;
        var p = label;
        if(level % 2 == 0){
             p = (int)(Math.Pow(2,level)-1 - (label-Math.Pow(2,level-1)));
        }
        //Console.WriteLine(level+","+p);
        var result = new List<int>(){label};
        
        p/=2;
        level--;
        while(level > 0){
            var v = p;
            if(level % 2 == 0){
                v = (int)(Math.Pow(2,level)-1 - (p-Math.Pow(2,level-1)));
            }
            
            result.Insert(0,v);
            p/=2;
            level--;
        }
        
        return result;
    }
    
}