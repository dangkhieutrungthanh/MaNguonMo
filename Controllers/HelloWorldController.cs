using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace dotnet.Controllers
{
    public class HelloWorldController : Controller
    {


        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
        public string Index()
        {
            return "This is my default action...";
        }

    }
}