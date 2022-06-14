// See https://aka.ms/new-console-template for more information

using DAL;
using MSSQLTests;


var db = new DataContextFactory();
var repo = new MSSQLRepo(db.getContext());
Console.WriteLine(repo.GetItems().ToString());

System.Diagnostics.Debug.WriteLine("fdsfgdg");
