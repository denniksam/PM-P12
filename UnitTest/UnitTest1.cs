using App;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace UnitTest            // �������� ����� "����������"
{                             // �������� �����, ���� ����� ���������
    [TestClass]               // �� ���� ����� ������,
    public class HelperTest   // ������� "Test"
    {
        []

        [TestMethod]
        public void EllipsisTest()  // ��� ����, �� � ������
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
        public void EllipsisExceptionTest()
        {
            /* ���������� ��������� �� ��� ������������.
             * - ����� ���������� � ��� ��������� ������ ���������
             *    �������� �����. ³�������, ������������ ������
             *    ������ �� ��������� ������������ ������������.
             *    ! ������ "������������" � ������
             * - �������� ���� ��������� ���������� � "��������"
             *    ��������. ����� ���������� ���� "Exception" �� 
             *    �������������, ���� ������� ���������� ������ ����
             *    (�����, ���� �� ��� - ������� Exception)
             * - ���� ����������, �� ������� � �����, �����������
             *    � Assert, �� �������� ������ �������� (�����) ��
             *    ���� ���� �� ������.
             */
            Helper helper = new();
            // ����: helper.Ellipsis(null!, 1) �� "��������" ���������� ���� ArgumentNullException
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => helper.Ellipsis(null!, 1)
                );
            // ����: ����������� ���������� (ex.Message) ������� ������ ����� ��������� (input)
            Assert.IsTrue(
                ex.Message.Contains("input"),
                "Exception message should contain 'input' substring"
            );

            var ex2 = Assert.ThrowsException<ArgumentException>(
                () => helper.Ellipsis("Hello, world", 1)
            );
            Assert.IsTrue(ex2.Message.Contains("len"));

            var ex3 = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => helper.Ellipsis("Hello, world", 100)
            );
            Assert.IsTrue(ex3.Message.Contains("len"));
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

        [TestMethod]
        public void CombineUrlExceptionTest()
        {
            // /home     null     1) /home  2) Exception ??
            // �� ����� ����������, � ������ ��� ������ ���������� null
            Helper helper = new();
            // ����������� �� ����������, �� ����� ���������� 
            // ���� �� ��� ��������� ����, ���������� Assert-�� �� �������
            Assert.AreEqual("/home", helper.CombineUrl("/home", null!));

            // null!, null! -- Exception, ���� � ����� �� ���� �������
            var ex = Assert.ThrowsException<ArgumentException>(
                () => helper.CombineUrl(null!, null!)
            );
            Assert.AreEqual("All arguments are null", ex.Message);

            // null  /subsection  -- �������� ��������� ��� ������� - Exception
            Assert.AreEqual(
                "Non-Null argument after Null one",
                Assert.ThrowsException<ArgumentException>(
                    () => helper.CombineUrl(null!, "/subsection")
                ).Message);
        }
    }
}
/* �.�. ������ �������� ���� �, �� �����������, ������������ ����� 
 * CombineUrl ��� ����������� ����� �����
 * - �� �������� null � ����� ������� ���������
 * - ������� null, ������� �� null � ����� ����������
 * ������� - ���� null � ����������� ������ - �� �����,
 * ���� ���� null ��� ��-null, �� �� ����������
 *  
 *  ***
 *  ���� ���� � ��������� "..", �� ���������� ��������� ��������
 *  /shop/cart/user/../123 --> /shop/cart/123
 */
/* �.�. �������� ����� CombineUrl(part1, part2)
 * part1     part2      ret
 * /home     index      /home/index
 * /home/   /index      /home/index
 *  home/    index      /home/index
 *  
 * ��������� ��� ����� ��� ������� ������� ��������� 
 */
/* �.�. �������� ����� .Finalize(String) ���� ���� ��������
 * ����� �� ���� �����, ���� �� ��� ����. ���� �, �� �� ����
 * ������� ��� ����� �������� ����� � ���������� ������� 
 * ���������.
 * ������ �������� � ����������� ����������.
 */