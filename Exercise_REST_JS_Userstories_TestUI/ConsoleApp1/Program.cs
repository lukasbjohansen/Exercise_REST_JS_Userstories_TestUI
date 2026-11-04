
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

string url = "http://127.0.0.1:42069";
IWebDriver driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
//driver.Navigate().GoToUrl("http://127.0.0.1:42069");
//var table = driver.FindElement(By.ClassName("table"));
//var tableText = table.;
//Console.WriteLine(tableText);
//Arrange
driver.Navigate().GoToUrl(url);
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
Console.WriteLine(table.Text);