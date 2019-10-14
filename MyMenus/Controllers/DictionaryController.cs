﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMenus.Controllers
{
    public class DictionaryController : Controller
    {
        Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.dictionaryIndex = "Welcome to the Dicitionary page!";
            return View();
        }

        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count +1) , (myDictionary.Count + 1));
            ViewBag.dictionaryIndex = "One item added to dictionary";

            return View("Index");
        }
        public ActionResult AddMany()
        {
            myDictionary.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
            }
            ViewBag.dictionaryIndex = "Many items added to dictionary";

            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.displayDictionary = myDictionary;
            return View();
        }

        public ActionResult DeleteOneDictionary()
        {
            return View();
        }

        public ActionResult DeleteItemDictionary(string place)
        {
            ViewBag.dictionaryIndex = "Entered Delete";
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
            ViewBag.dictionaryIndex = "Entered Search ";
            return View("Index");
        }
    }
}