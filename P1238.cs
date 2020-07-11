public class Solution {
    public IList<int> CircularPermutation(int n, int start) {
        if(n == 1)
        {
            if(start == 0)
                return new List<int>(){0,1};
            else
                return new List<int>(){1,0};
        }else{
            var result = new List<int>{0,1};
            var b = 2;
            for(int i = 0;i<n-1;i++){
                var half = result.Count/2;
                
                for(int j = half;j>=1;j--){
                    result.Insert(half,result[result.Count-j]^b);
                }
                
                for(int j = 0;j<half;j++)
                {
                    result.Insert(half,result[j]^b);
                }
                b*=2;
            }
            
            
            //Console.WriteLine(string.Join("\n",result.Select(x=>Convert.ToString(x,2).PadLeft(n,'0'))));
            while(result[0] != start){
                result.Add(result[0]);
                result.RemoveAt(0);
            }
            
            //Console.WriteLine("\n\n\n");
            //Console.WriteLine(string.Join("\n",result.Select(x=>Convert.ToString(x,2).PadLeft(n,'0'))));
            
            return result;
        }
    }
}


 public List<Integer> circularPermutation(int n, int start) {
        List<Integer> res = new ArrayList<>();
        for (int i = 0; i < 1 << n; ++i)
            res.add(start ^ i ^ i >> 1);
        return res;
    }