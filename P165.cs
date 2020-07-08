public class Solution {
    public int CompareVersion(string version1, string version2) {
        var arr1 = version1.Split(new char[]{'.'});
        var arr2 = version2.Split(new char[]{'.'});
        
        var len1 = arr1.Length;
        var len2 = arr2.Length;
        
        var i = 0;
        var j = 0;
        
        while(i<len1 || j < len2){
            var v1 = 0;
            var v2 = 0;
            
            if(i < len1)
                v1 = int.Parse(arr1[i++]);
            if(j < len2)
                v2 = int.Parse(arr2[j++]);
            
            if(v1 < v2)
                return -1;
            else if(v1 > v2)
                return 1;
        }
        
        return 0;
    }
}