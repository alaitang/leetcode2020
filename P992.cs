public class Solution {
    public int SubarraysWithKDistinct(int[] A, int K) {
        var mapping = new Dictionary<int,int>();
        
        var len = A.Length;
        var low = 0;
        var list = new List<int>();
        var result = 0;
        for(int i = 0;i<len;i++)
        {
            if(!mapping.ContainsKey(A[i]))
                mapping[A[i]] = -1;
            var index = list.BinarySearch(mapping[A[i]]);
            if(index >= 0){
                list.RemoveAt(index);
            }
            list.Add(i);
            mapping[A[i]] = i;
            
            while(mapping.Count > K){
                if(mapping[A[low]] == low){
                    mapping.Remove(A[low]);
                    list.RemoveAt(0);
                }
                low++;
            }
            
            if(mapping.Count == K)
                result += list.First()-low+1;
        }
        
        return result;
    }
}