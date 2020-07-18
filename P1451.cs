public class Solution {
    public string ArrangeWords(string text) {
        if(text == "")
            return text;
        var str = string.Join(" ",text.Split(new char[]{' '}).OrderBy(x=>x.Length)).ToLower();
        
        
        str = (str[0]+"").ToUpper() + str.Substring(1);
        
        return str;
    }
}