using OpenQA.Selenium;
using System;
using NUnit.Framework;

namespace UI_Tests
{
    public class ShoppingCartPage : BasePage
    {
        public const string URLSITE = "http://127.0.0.1:81/opencart/";
        public ShoppingCartPage(IWebDriver driver) : base(driver) { }

        public IWebElement AddToCartButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div/button"));
        public IWebElement RemoveProduct => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div/table/tbody/tr/td[4]/div/span/button[2]"));
        public IWebElement AddProductButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/div/div/div[2]/div[2]/button[1]"));
        public IWebElement DropDownCartButton => driver.FindElement(By.Id("cart-total"));
        public IWebElement VisitShoppingCart => driver.FindElement(By.XPath("/html/body/header/div/div/div[3]/div/ul/li[2]/div/p/a[1]/strong"));
        public IWebElement EmpyCart => driver.FindElement(By.XPath("/html/body/header/div/div/div[3]/div/button/span"));
        public IWebElement DropDownEmpty => driver.FindElement(By.XPath("/html/body/header/div/div/div[3]/div/ul/li/p"));
        public void Waiter()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }
        public void AddProductToCart()
        {
            AddToCartButton.Click();
        }
        public void CheckProductInShopingCart()
        {

            DropDownCartButton.Click();
            VisitShoppingCart.Click();
        }
        public void DeleteProductFromShoppingCart()
        {
            RemoveProduct.Click();
            Waiter();
        }
        public void CheckDeletedProductFromCart()
        {
            Waiter();
            EmpyCart.Click();
            Assert.True(DropDownEmpty.Text.Contains("Your shopping cart is empty!"));
        }
        public void AddSearchProduct()
        {
            AddProductButton.Click();
        }
    }
}
