public class Solution {
    public IList<IList<string>> FindDuplicate(string[] paths) {
        var mapping = new Dictionary<string,IList<string>>();
        
        foreach(var item in paths){
            var arr = item.Split(new char[]{' '});
            
            var dir = arr[0];
            
            for(var i = arr.Length-1;i>0;i--){
                var f = arr[i];
                var content = f.Substring(f.LastIndexOf('(')+1);
                content = content.Substring(0,content.Length-1);
                
                var fname = f.Substring(0,f.LastIndexOf('('));
                if(!mapping.ContainsKey(content))
                    mapping[content] = new List<string>();
                mapping[content].Add(dir+"/"+fname);
            }
        }
        
        return mapping.Values.Where(x=>x.Count > 1).ToList();
    }
}