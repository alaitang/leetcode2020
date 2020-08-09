public class RangeModule {

    List<int[]> list = new List<int[]>();
    
    public RangeModule() {
        
    }
    
    public void AddRange(int left, int right) {
        //Console.Write($"Add : [{left}, {right-1}] in ");
        var v = new int[]{left,right-1};
        var index = list.BinarySearch(v,Comparer<int[]>.Create((a,b)=>{
            return a[0]-b[0];
        }));
        if(index < 0)
            index = ~index;
        index--;
        var len = list.Count;
        
        for(int i = index;i<len;i++){
             if(i < 0 || list[i][1] < v[0]-1){
                continue;
            }else if(list[i][0] > v[1]+1){
                list.Insert(i,v);
                 
            //Console.WriteLine(string.Join(" , ",list.Select(x=>$"[{x[0]},{x[1]}]")));
                return;
            }else{
                v[0] = Math.Min(v[0],list[i][0]);
                v[1] = Math.Max(v[1],list[i][1]);
                list.RemoveAt(i);
                len--;
                i--;
            }
        }
        
        list.Add(v);
        
        //Console.WriteLine(string.Join(" , ",list.Select(x=>$"[{x[0]},{x[1]}]")));
    }
    
    public bool QueryRange(int left, int right) {
        //Console.Write($"query : [{left}, {right-1}] in ");
        var v = new int[]{left,right-1};
        var index = list.BinarySearch(v,Comparer<int[]>.Create((a,b)=>{
            return a[0]-b[0];
        }));
        if(index < 0)
            index = ~index;
        index--;
        
        //Console.WriteLine(string.Join(" , ",list.Select(x=>$"[{x[0]},{x[1]}]")));
        
        
        return 0 <= index && index < list.Count && list[index][0] <= left && right-1 <= list[index][1] || 
         index+1 < list.Count && list[index+1][0] <= left && right-1 <= list[index+1][1];
    }
    
    public void RemoveRange(int left, int right) {
        //Console.Write($"Remove : [{left}, {right-1}] in ");
        
        var v = new int[]{left,right-1};
        var index = list.BinarySearch(v,Comparer<int[]>.Create((a,b)=>{
            return a[0]-b[0];
        }));
        if(index < 0)
            index = ~index;
        index--;
        var len = list.Count;
        
        for(int i = index;i<len;i++){
            if(i < 0 || list[i][1] < v[0]){
                continue;
            }else if(list[i][0] > v[1]){
                
            //Console.WriteLine(string.Join(" , ",list.Select(x=>$"[{x[0]},{x[1]}]")));
                return;
            }else{
                if(v[0] <= list[i][0] && list[i][1] <= v[1]){
                    list.RemoveAt(i);
                    len--;
                    i--;
                }else if(list[i][0] < v[0] && list[i][1] <= v[1]){
                    list[i][1] = v[0]-1;
                }else if(v[0] <= list[i][0] && v[1] < list[i][1]){
                    list[i][0] = v[1]+1;
                }else{
                    list.Insert(i+1,new int[]{v[1]+1,list[i][1]});
                    list[i][1] = v[0]-1;
                }
            }
        }
        
        //Console.WriteLine(string.Join(" , ",list.Select(x=>$"[{x[0]},{x[1]}]")));
    }
    
    
}

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.AddRange(left,right);
 * bool param_2 = obj.QueryRange(left,right);
 * obj.RemoveRange(left,right);
 */