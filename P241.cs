public class Solution {
    public IList<int> DiffWaysToCompute(string input) {
        return Helper(input,0,input.Length-1,new Dictionary<string, List<int>>());
    }
    
    private List<int> Helper(string input, int low,int high, Dictionary<string, List<int>> mapping){
        
        var key = low + "," + high;
        
        if(!mapping.ContainsKey(key)){
            mapping[key] = new List<int>();
            for(int i = low;i<=high;i++){
                if(input[i] > '9' || input[i] < '0')
                {
                    var leftR = Helper(input,low,i-1,mapping);
                    var rightR = Helper(input,i+1,high,mapping);
                    
                    
                    foreach(var rl in leftR){
                        foreach(var rr in rightR){
                            if(input[i] == '+'){
                                mapping[key].Add(rl+rr);
                            }else if(input[i] == '-'){
                                mapping[key].Add(rl-rr);
                            }else if(input[i] == '*'){
                                mapping[key].Add(rl*rr);
                            }
                        }
                    }
                    
                }
            }
            
            if(!mapping[key].Any()){
                mapping[key].Add(int.Parse(input.Substring(low,high-low+1)));
            }
        }
        
        return mapping[key];
    }
}