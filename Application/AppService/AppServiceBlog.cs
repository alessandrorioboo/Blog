using ApplicationBlog.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ApplicationBlog.AppService
{
    public class AppServiceBlog
    {

        static HttpClient client = new HttpClient();
        public async Task<Todo> GetClicks(int numClick)
        {
            var xyz = GetProductAsync("https://jsonplaceholder.typicode.com/todos/1");
            var xyz1 = GetProductAsync("https://jsonplaceholder.typicode.com/todos/2");
            var xyz2 = GetProductAsync("https://jsonplaceholder.typicode.com/todos/3");


            //var xyz777 = Task.WhenAll(xyz, xyz1, xyz2).GetAwaiter().GetResult();
            //var kkk = xyz.GetAwaiter().GetResult();
            var kkk = await xyz;
            var kkk1 = await xyz1;
            var kkk2 = await xyz2;

            return kkk2;
        }

        //public Click GetClicks(int numClick)
        //{
        //    var xyz = GetProductAsync("https://jsonplaceholder.typicode.com/todos/1");
        //    var xyz1 = GetProductAsync("https://jsonplaceholder.typicode.com/todos/2");
        //    var xyz2 = GetProductAsync("https://jsonplaceholder.typicode.com/todos/3");


        //    //var xyz777 = Task.WhenAll(xyz, xyz1, xyz2).GetAwaiter().GetResult();
        //    //var kkk = xyz.GetAwaiter().GetResult();

        //    return new Click(xyz.Result.UserId);
        //}

        private async Task<Todo> GetProductAsync(string path)
        {
            Todo? todo = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                todo = JsonConvert.DeserializeObject<Todo>(await response.Content.ReadAsStringAsync());
            }
            return todo ?? new Todo();
        }
    }
}
