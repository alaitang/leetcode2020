public class Solution {
    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild) {
        var visited = new bool[n];
        var heads = new int[n];
        for(int i = 0;i<n;i++)
            heads[i] = i;
        
        for(int i = 0;i<n;i++){
            var hi = FindHead(heads,i);
            if(leftChild[i] != -1){
                if(visited[leftChild[i]] || FindHead(heads,leftChild[i]) == hi)
                    return false;
                visited[leftChild[i]] = true;
                heads[leftChild[i]] = i;
            }
            
            
            if(rightChild[i] != -1){
                if(visited[rightChild[i]] ||  FindHead(heads,rightChild[i]) == hi)
                    return false;
                visited[rightChild[i]] = true;
                heads[rightChild[i]] = i;
            }
        }
        
        var t = 0;
        
        for(int i = 0;i<n;i++)
        {
            if(heads[i] == i)
                t++;
        }
        
        return t == 1;
        
    }
    
    private int FindHead(int[] heads,int n){
        if(heads[n] == n)
            return n;
        
        return FindHead(heads,heads[n]);
    }
}