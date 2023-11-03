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
    }
}
/* Д.З. Створити метод .Finalize(String) який буде додавати
 * точку до кінця рядка, якщо її там немає. Якщо є, то не додає
 * Скласти для нього тестовий метод з достатньою кількістю 
 * тверджень.
 * Додати скриншот з результатом тестування.
 */