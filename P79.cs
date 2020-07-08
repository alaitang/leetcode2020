public class Solution {
    public bool Exist(char[][] board, string word) {
        
        var rows = board.Length;
        var cols = board[0].Length;
        
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
            
                if(Helper(board,i,j,rows,cols,word,0,new HashSet<int>()))
                    return true;
                
            }
        }
        return false;
    }
    
    private bool Helper(char[][] board,int i,int j,int rows,int cols,string word,int index,HashSet<int> visited){
        if(index >= word.Length)
            return true;
        if(i >= rows || j >= cols || i < 0 || j <0 || board[i][j] != word[index] || !visited.Add(i*cols+j))
            return false;
            
        var r = Helper(board,i+1,j,rows,cols,word,index+1,visited)
            || Helper(board,i-1,j,rows,cols,word,index+1,visited)
            || Helper(board,i,j-1,rows,cols,word,index+1,visited)
            || Helper(board,i,j+1,rows,cols,word,index+1,visited);
        
        visited.Remove(i*cols+j);
        
        return r;
        
    }
}
