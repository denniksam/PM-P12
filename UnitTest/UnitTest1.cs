using App;

namespace UnitTest            // Тестовий проєкт "відзеркалює"
{                             // основний проєкт, його класи називають
    [TestClass]               // від імен класів проєкту,
    public class HelperTest   // додаючи "Test"
    {
        [TestMethod]
        public void EllipsisTest()  // так само, як і методи
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            Assert.AreEqual(
                "He...",
                helper.Ellipsis("Hello, World", 5));
            Assert.AreEqual(
                "Hel...",
                helper.Ellipsis("Hello, World", 6));
            Assert.AreEqual(
                "Test...",
                helper.Ellipsis("Test String", 7));
        }

        [TestMethod]
        public void CombineUrlTest()
        {
            Helper helper = new();
            Dictionary<String[], String> testCases = new()
            {
                { new[] { "/home",  "index"   }, "/home/index"  },
                { new[] { "/shop/", "/cart"   }, "/shop/cart"   },
                { new[] { "auth/",  "logout"  }, "/auth/logout" },
                { new[] { "forum/",  "topic/" }, "/forum/topic" },
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    helper.CombineUrl(testCase.Key[0], testCase.Key[1]),
                    $"{testCase.Value} -- {testCase.Key[0]} + {testCase.Key[1]}"
                );
            }
        }
        [TestMethod]
        public void CombineUrlMultiTest()
        {
            Helper helper = new();
            Dictionary<String[], String> testCases = new()
            {
                { new[] { "/home",  "/index", "/123"  }, "/home/index/123"  },
                { new[] { "/shop/", "/cart/", "123/"  }, "/shop/cart/123"   },
                { new[] { "auth/",  "logout", "/123/" }, "/auth/logout/123" },
                { new[] { "forum",  "topic/", "123"   }, "/forum/topic/123" },
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    helper.CombineUrl(testCase.Key),
                    $"{testCase.Value} -- {testCase.Key[0]} + {testCase.Key[1]}"
                );
            }
        }
    }
}
/* Д.З. Модифікувати метод CombineUrl для проходження тестів
 * part1      part2      ret
 * /home///    index      /home/index
 * ///home/   /index      /home/index
 *  home/    ////index    /home/index
 *  Додати ці тестові кейси
 *  
 *  ***
 *  Якщо один з параметрів "..", то вилучається попередній фрагмент
 *  /shop/cart/user/../123 --> /shop/cart/123
 */
/* Т.З. Створити метод CombineUrl(part1, part2)
 * part1     part2      ret
 * /home     index      /home/index
 * /home/   /index      /home/index
 *  home/    index      /home/index
 *  
 * Розширити цей метод для довільної кількості параметрів 
 */
/* Д.З. Створити метод .Finalize(String) який буде додавати
 * точку до кінця рядка, якщо її там немає. Якщо є, то не додає
 * Скласти для нього тестовий метод з достатньою кількістю 
 * тверджень.
 * Додати скриншот з результатом тестування.
 */