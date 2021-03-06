﻿using System;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTesting.Common.Blocks
{
    public class WebBlock : Block
    {
        protected WebDriverWait Wait { get; private set; }

        public WebBlock(Session session) : base(session)
        {
            this.Pause(200);
            Wait = new WebDriverWait(Session.Driver, TimeSpan.FromSeconds(60));
            Tag = Wait.Until(driver => driver.GetElement(By.TagName("body")));
        }
    }
}