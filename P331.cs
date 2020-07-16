public class Solution {
    public bool IsValidSerialization(string preorder) {
        if(preorder == "")
            return true;
        
        var arr = preorder.Split(new char[]{','});
        
        var n = 1;
        
        foreach(var item in arr){
            if(item == "#")
                n--;
            else if(n == 0)
                return false;
            else{
                n+=1;
            }
        }
        
        return n == 0;
    }
}