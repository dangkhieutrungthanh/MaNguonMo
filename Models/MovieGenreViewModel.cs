using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace dotnet.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Product> Products { get; set; }
        public SelectList ds { get; set; }
        public string loaidachon { get; set; }
        public string SearchString { get; set; }
    }
    public class ProcessString
    {
        public static string AutoKey(string id)
        {
            string newKey, NumPart, StrPart, them = null;
            NumPart = Regex.Match(id, @"\d+").Value;
            StrPart = Regex.Match(id, @"\D+").Value;
            int newNum = Convert.ToInt32(NumPart) + 1;
            for (int i = 0; i < StrPart.Length - newNum.ToString().Length; i++)
            {
                them += "0";
            }
            return newKey = StrPart + them + newNum;
        }
    }
}