using Microsoft.AspNetCore.Mvc;
using Sample7.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sample7.Api.Actions
{
    public sealed class EmployeeCsvResult : FileResult
    {
        private readonly IEnumerable<IModel> _data;

        public EmployeeCsvResult(IEnumerable<IModel> data, string fileDownloadName) : base("text/csv")
        {
            _data = data;
            FileDownloadName = fileDownloadName;
        }

        public async override Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            context.HttpContext.Response.Headers.Add("Content-Disposition", new[] { "attachment; filename=" + FileDownloadName });
            using (var streamWriter = new StreamWriter(response.Body))
            {
                var properties = _data.First().GetType().GetProperties();

                var header = "";

                foreach (var pro in properties)
                {
                    if (typeof(IEnumerable<IModel>).IsAssignableFrom(pro.PropertyType) || typeof(IModel).IsAssignableFrom(pro.PropertyType))
                        continue;

                        header += $"{pro.Name};";
                }
                await streamWriter.WriteLineAsync(header);

                foreach (var p in _data)
                {
                    var props = p.GetType().GetProperties();

                    var line = "";
                    foreach (var pro in props)
                    {
                        if (typeof(IEnumerable<IModel>).IsAssignableFrom(pro.PropertyType) || typeof(IModel).IsAssignableFrom(pro.PropertyType))
                            continue;
                        line += $"{pro.GetValue(p)};";
                    }

                    await streamWriter.WriteLineAsync(line);
                    //await streamWriter.FlushAsync();
                }
                await streamWriter.FlushAsync();
            }
        }
    }
}
