public class Solution {
    public IList<string> AmbiguousCoordinates(string S) {
        var result = new List<string>();
        S = S.Substring(1,S.Length-2);
        var len = S.Length;
        
        for(int i = 1;i<len;i++){
            var leftR = Helper(S.Substring(0,i));
            var rightR = Helper(S.Substring(i));
            
            foreach(var l in leftR){
                foreach(var r in rightR){
                    result.Add($"({l}, {r})");
                }
            }
        }
        
        return result;
    }
    
    private List<string> Helper(string str){
        var result = new List<string>();
        if(decimal.Parse(str).ToString() == str)
            result.Add(str);
        
        var len = str.Length;
        var list = str.ToList();
        for(int i = len-1;i>0;i--){
        
            if(i < len-1 && list[len-1] == '0')
                break;
            list.Insert(i,'.');
            var ss = string.Join("",list);
            var ps = decimal.Parse(ss);
            if(ps == Math.Round(ps))
                ps = Math.Round(ps);
            if(ps.ToString() == ss)
                result.Add(ss);
            list.RemoveAt(i);
        }
        return result;
    }
}