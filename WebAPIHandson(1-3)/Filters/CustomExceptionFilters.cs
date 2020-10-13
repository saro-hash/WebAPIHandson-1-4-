using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIHandson_1_3_.Filters
{
    public class CustomExceptionFilters:IExceptionFilter
    {
        public CustomExceptionFilters()
        {
        }

        public void OnException(ExceptionContext context)
        {
            FileStream fs = new FileStream("log.txt", FileMode.Append, FileAccess.Write);
            StreamWriter s = new StreamWriter(fs);

            s.WriteLine("Exception occured");
            s.WriteLine(context.Exception.Message);
            s.WriteLine("Exception Logged Time: " + DateTime.Now);
            s.WriteLine("Exception Occured at:");
            s.WriteLine(context.Exception.StackTrace);
            s.Flush();
            s.Close();
            fs.Close();

            context.ExceptionHandled = true;
        }
    }
}
