public class Solution {
    public bool ValidTicTacToe(string[] board) {
        var n = 0;
        var m = 0;
        
        var winCount = 0;
        
        var nw = false;
        var mw = false;
        
        foreach(var r in board){
            if(r == "XXX"){
                nw = true;
                winCount++;
            }
            else if(r == "OOO"){
                mw = true;
                winCount++;
            }
            
            foreach(var c in r){
                if(c == 'X')
                    n++;
                else if(c == 'O')
                    m++;
            }
        }
        
        if(winCount > 1 || !(n == m || n == m+1) )
            return false;
        
        winCount = 0;
        
        var tn = n;
        var tm = m;
        for(int j = 0;j<3;j++)
        {
            n = 0;
            m = 0;
            for(int i = 0;i<3;i++){
                var c = board[i][j];
                if(c == 'X'){
                    n++;
                }
                else if(c == 'O'){
                    m++;
                }
            }
            
            if(n == 3){
                nw = true;
                winCount++;
            }
            else if(m == 3){
                mw = true;
                winCount++;
            }
        }
        
        
        if(winCount >1)
            return false;
        
        nw |= board[1][1] == 'X' && (board[0][0] == board[1][1] && board[2][2] == board[1][1]
                                    || board[0][2] == board[1][1] && board[2][0] == board[1][1]);
        
        mw |= board[1][1] == 'O' && (board[0][0] == board[1][1] && board[2][2] == board[1][1]
                                    || board[0][2] == board[1][1] && board[2][0] == board[1][1]);
        
        
        if(nw && (tn == tm) || mw && (tn == tm+1))
            return false;
        
        
        return true;
    }
}