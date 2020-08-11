public class Solution {
    public int[] MaxDepthAfterSplit(string seq) {
        var list = new List<int>();
        var n = 0;
        foreach(var c in seq){
            if(c == '(')
            {
                n++;
                list.Add(n%2);
            }else{
                list.Add(n%2);
                n--;
            }
        }
        
        return list.ToArray();
    }
}