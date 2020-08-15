public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        var mapping = new Dictionary<string,List<string>>();
        
        foreach(var t in tickets){
            if(!mapping.ContainsKey(t[0]))
                mapping[t[0]] = new List<string>();
            var index = mapping[t[0]].BinarySearch(t[1]);
            if(index < 0)
                index = ~index;
            mapping[t[0]].Insert(index,t[1]);
        }
        
        var result = new List<string>(){"JFK"};
        
        Helper("JFK",mapping,tickets.Count,result);
        
        return result;
        
    }
    
    private bool Helper(string start, Dictionary<string,List<string>> mapping, int t, List<string> result){
        if(t == 0)
            return true;
        
        if(!mapping.ContainsKey(start) || mapping[start].Count == 0)
            return false;
        
        var len = mapping[start].Count;
        
        for(int i = 0;i<len;i++){
            var end = mapping[start][i];
            if(i > 0 && end == mapping[start][i-1])
                continue;
            result.Add(end);
            mapping[start].RemoveAt(i);
            if(Helper(end,mapping,t-1,result))
                return true;
            
            mapping[start].Insert(i,end);
            result.RemoveAt(result.Count-1);
        }
        
        return false;
    }
}