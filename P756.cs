public class Solution {
    HashSet<string> visited = new HashSet<string>();
    
    public bool PyramidTransition(string bottom, IList<string> allowed) {
        
        
        var mapping = new Dictionary<string,List<char>>();
        foreach(var item in allowed){
            if(!mapping.ContainsKey($"{item[0]}{item[1]}"))
                mapping[$"{item[0]}{item[1]}"] = new List<char>();
            
            mapping[$"{item[0]}{item[1]}"].Add(item[2]);
        }
        
        
        return Helper(bottom,mapping);
    }
    
    private bool Helper(string bottom, Dictionary<string,List<char>> mapping){
        //Console.WriteLine(bottom);
        if(bottom.Length <= 1)
            return true;
        
        if(!visited.Add(bottom))
            return false;
        var len = bottom.Length;
        
        return Helper(bottom,0,len,mapping,new StringBuilder());
    }
    
    private bool Helper(string bottom, int index,int len, Dictionary<string,List<char>> mapping,StringBuilder sb){
        //Console.WriteLine(sb.ToString());
        if(index == len-1 )
        {
            return Helper(sb.ToString(),mapping);
        }
        
        if(mapping.ContainsKey($"{bottom[index]}{bottom[index+1]}")){
            foreach(var c in mapping[$"{bottom[index]}{bottom[index+1]}"]){
                sb.Append(c);
                if(Helper(bottom,index+1,len,mapping,sb))
                    return true;
                sb.Length--;
            } 
        }
        
        return false;
    }
    
    
}