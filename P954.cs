public class Solution {
    public bool CanReorderDoubled(int[] A) {
        A = A.OrderBy(x=>Math.Abs(x)).ToArray();
        var mapping = new Dictionary<int,int>();
        foreach(var item in A){
            if(mapping.ContainsKey(item) && mapping[item] != 0)
                mapping[item]--;
            else{
                if(!mapping.ContainsKey(item*2))
                    mapping[item*2] = 0;
                mapping[item*2]++;
            }
        }
        
        //Console.WriteLine(string.Join(" , ",mapping.Select(x=>$"[{x.Key},{x.Value}]")));
        
        return mapping.Values.All(x=>x==0);
    }
}