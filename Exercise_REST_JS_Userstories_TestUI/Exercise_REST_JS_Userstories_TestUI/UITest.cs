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
    #region UI test for user story 2
    [Fact]
    public void TestFilterByArtist()
    {
        //Arrange
        driver.Navigate().GoToUrl("http://127.0.0.1:42069");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        //Act
        var artistInput = driver.FindElement(By.Id("artist"));
        artistInput.SendKeys("Michael Jackson");
        //Assert
        Assert.Equal("Michael Jackson", artistInput.GetAttribute("value"));
    }
    [Fact]
    public void TestFilterByMinAndMaxDuration()
    {
        //Arrange
        driver.Navigate().GoToUrl("http://127.0.0.1:42069");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        wait.Until(d => driver.FindElement(By.ClassName("table")));
        //Act
        var minDurationInput = driver.FindElement(By.Id("minDuration"));
        var maxDurationInput = driver.FindElement(By.Id("maxDuration"));
        minDurationInput.SendKeys("43");
        maxDurationInput.SendKeys("45");

        var table = driver.FindElement(By.ClassName("table"));
        var tableText = table.Text;
        //Assert
        Assert.Contains("Dark Side", tableText);
    }

    [Fact]
    public void TestAllFilters()
    {
        //Arrange
        driver.Navigate().GoToUrl("http://127.0.0.1:42069");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        wait.Until(d => driver.FindElement(By.ClassName("table")));
        //Act
        var titleInput = driver.FindElement(By.Id("title"));
        var artistInput = driver.FindElement(By.Id("artist"));
        var minDurationInput = driver.FindElement(By.Id("minDuration"));
        var maxDurationInput = driver.FindElement(By.Id("maxDuration"));
        var yearInput = driver.FindElement(By.Id("publicationYear"));
        titleInput.SendKeys("Back in Black");
        artistInput.SendKeys("AC/DC");
        minDurationInput.SendKeys("41");
        maxDurationInput.SendKeys("43");
        yearInput.SendKeys("1980");

        var table = driver.FindElement(By.ClassName("table"));
        var tableText = table.Text;
        //Assert
        Assert.Contains("Back in Black", tableText);
    }
    #endregion
    public void Dispose()
    {
        driver.Quit();
    }
}
