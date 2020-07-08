public class FreqStack {

    Dictionary<int,int> mapping = new Dictionary<int,int>();
    Dictionary<int,Stack<int>> list = new Dictionary<int,Stack<int>>();
    int maxf = 0;
    public FreqStack() {
        
    }
    
    public void Push(int x) {
        
        if(!mapping.ContainsKey(x))
            mapping[x] = 1;
        else
            mapping[x]++;
        
        if(mapping[x] > maxf)
            maxf = mapping[x];
        
        if(!list.ContainsKey(mapping[x]))
            list[mapping[x]] = new Stack<int>();
        list[mapping[x]].Push(x);
    }
    
    public int Pop() {
        var result = list[maxf].Pop();
        
        mapping[result]--;
        
        if(list[maxf].Count == 0){
            maxf--;
        }
        
        return result;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 */