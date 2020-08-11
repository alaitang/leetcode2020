public class Solution {
    public bool CanTransform(string start, string end) {
        var len = start.Length;
        if(len != end.Length)
            return false;
        
        var i = 0;
        var j = 0;
        
        
        while(j < len){
            if(end[j] == 'X'){
                j++;
                continue;
            }else if(end[j] == 'L'){
                while(i < len && start[i] == 'X')
                    i++;
                if(i >= len || start[i] == 'R' ||  i < j)
                    return false;
                i++;
                j++;
            }else{
                while(i < len && start[i] == 'X')
                    i++;
                if(i >= len || start[i] == 'L' ||  i > j)
                    return false;
                i++;
                j++;
            }
        }
        
        while(i < len && start[i] == 'X')
            i++;
        
        return i==len;
    }
}

>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

public class Solution {
    public bool CanTransform(string start, string end) {
        var len = start.Length;
        if(len != end.Length)
            return false;
        
        var i = 0;
        var j = 0;
        
        while(i < len && j < len){
            if( start[i] == 'X'){
                i++;
                continue;
            }
            
            if( end[j] == 'X'){
                j++;
                continue;
            }
            
            if(start[i] != end[j] || start[i] == 'L' && j > i
                    || start[i] == 'R' && j < i){
                return false;
            }
            else{
                i++;
                j++;
            }
        }
        
        while(i < len && start[i] == 'X')
            i++;
        while(j < len && end[j] == 'X')
            j++;
        
        return i == j;
    }
}