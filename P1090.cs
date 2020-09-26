public class Solution {
    public int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit) {
        var len = values.Length;
        var list = new List<int>();
        var mapping = new Dictionary<int,List<int>>();
        for(int i = 0;i<len;i++){
            var l = labels[i];
            if(!mapping.ContainsKey(l))
                mapping[l] = new List<int>();
            var index = mapping[l].BinarySearch(values[i]);
            if(index < 0)
                index = ~index;
            mapping[l].Insert(index,values[i]);
            if(mapping[l].Count > use_limit)
                mapping[l].RemoveAt(0);
        }
        
        foreach(var kv in mapping){
            list.AddRange(kv.Value);
        }
        if(list.Count <= num_wanted)
            return list.Sum();
        FindN(0,list.Count-1,list,num_wanted);
        //Console.WriteLine(string.Join(",",list));
        return list.Take(num_wanted).Sum();
    }
    
    private void FindN(int low, int high, List<int> list,int k){
        var ll = low;
        if(low >= high)
            return;
        for(int i = low+1;i<=high;i++){
            if(list[i] >= list[low]){
                swap(list,i,++ll);
            }
        }
        swap(list,low,ll);
        
        if(ll-low+1 == k)
            return;
        else if(ll-low+1 > k){
            FindN(low,ll-1,list,k);
        }else{
            FindN(ll+1,high,list,k-(ll-low+1));
        }
    }
    
    private void swap(List<int> list, int i,int j){
        var t = list[j];
        list[j] = list[i];
        list[i] = t;
    }
}