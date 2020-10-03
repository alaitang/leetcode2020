public class ProductOfNumbers {

    List<int> list = new List<int>();
    
    public ProductOfNumbers() {
        
    }
    
    public void Add(int num) {
        if(num == 0)
        {
            list = new List<int>();
        }else if(list.Any()){
            list.Add(list.Last() * num);
        }else{
            list.Add(num);
        }
    }
    
    public int GetProduct(int k) {
        if(list.Count > k){
            return list.Last() / list[list.Count-k-1];
        }else if(list.Count == k){
            return list.Last();
        }else{
            return 0;
        }
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */