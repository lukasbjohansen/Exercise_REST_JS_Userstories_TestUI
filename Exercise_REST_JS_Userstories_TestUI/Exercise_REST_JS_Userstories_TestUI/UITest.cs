using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace Exercise_REST_JS_Userstories_TestUI;

public class UITest : IDisposable
{
    private IWebDriver driver;
    public UITest()
    {
        driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
    }
    [Fact]
    public void TestGetAllHasAtLeastOneRow()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:42069");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        wait.Until(d => driver.FindElement(By.ClassName("table")));

        var table = driver.FindElement(By.ClassName("table"));
        var rows = table.FindElements(By.TagName("tr"));
        
        Assert.True(rows.Count > 1, "Expected at least one row in the table");
    }
    public void Dispose()
    {
        driver.Quit();
    }
}
