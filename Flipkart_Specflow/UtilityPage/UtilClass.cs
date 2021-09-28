using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace Flipkart_Specflow.UtilityPage
{
    //public interface IHelperClass
    //{
    //    public void PageInfoDetails(string pageName);
    //}
    public class UtilClass
    {
        Object obj = null;
        public string PageCLassName = string.Empty;
        //public UtilClass()
        //{

        //}

        public void PageInfoDetails(string pageName, string actionEvent, IWebDriver driver)
        {
            List<object> MethodOutputs = new List<object>();
            Type typ = Type.GetType("Flipkart_Specflow.Pages." + pageName.Replace(" ",""));
            Object[] args = { driver };
            Object obj = Activator.CreateInstance(typ,args);
            MethodInfo method = typ.GetMethod(actionEvent);

            Object[] methodArgs = { };
            method.Invoke(obj, methodArgs);
            //var _driver = method.Invoke(obj, methodArgs);
            //driver = (IWebDriver)_driver;
            //MethodOutputs.Add(method.Invoke(o, methodArgs));
            //return driver;
        }
        public void PageInfoDetails(string pageName, Table table, IWebDriver driver)
        {
            List<object> MethodOutputs = new List<object>();
            Type typ = Type.GetType("Flipkart_Specflow.Pages." + pageName.Replace(" ", ""));
            Object[] args = { driver };
            Object obj = Activator.CreateInstance(typ, args);
            MethodInfo method = typ.GetMethod("PopulateData");

            Object[] methodArgs = { table };
            method.Invoke(obj, methodArgs);
            //var _driver = method.Invoke(obj, methodArgs);
            //driver = (IWebDriver)_driver;
            //MethodOutputs.Add(method.Invoke(o, methodArgs));
            //return driver;
        }

        public bool PageToLoad(string pageName, IWebDriver driver)
        {
            PageInfoDetails(pageName, "WaitPageToLoad", driver);
            return true;
        }
        public void ElementClick(string pageName, string btnName, IWebDriver driver)
        {
            PageInfoDetails(pageName, "eventElement", btnName, driver);
            //return driver;
        }


        #region Soumyadeep
        public void PageInfoDetails(string pageName, string actionEvent, string strArgumentText, IWebDriver driver)
        {
            List<object> MethodOutputs = new List<object>();
            Type typ = Type.GetType("Flipkart_Specflow.Pages." + pageName.Replace(" ", ""));
            Object[] args = { driver };
            Object obj = Activator.CreateInstance(typ, args);
            MethodInfo method = typ.GetMethod(actionEvent);
            Object[] methodArgs;
            if (strArgumentText != null)
                methodArgs = new object[] { strArgumentText };
            else
                methodArgs = new object[] { };
            //_driver = (IWebDriver)method.Invoke(o, methodArgs);
            method.Invoke(obj, methodArgs);
            //return _driver;
        }

        public void PageSearchInfoDetails(string pageName, string searchText, string actionEvent, IWebDriver driver)
        {
            List<object> MethodOutputs = new List<object>();
            Type t = Type.GetType("Flipkart_Specflow.Pages." + pageName.Replace(" ", ""));
            Object[] args = { driver };
            Object o = Activator.CreateInstance(t, args);
            MethodInfo method = t.GetMethod(actionEvent);
            Object[] methodArgs = { searchText };
            method.Invoke(o, methodArgs);
        }



        public bool SearchAndClick(string pageName, string SearchText, IWebDriver driver)
        {
            PageInfoDetails(pageName, "SearchTextAndClick", SearchText,  driver);
            return true;
        }

        public bool Verify(string pageName, string SearchText, IWebDriver driver)
        {
            PageSearchInfoDetails(pageName, SearchText, "Validate", driver);
            return true;
        }
        #endregion

    }
}
