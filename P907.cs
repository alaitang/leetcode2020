public class StockSpanner {

    Stack<int> pstack = new Stack<int>();
    Stack<int> vstack = new Stack<int>();
    public StockSpanner() {
        
    }
    
    public int Next(int price) {
        var result = 1;
        while(pstack.Any() && price >= pstack.Peek()){
            result += vstack.Pop();
            pstack.Pop();
        }
        
        pstack.Push(price);
        vstack.Push(result);
        
        return result;
    }
}