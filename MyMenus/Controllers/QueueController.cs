using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMenus.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();

        // GET: Queue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.queueIndex = "Added One";

            return View("Index");
        }

        public ActionResult AddMany()
        {
            myQueue.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }
            ViewBag.queueIndex = "Added Many";

            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.queueDisplay = myQueue;
            return View();
        }

        public ActionResult DeleteOneQueue()
        {
            return View();
        }

        public ActionResult DeleteItemQueue(string place)
        {
            Queue<string> tempQueue = new Queue<string>();

            if (myQueue.Contains(place))
            {
                while (myQueue.Count > 0)
                {
                    if (myQueue.Peek() == place)
                    {
                        myQueue.Dequeue();
                    }
                    else
                    {
                        tempQueue.Enqueue(myQueue.Dequeue());
                    }
                }
                while (tempQueue.Count > 0)
                {
                    myQueue.Enqueue(tempQueue.Dequeue());
                }
                ViewBag.queueIndex = "Item found and deleted";
            }
            else
            {
                ViewBag.queueIndex = "Item not found in Queue";
            }


            return View("Index");
        }

        public ActionResult Clear()
        {
            myQueue.Clear();
            ViewBag.queueIndex = "Cleared";

            return View("Index");
        }

        public ActionResult SearchForItemQueue()
        {
            return View();
        }

        public ActionResult SearchItemQueue(string place)
        {
            Queue<string> tempQueue = new Queue<string>();
            int positionInQueue = 0;
            int iCounter = 0;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            if (myQueue.Contains(place))
            {
                sw.Start();

                while (myQueue.Count > 0)
                {
                    iCounter += 1;
                    if (myQueue.Peek() == place)
                    {
                        positionInQueue = iCounter;
                        tempQueue.Enqueue(myQueue.Dequeue());   
                    }
                    else
                    {
                        tempQueue.Enqueue(myQueue.Dequeue());
                    }
                }
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                ViewBag.queueIndex = "Item found | Index at: " + positionInQueue + " | Time elapsed: " + ts;

                while (tempQueue.Count > 0)
                {
                    myQueue.Enqueue(tempQueue.Dequeue());
                }
            }
            else
            {
                ViewBag.queueIndex = "Item not found in Queue";
            }

            return View("Index");
        }
    }
}