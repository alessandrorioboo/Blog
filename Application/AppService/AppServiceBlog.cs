//using ApplicationBlog.Helper;
//using LocalDataBase.Model;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.Json.Nodes;
//using System.Threading.Tasks;

//namespace ApplicationBlog.AppService
//{
//    public class AppServiceBlog
//    {

//        //static HttpClient client = new HttpClient();
//        public async Task<IList<Post>> GetPosts(int itens, int pagina, bool online)
//        {
//            //var allPostTask = GetAllPostAsync();
//            //var xyz1 = GetAllPostAsync("https://jsonplaceholder.typicode.com/todos/2");
//            //var xyz2 = GetAllPostAsync("https://jsonplaceholder.typicode.com/todos/3");


//            //var xyz777 = Task.WhenAll(xyz, xyz1, xyz2).GetAwaiter().GetResult();
//            //var kkk = xyz.GetAwaiter().GetResult();
//            var posts = await GetAllPostAsync();// await allPostTask;
//            posts = posts.OrderByDescending(p => p.Id).Skip((pagina - 1) * itens).Take(itens).ToList();

//            if (posts != null && posts.Count > 0)
//            {
//                var userIdList = posts.Select(p => p.UserId).Distinct().ToList();
//                var users = await GetUsersByListId(userIdList);

//                posts = (from x in posts
//                         join y in users
//                         on x.UserId equals y.Id
//                         select new Post(x, y)).OrderByDescending(p => p.Id).ToList();
//            }

//            //var kkk1 = await xyz1;
//            //var kkk2 = await xyz2;

//            return posts ?? new List<Post>();
//        }

//        //public Click GetClicks(int numClick)
//        //{
//        //    var xyz = GetProductAsync("https://jsonplaceholder.typicode.com/todos/1");
//        //    var xyz1 = GetProductAsync("https://jsonplaceholder.typicode.com/todos/2");
//        //    var xyz2 = GetProductAsync("https://jsonplaceholder.typicode.com/todos/3");


//        //    //var xyz777 = Task.WhenAll(xyz, xyz1, xyz2).GetAwaiter().GetResult();
//        //    //var kkk = xyz.GetAwaiter().GetResult();

//        //    return new Click(xyz.Result.UserId);
//        //}

//        //private async Task<Todo> GetProductAsync(string path)
//        //{
//        //    Todo? todo = null;
//        //    HttpResponseMessage response = await client.GetAsync(path);
//        //    if (response.IsSuccessStatusCode)
//        //    {
//        //        todo = JsonConvert.DeserializeObject<Todo>(await response.Content.ReadAsStringAsync());
//        //    }
//        //    return todo ?? new Todo();
//        //}

//        private async Task<IList<Post>> GetAllPostAsync()
//        {
//            string jSonPosts = await APIBlogHelper.GetAllPostsAsync();
//            IList<Post>? posts = null;

//            if (!String.IsNullOrEmpty(jSonPosts))
//            {
//                posts = JsonConvert.DeserializeObject<IList<Post>>(jSonPosts);
//            }

//            return posts ?? new List<Post>();
//        }

//        private async Task<IList<User>> GetUsersByListId(IList<int> listId)
//        {
//            string jSonUser = await APIBlogHelper.GetUserByListIdAsync(listId);
//            IList<User>? users = null;

//            if (!String.IsNullOrEmpty(jSonUser))
//            {
//                users = JsonConvert.DeserializeObject<IList<User>>(jSonUser);
//            }

//            return users ?? new List<User>();
//        }


//    }
//}
