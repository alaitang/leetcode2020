public class Solution {
    public string ComplexNumberMultiply(string a, string b) {
        var arra = a.Split(new char[]{'+'}).Select(x=>int.Parse(x.Replace("i",""))).ToArray();
        var arrb = b.Split(new char[]{'+'}).Select(x=>int.Parse(x.Replace("i",""))).ToArray();
        
        return $"{arra[0]*arrb[0]-arra[1]*arrb[1]}+{arra[0]*arrb[1]+arra[1]*arrb[0]}i";
    }
}