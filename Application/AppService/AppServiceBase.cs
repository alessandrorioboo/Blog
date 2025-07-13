using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationBlog.AppService
{
    public abstract class AppServiceBase
    {
        public JsonSerializerOptions _serializerOptions;

        public AppServiceBase()
        {
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }
    }
}
