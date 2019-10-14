using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMenus.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.IndexBag = "Welcome to the Stack Page";
            return View();
        }

        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            //ViewBag.StackBag = myStack;
            ViewBag.IndexBag = "Added One";
            return View("Index");
        }

        public ActionResult AddMany()
        {
            myStack.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
                //ViewBag.StackBag = myStack;
            }
            ViewBag.IndexBag = "Added Many";
            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.StackBag = myStack;
            return View("Display");
        }

        public ActionResult DeleteOne()
        {
            return View("DeleteOne");
        }

        public ActionResult DeleteItem(string place)
        {
            Stack<string> tempStack = new Stack<string>();

            if (myStack.Contains(place) == true)
            {
                while (myStack.Count > 0)
                {
                    if (place == myStack.Peek())
                    {
                        myStack.Pop();
                        break;
                    }
                    else
                    {
                        tempStack.Push(myStack.Pop());
                    }
                }

                while (tempStack.Count > 0)
                {
                    myStack.Push(tempStack.Pop());
                }
                ViewBag.IndexBag = "Item found and deleted";
            }

            else
            {
                ViewBag.IndexBag = "Item not in Stack";
            }
            return View("Index");
        }

        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.IndexBag = "Cleared";
            return View("Index");
        }

        public ActionResult SearchForItem()
        {
            return View("SearchForItem");
        }

        public ActionResult Search(string place)
        {
            Stack<string> tempStack = new Stack<string>();
            int positionInStack = 0;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            if (myStack.Contains(place) == true)
            {
                sw.Start();

                while (myStack.Count > 0)
                {
                    positionInStack += 1;
                    if (myStack.Peek() == place)
                    {
                        break;
                    }
                    else
                    {
                        tempStack.Push(myStack.Pop());
                    }
                }
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                ViewBag.IndexBag = "Item found | Index at: " + positionInStack + " | Time elapsed: " + ts;

                while (tempStack.Count > 0)
                {
                    myStack.Push(tempStack.Pop());
                }
            }
            else
            {
                ViewBag.IndexBag = "Item not in Stack";
            }
            return View("Index");
        }
    }
}