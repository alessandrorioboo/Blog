using LocalDataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace ApplicationBlog.Helper
{
    public class MapperHelper<S, D>
    {
        //public JsonSerializerOptions _serializerOptions;

        //public MapperHelper()
        //{
        //    _serializerOptions = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true,
        //        WriteIndented = true
        //    };
        //}

        public D? Map(S source)
        {
            var _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };


            var jSonSource = JsonSerializer.Serialize(source, _serializerOptions);
            var destination = JsonSerializer.Deserialize<D>(jSonSource, _serializerOptions);

            return destination;
        }

    }
}
