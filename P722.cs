public class Solution {
    public IList<string> RemoveComments(string[] source) {
        var isopen = false;
        var result = new List<string>();
        
        var sb= new StringBuilder();
        var ss = "";
        foreach(var s in source){
            var len = s.Length;
            
            for(int i = 0;i<len;i++){
                if(!isopen && s[i] == '/' && i+1 < len && s[i+1] == '*'){
                    isopen = true;
                    i++;
                }else if(isopen && s[i] == '*' && i+1 < len && s[i+1] == '/'){
                    isopen = false;
                    i++;
                }else if(!isopen && s[i] == '/' && i+1 < len && s[i+1] == '/'){
                    break;
                }else if(!isopen){
                    sb.Append(s[i]);
                }
            }
            if(!isopen){
                ss = sb.ToString();

                if(ss != "")
                    result.Add(ss);
                sb = new StringBuilder();
            }
        }
                ss = sb.ToString();

                if(ss != "")
                    result.Add(ss);
        
        
        return result;
    }
}