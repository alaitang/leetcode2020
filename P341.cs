/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {

    Stack<NestedInteger> stack = new Stack<NestedInteger>();
    
    public NestedIterator(IList<NestedInteger> nestedList) {
       var len = nestedList.Count;
        for(int i = len-1;i>=0;i--){
            stack.Push(nestedList[i]);
        }
        
        while(stack.Any() && !stack.Peek().IsInteger()){
            IList<NestedInteger> nestedList1 = stack.Pop().GetList();
            var len1 = nestedList1.Count;
            for(int i = len1-1;i>=0;i--){
                stack.Push(nestedList1[i]);
            }
        }
    }

    public bool HasNext() {
        return stack.Any();   
    }

    public int Next() {
        var r = stack.Pop();
        
        while(stack.Any() && !stack.Peek().IsInteger()){
            IList<NestedInteger> nestedList = stack.Pop().GetList();
            var len = nestedList.Count;
            for(int i = len-1;i>=0;i--){
                stack.Push(nestedList[i]);
            }
        }
        
        return r.GetInteger();
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */