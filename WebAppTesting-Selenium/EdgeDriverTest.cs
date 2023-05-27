using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestPizzaBekaluKobro
{
    [TestClass]
    public class EdgeDriverTest
    {
        

        private EdgeDriver _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            string driverPath = @"C:\Users\Beck\OneDrive\Desktop\TestPizzaBekaluKobro\";
            var options = new EdgeOptions

            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new EdgeDriver(driverPath, options);
        }


        // TestCase-o:test title
        [TestMethod]
        public void VerifyPageTitle()
        {
            
            _driver.Url = "http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html";
            Assert.AreEqual("Red Ball Pizza Build a Pizza", _driver.Title);
        }


        // TestCase-1: Test Image Red Ball Pizza
        [TestMethod]
        public void TestImageRedBullPizza()
        {
            
            
            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");

            IWebElement img_ = _driver.FindElement(By.Id("logoimg"));

            // Check that the image source is correct
            Assert.AreEqual("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_logo.png", img_.GetAttribute("src"));
        }


        // TestCase-2: test hyperlink home
        [TestMethod]
        public void TestHyprilinkHome()
        {


            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");

            IWebElement linkHome = _driver.FindElement(By.LinkText("home"));

            // Check link href attribute is correct
            Assert.AreEqual("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html#", linkHome.GetAttribute("href"));
        }


        // TestCase-3: test hyperlink menu
        [TestMethod]
        public void TestHyprilinkMenu()
        {


            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");

            IWebElement linkMenu = _driver.FindElement(By.LinkText("menu"));

            // Check link href attribute is correct
            Assert.AreEqual("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html#", linkMenu.GetAttribute("href"));
        }



        // TestCase-4:test dropdown menu-1
        [TestMethod]
        public void TestDropDownQuantity()
        {

            int[] arrayQuantityValue = {1,2,3,4,5,6,7,8,9,10};
            string[] arrayQuantityText  = {"1", "2", "3", "4", "5", "6" , "7", "8", "9", "10"};

            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");

            IWebElement dropDownQuantity = _driver.FindElement(By.Name("pizzaQuantity"));
            SelectElement elementOption = new SelectElement(dropDownQuantity);

            for (int i = 0; i < arrayQuantityText.Length; i++)
            {

                elementOption.SelectByValue(arrayQuantityValue[i].ToString());
                elementOption.SelectByText(arrayQuantityText[i]);
                Thread.Sleep(1000);

            }
            // report: can't find dropdown value for 5 & 6
        }


        // TestCase-5: test dropdown menu-2
        [TestMethod]
        public void TestDropDownSize()
        {
            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");
            SelectElement dropdown = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));

            
            for (int i = 0; i < dropdown.Options.Count; i++)
            {
                
                string value = dropdown.Options[i].GetAttribute("value");
                dropdown.SelectByValue(value);
                Assert.AreEqual(value, dropdown.SelectedOption.GetAttribute("value"));
                Thread.Sleep(1000);
            }
        }

        // TestCase-6: test dropdown menu-3
        [TestMethod]
        public void TestDropDownCrust()
        {
            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");
            SelectElement dropdown = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));

          
            for (int i = 0; i < dropdown.Options.Count; i++)
            {
                
                string value = dropdown.Options[i].GetAttribute("value");
                dropdown.SelectByValue(value);
                Assert.AreEqual(value, dropdown.SelectedOption.GetAttribute("value"));
                Thread.Sleep(1000);
            }
        }





        //TestCase-7: test combination of dropdown menu-1
        [TestMethod]
        public void Combination1() // Quantity, Size, Crust = 1, 12", thin -> expectedTotalPricerice $11
        {
            

            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity, size, crust
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));

            dropdownQty.SelectByIndex(0);  // Quantity = 1
            dropdownSize.SelectByIndex(0);  // size = 12"
            dropdownCrust.SelectByIndex(0); //crust = thin
            //Thread.Sleep(3000);


            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(4000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$11.00", cartTotal.GetAttribute("value"));

           
            // report: Expected:<$11.00>. Actual:<$16.00>.
        }

        //TestCase-8: test combination of dropdown menu-2
        [TestMethod]
        public void Combination2() // Quantity, Size, Crust = 2, 14", thin -> expectedTotalPricerice $26
        {
            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");

            //selectPizza Quantity, size, crust
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));


            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(1);  // size = 14"
            dropdownCrust.SelectByIndex(0); //crust = thin
            //Thread.Sleep(3000);


            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(4000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$26.00", cartTotal.GetAttribute("value"));

            
        }


        //TestCase-9: test combination of dropdown menu-3
        [TestMethod]
        public void Combination3() // Quantity, Size, Crust = 2, 14", stuffed -> expectedTotalPricerice $32
        {
            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));

            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(1);  // size = 14"
            dropdownCrust.SelectByIndex(2); //crust = stuffed
            //Thread.Sleep(3000);

            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(4000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$32.00", cartTotal.GetAttribute("value"));


            // report: passed
        }


        //TestCase-10: test combination of dropdown menu-4
        [TestMethod]
        public void Combination4() // Quantity, Size, Crust = 2, 14", pan -> expectedTotalPricerice $30
        {
            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));


            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(1);  // size = 14"
            dropdownCrust.SelectByIndex(3); //crust = pan
            //Thread.Sleep(3000);


            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(3000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$30.00", cartTotal.GetAttribute("value"));
            // report: passed
        }

        //TestCase-11: test combination of dropdown menu-5
        [TestMethod]
        public void Combination5() // Quantity, Size, Crust = 2, 16", thin -> expectedTotalPricerice $32
        {
            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));


            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(2);  // size = 16"
            dropdownCrust.SelectByIndex(0); //crust = thin
            //Thread.Sleep(3000);


            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(3000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$32.00", cartTotal.GetAttribute("value"));
            // report: passed
        }


        //TestCase-12: test combination of dropdown menu-6
        [TestMethod]
        public void Combination6() // Quantity, Size, Crust = 2, 16", pan -> expectedTotalPricerice $36
        {
            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));


            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(2);  // size = 16"
            dropdownCrust.SelectByIndex(3); //crust = pan
            //Thread.Sleep(3000);


            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(3000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$36.00", cartTotal.GetAttribute("value"));
            // report: passed
        }



        //TestCase-13: test checkbox-1
        [TestMethod]
        public void Combination2WithSauce() // Quantity, Size, Crust, +doubleSouce = 2, 14", thin -> expectedTotalPricerice $29
        {

            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");

            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));

            // select checkbox for doublesouce 
            IWebElement checkDoubleSouce = _driver.FindElement(By.Id("doubleSauce"));

            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(1);  // size = 14"
            dropdownCrust.SelectByIndex(0); //crust = thin
            checkDoubleSouce.Click();       // add doublesouce

            //Thread.Sleep(3000);

            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(3000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$29.00", cartTotal.GetAttribute("value"));
            // report: passed

        }


        //TestCase-14: test checkbox-2

        [TestMethod]
        public void Combination2WithOUTSauce() // Quantity, Size, Crust = 2, 14", thin -> expectedTotalPricerice $26
        {

            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));

           

            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(1);  // size = 14"
            dropdownCrust.SelectByIndex(0); //crust = thin
            

            //Thread.Sleep(3000);

            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(3000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$26.00", cartTotal.GetAttribute("value"));
            // report: passed

        }




        //TestCase-15: test dorpdown + radio-1
        [TestMethod]
        public void Combination2WithDoubleCheese() // combination2 + doublecheese & no peperoni 
        {

            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));

            // select checkbox for doubleCheese 
            IWebElement checkdoubleCheese = _driver.FindElement(By.Id("doubleCheese"));

            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(1);  // size = 14"
            dropdownCrust.SelectByIndex(0); //crust = thin
            checkdoubleCheese.Click();       // add doublesouce

            //Thread.Sleep(3000);

            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(3000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$29.00", cartTotal.GetAttribute("value"));
            // report: passed

        }




        //TestCase-16: test dorpdown + radio-2
        [TestMethod]
        public void Combination2WithDoubleCheesePeperoni() // combination2 + doublecheese + peperoni 
        {

            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));

            // select checkbox for doubleCheese 
            IWebElement checkdoubleCheese = _driver.FindElement(By.Id("doubleCheese"));



            string radioButtonValue = "full";
            string radioButtonName = "pepperoni";

            // select radiobutton 
            IWebElement radioButton = _driver.FindElement(By.XPath($"//input[@type='radio' and @name='{radioButtonName}' and @value='{radioButtonValue}']"));
           

            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(1);  // size = 14"
            dropdownCrust.SelectByIndex(0); //crust = thin
            checkdoubleCheese.Click();       // add doublesouce
            radioButton.Click();             // add peperoni

            //Thread.Sleep(3000);

            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(3000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$32.00", cartTotal.GetAttribute("value"));
            // report: passed

        }





        //TestCase-17: test dorpdown + radio-3

        [TestMethod]
        public void Combination2With_HalfPeperoni_HalfChicken_HalfTomatoe() // combination2  + no cheese + 1/2 peperoni  + 1/2 chicken + 1/2 tomatoe
        {

            _driver.Navigate().GoToUrl("http://students.cs.ndsu.nodak.edu/~myronovy/pizza/rb_pizza.html");


            //selectPizza Quantity
            SelectElement dropdownQty = new SelectElement(_driver.FindElement(By.Id("pizzaQuantity")));
            SelectElement dropdownSize = new SelectElement(_driver.FindElement(By.Id("pizzaSize")));
            SelectElement dropdownCrust = new SelectElement(_driver.FindElement(By.Id("pizzaCrust")));

           


            // add half peperoni 
            string radioButtonLeft = "left";
            string radioButtonPep = "pepperoni";
            IWebElement radioButton_pep = _driver.FindElement(By.XPath($"//input[@type='radio' and @name='{radioButtonPep}' and @value='{radioButtonLeft}']"));


            // add half chicken 
            string radioButtonRight = "right";
            string radioButtonChicken = "chicken";
            IWebElement radioButton_chicken = _driver.FindElement(By.XPath($"//input[@type='radio' and @name='{radioButtonChicken}' and @value='{radioButtonRight}']"));


            // add tomatoes 
            string radioButton_tomato_right = "right";
            string radioButtontomato = "tomato";
            IWebElement radioButton_tomato = _driver.FindElement(By.XPath($"//input[@type='radio' and @name='{radioButtontomato}' and @value='{radioButton_tomato_right}']"));


            dropdownQty.SelectByIndex(1);  // Quantity = 2
            dropdownSize.SelectByIndex(1);  // size = 14"
            dropdownCrust.SelectByIndex(0); //crust = thin

            radioButton_pep.Click();      // add 1/2 peperoni
            radioButton_chicken.Click();  // add 1/2 chicken
            radioButton_tomato.Click();  // add 1/2 tomato 

            //Thread.Sleep(3000);

            // submit the combination
            IWebElement addToCart = _driver.FindElement(By.Id("addToCart"));
            addToCart.Click();
            Thread.Sleep(3000);

            // retrieveCalculatedValue
            IWebElement cartTotal = _driver.FindElement(By.Id("cartTotal"));
            Assert.AreEqual("$30.50", cartTotal.GetAttribute("value"));
            // report: passed

        }


        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
