public class Twitter {

    Dictionary<int,HashSet<int>> followers = new Dictionary<int,HashSet<int>>();
    Dictionary<int,List<int>> posts = new Dictionary<int,List<int>>();
    Dictionary<int,int> times = new Dictionary<int,int>();
    int t = 0;
    /** Initialize your data structure here. */
    public Twitter() {
        
    }
    
    /** Compose a new tweet. */
    public void PostTweet(int userId, int tweetId) {
        if(!posts.ContainsKey(userId))
            posts[userId] = new List<int>();
        posts[userId].Insert(0,tweetId);
        times.Add(tweetId,t++);
        if(!followers.ContainsKey(userId))
            followers[userId] = new HashSet<int>();
        followers[userId].Add(userId);
    }
    
    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public IList<int> GetNewsFeed(int userId) {
        var result = new List<int>();
        if(followers.ContainsKey(userId)){
            var len = followers[userId].Count;
            
            var indexes = new int[len];
            
            var mapping = new Dictionary<int,int>();
            foreach(var item in followers[userId])
                mapping[item] = 0;
            
            while(result.Count < 10){
                var r = -1;
                
                foreach(var k in followers[userId]){
                    
                    if(!posts.ContainsKey(k)
                      || posts[k].Count <=  mapping[k] )
                        continue;
                    
                    if(r == -1 || 
                      times[posts[k][mapping[k]]]
                      > times[posts[r][mapping[r]]]){
                        r = k;
                    }
                }
                
                if(r == -1)
                    break;
                
                result.Add(posts[r][mapping[r]]);
                mapping[r]++;
            }
        }
        
        return result;
    }
    
    /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
    public void Follow(int followerId, int followeeId) {
        if(!followers.ContainsKey(followerId))
            followers[followerId] = new HashSet<int>();
        followers[followerId].Add(followeeId);
    }
    
    /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
    public void Unfollow(int followerId, int followeeId) {
        if(followerId == followeeId || !followers.ContainsKey(followerId))
            return;
        followers[followerId].Remove(followeeId);
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */