public class Solution {
    public void Solve(char[][] board) {
        var rows = board.Length;
        if(rows == 0)
            return;
        var cols = board[0].Length;
        
        for(int i = 0;i<rows;i++)
        {
            for(int j = 0;j<cols;j++){
                if(board[i][j] == 'X')
                    continue;
                
                var visited = new HashSet<int>();
                
                var queue = new Queue<int>();
                visited.Add(i*cols+j);
                queue.Enqueue(i*cols+j);
                var isBound = false;
                while(queue.Any()){
                    var top = queue.Dequeue();
                    
                    var ii = top/cols;
                    var jj = top%cols;
                    
                    isBound |= Helper(ii+1,jj,rows,cols,board,visited,queue);
                    isBound |= Helper(ii-1,jj,rows,cols,board,visited,queue);
                    isBound |= Helper(ii,jj+1,rows,cols,board,visited,queue);
                    isBound |= Helper(ii,jj-1,rows,cols,board,visited,queue);
                }
                
                if(!isBound){
                    foreach(var item in visited){
                        board[item/cols][item%cols] = 'X';
                    }
                }
                
            }
        }
    }
    
    private bool Helper(int i,int j,int rows,int cols,char[][] board,HashSet<int> visited,Queue<int> queue){
        if(i< 0 || j < 0 || i >= rows || j >= cols)
            return true;
        
        if(board[i][j] == 'X' || !visited.Add(i*cols+j))
            return false;
        
        queue.Enqueue(i*cols+j);
        
        return false;
    }
}