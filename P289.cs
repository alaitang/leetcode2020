public class Solution {
    public void GameOfLife(int[][] board) {
        if(board == null)
            return;
        
        var rows = board.Length;
        if(rows == 0)
            return;
        
        var cols = board[0].Length;
        if(cols == 0)
            return;
        
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                
                var b = 0;
                for(int ii = Math.Max(0,i-1);ii<=Math.Min(i+1,rows-1);ii++)
                {
                    for(int jj = Math.Max(0,j-1);jj<=Math.Min(j+1,cols-1);jj++){
                        if(board[ii][jj] == 1 || board[ii][jj] == -1){
                            b++;
                        }
                    }
                }
                
                if(board[i][j] == 1 && !(b == 3 || b == 4)){
                    board[i][j] = -1;
                }else if(board[i][j] == 0 && b == 3){
                    board[i][j] = 2;
                }
            }
        }
        
        for(int i = 0;i<rows;i++){
            for(int j = 0;j<cols;j++){
                if(board[i][j] == -1){
                    board[i][j] = 0;
                }else if(board[i][j] == 2){
                    board[i][j] = 1;
                }
            }
        }
    }
}