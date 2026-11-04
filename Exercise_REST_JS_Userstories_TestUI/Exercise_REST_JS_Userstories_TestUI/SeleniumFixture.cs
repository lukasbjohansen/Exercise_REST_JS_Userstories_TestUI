using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_REST_JS_Userstories_TestUI;

public class SeleniumFixture : IDisposable
{
    public IWebDriver Driver { get; private set; }
    public SeleniumFixture()
    {
        Driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
    }
    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}
