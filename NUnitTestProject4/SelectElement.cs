using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ExperienceWithSeleniumWeb
{
    internal class SelectElement
    {
        private ReadOnlyCollection<IWebElement> dropDown;

        public SelectElement(ReadOnlyCollection<IWebElement> dropDown)
        {
            this.dropDown = dropDown;
        }

        internal void SelectByText(string v)
        {
            throw new NotImplementedException();
        }
    }
}