public class Solution {
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        var result = new HashSet<int>();
        for(int i = 0;i<n;i++)
            result.Add(i);
        
        foreach(var edge in edges){
            result.Remove(edge[1]);
        }
        return result.ToList();
    }
    
}