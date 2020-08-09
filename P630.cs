public class Solution {
    public int ScheduleCourse(int[][] courses) {
        courses = courses.OrderBy(x=>x[1]).ToArray();
        var list = new List<int[]>();
        var time = 0;
        foreach(var c in courses){
            var index = list.BinarySearch(c,Comparer<int[]>.Create((a,b)=>{
                return b[0]-a[0];
            }));
            
            if(index < 0)
                index = ~index;
            list.Insert(index,c);
            time += c[0];
            
            if(time > c[1])
            {
                time -= list[0][0];
                list.RemoveAt(0);
            }
        }
        
        return list.Count;
    }
}