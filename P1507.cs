public class Solution {
    public string ReformatDate(string date) {
        var arr = date.Split(new char[]{' '});
        
        var year = int.Parse(arr[2]);
        var day = int.Parse(arr[0].Substring(0,arr[0].Length-2));
        var months = new string[]{"","Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
        var month =Array.IndexOf(months,arr[1]);
        
        return $"{year}-{(month+"").PadLeft(2,'0') }-{(day+"").PadLeft(2,'0')}";
    }
}