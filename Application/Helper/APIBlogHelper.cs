namespace ApplicationBlog.Helper
{
    /// <summary>
    /// Classe Helper de acesso à API jsonplaceholder.typicode.com
    /// </summary>
    public class APIBlogHelper
    {
        private static HttpClient client = new HttpClient();

        private const string _templaeURLGetAllPost = "https://jsonplaceholder.typicode.com/posts";
        private const string _templaeURLGetUserByList = "https://jsonplaceholder.typicode.com/users?{0}";
        private const string _templaeURLGetCommentByPostList = "https://jsonplaceholder.typicode.com/comments?{0}";

        public static async Task<string> GetAllPostsAsync()
        {
            return await GetData(_templaeURLGetAllPost);
        }

        public static async Task<string> GetUserByListIdAsync(List<int> listId)
        {
            if (listId != null && listId.Count > 0)
            {
                string parameter = "";
                foreach (var id in listId)
                {
                    parameter = parameter + "id=" + id.ToString() + "&";
                }

                var uRL = String.Format(_templaeURLGetUserByList, parameter);
                return await GetData(uRL);
            }
            else
            {
                return string.Empty;
            }
        }

        public static async Task<string> GetCommentsByPostListIdAsync(List<int> postListId)
        {        
            if (postListId != null && postListId.Count > 0)
            {
                string parameter = "";
                foreach (var id in postListId)
                {
                    parameter = parameter + "postId=" + id.ToString() + "&";
                }

                var uRL = String.Format(_templaeURLGetCommentByPostList, parameter);
                return await GetData(uRL);
            }
            else
            {
                return string.Empty;
            }
        }

        private static async Task<string> GetData(string uRL)
        {
            string result = "";
            HttpResponseMessage response = await client.GetAsync(uRL);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
