public class Solution {
    public IList<IList<string>> DisplayTable(IList<IList<string>> orders) {
        var mapping = new Dictionary<int,Dictionary<string,int>>();
        var foods = new HashSet<string>();
        foreach(var item in orders){
            var table = int.Parse(item[1]);
            
            var food = item[2];
            
            if(!mapping.ContainsKey(table))
                mapping[table] = new Dictionary<string,int>();
            
            if(!mapping[table].ContainsKey(food))
                mapping[table][food] = 0;
            mapping[table][food]++;
            foods.Add(food);
        }
        
        var foodList = foods.OrderBy(x=>string.Join("",x.Select(c=>((int)c+"").PadLeft(3,'0')  ))).ToList();;
        var tables = mapping.Keys.OrderBy(x=>x).ToList();
        var head = new List<string>(){"Table"};
        head.AddRange(foodList);
        
        var result = new List<IList<string>>(){head};
        
        foreach(var t in tables){
            var r  = new List<string>(){t+""};
            
            foreach(var food in foodList){
                if(mapping[t].ContainsKey(food)){
                    r.Add(mapping[t][food]+"");
                }else{
                    r.Add("0");
                }
            }
            
            result.Add(r);
            
        }
        
        return result;
    }
}