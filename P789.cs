public class Solution {
    public bool EscapeGhosts(int[][] ghosts, int[] target) {
        return ghosts.All(x=>Math.Abs(x[0]-target[0])+Math.Abs(x[1]-target[1]) > Math.Abs(target[0])+Math.Abs(target[1]) );
    }
}