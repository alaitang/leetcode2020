public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var mapping = new Dictionary<int,int>();
        
        foreach(var item in nums){
            if(!mapping.ContainsKey(item))
                mapping[item] = 0;
            mapping[item]++;
        }
        
        var allkeys = mapping.Keys.ToArray();
        
        if(allkeys.Length == k)
            return allkeys;
        
        Helper(allkeys,0,allkeys.Length-1,k,mapping);
        return allkeys.Take(k).ToArray();; 
    }
    
    private void Helper(int[] keys, int ii, int jj, int k, Dictionary<int,int> mapping){
        if(ii >= jj)
            return;
        var low = ii;
        var index = ii;
        for(int i = ii+1;i<=jj;i++){
            if(mapping[keys[low]] <= mapping[keys[i]]){
                Swap(keys,i,++index);
            }
        }
        
        Swap(keys,low,index);
        
        if(index-low+1 == k)
            return;
        else if(index-low+1 < k){
            Helper(keys,index+1,jj,k- (index-low+1),mapping);
        }else{
            Helper(keys,ii,index-1,k,mapping);
        }
    }
    
    private void Swap(int[] keys,int i,int j){
        var t = keys[i];
        keys[i] = keys[j];
        keys[j] = t;
    }
}