public class Solution {
    public IList<string> FindWords(char[][] board, string[] words) {
        var rows = board.Length;
        var cols = board[0].Length;
        
        var root = new TrieNode();
        
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                Helper(board,i,j,rows,cols,new HashSet<int>(),root);
            }
        }
        
        var result = new List<string>();
        foreach(var w in words){
            var current = root;
            var b = true;
            foreach(var c in w){
                if(current.children[c-'a'] == null)
                {
                    b = false;
                    break;
                }
                current = current.children[c-'a'];
            }
            
            if(b)
                result.Add(w);
        }
        
        return result;
    }
    
    private void Helper(char[][] board,int i,int j,int rows,int cols,HashSet<int> visited,TrieNode current){
        if(i < 0 || j <0 || i>=rows || j >= cols || !visited.Add(i*cols+j))
            return;
        
        if(current.children[board[i][j] - 'a'] == null)
            current.children[board[i][j] - 'a'] = new TrieNode();
        current = current.children[board[i][j] - 'a'];
        
        Helper(board,i+1,j,rows,cols,visited,current);
        Helper(board,i-1,j,rows,cols,visited,current);
        Helper(board,i,j+1,rows,cols,visited,current);
        Helper(board,i,j-1,rows,cols,visited,current);
        
        visited.Remove(i*cols+j);
        
        
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
}


public class Solution {
    public IList<string> FindWords(char[][] board, string[] words) {
        var rows = board.Length;
        var cols = board[0].Length;
        
        var root = new TrieNode();
        
        
        foreach(var w in words){
            var current = root;
            foreach(var c in w){
                if(current.children[c-'a'] == null)
                {
                    current.children[c-'a'] = new TrieNode();
                }
                current = current.children[c-'a'];
            }
            current.word = w;
        }
        
        var result = new List<string>();
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                Helper(board,i,j,rows,cols,new HashSet<int>(),root,result);
            }
        }
        
        
        return result;
    }
    
    private void Helper(char[][] board,int i,int j,int rows,int cols,HashSet<int> visited,TrieNode current,List<string> result){
        if(i < 0 || j <0 || i>=rows || j >= cols || current.children[board[i][j] - 'a'] == null || !visited.Add(i*cols+j))
            return;
        //Console.WriteLine($"{i},{j}");
        current = current.children[board[i][j] - 'a'];
        
        if(current.word != "")
        {
            result.Add(current.word);
            current.word = "";
        }
        
        
        Helper(board,i+1,j,rows,cols,visited,current,result);
        Helper(board,i-1,j,rows,cols,visited,current,result);
        Helper(board,i,j+1,rows,cols,visited,current,result);
        Helper(board,i,j-1,rows,cols,visited,current,result);
        
        visited.Remove(i*cols+j);
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
    public string word = "";
}