using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMenus.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.dictionaryIndex = "Welcome to the Dictionary page!";
            return View();
        }

        public ActionResult AddOne()
        {
            myDictionary.Add((myDictionary.Count + 1), "New Entry " + (myDictionary.Count + 1));
            ViewBag.dictionaryIndex = "One item added to dictionary";

            return View("Index");
        }
        public ActionResult AddMany()
        {
            myDictionary.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add((myDictionary.Count + 1), "New Entry " + (myDictionary.Count + 1));
            }
            ViewBag.dictionaryIndex = "Many items added to dictionary";

            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.displayDictionary = myDictionary;
            return View("Display");
        }

        public ActionResult DeleteOneDictionary()
        {
            return View("DeleteOneDictionary");
        }

        public ActionResult DeleteItemDictionary(string place)
        {
            try
            {
                int tryKey = Int32.Parse(place);
                if (myDictionary.Count == 0)
                {
                    ViewBag.dictionaryIndex = "The dictionary is Empty, Add items before trying to delete them";
                }
                if (myDictionary.ContainsKey(tryKey))
                {
                    myDictionary.Remove(tryKey);
                    ViewBag.dictionaryIndex = "The value was found and deleted";
                }
                else
                {
                    ViewBag.dictionaryIndex = "This value does not exist in the Dictionary";
                }
            }
            catch (FormatException)
            {
                ViewBag.dictionaryIndex = "Not a valid number";
            }
            return View("Index");
        }

        public ActionResult Clear()
        {
            myDictionary.Clear();
            ViewBag.dictionaryIndex = "Dictionary cleared";
            return View("Index");
        }

        public ActionResult SearchForItemDictionary()
        {
            ViewBag.displayDictionary = myDictionary;
            return View();
        }

        public ActionResult SearchItemDictionary(string place)
        {
            try
            {
                int tryKey = Int32.Parse(place);
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                if (myDictionary.ContainsKey(tryKey))
                {
                    string value = myDictionary[tryKey];
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    ViewBag.dictionaryIndex = "Item found | with the Value of: " + value + " | Time elapsed: " + ts;

                }
                else
                {
                    ViewBag.dictionaryIndex = "Item not found in Dictionary";
                }

            }
            catch (FormatException)
            {
                ViewBag.dictionaryIndex = "Not a valid number";
            }
            return View("Index");
        }
    }
}