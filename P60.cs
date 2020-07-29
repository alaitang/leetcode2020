public class Solution {
    public string GetPermutation(int n, int k) {
        
        var avg = 1;
        
        for(int i = 1;i<n;i++)
            avg *= i;
        var list = new List<int>();
        for(int i = 1;i<=n;i++)
            list.Add(i);
        var sb = new StringBuilder();
        while(list.Count > 1){
            var index = k/avg + (k%avg == 0? -1 :0);
            
            k-=avg*index;
            
            sb.Append(list[index]);
            
            list.RemoveAt(index);
            n--;
            if(n != 1)
                avg = avg/n;
        }
        
        sb.Append(list.Last());
        return sb.ToString();
        
    }
    
}