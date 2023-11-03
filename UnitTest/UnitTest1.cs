using App;

namespace UnitTest            // �������� ����� "����������"
{                             // �������� �����, ���� ����� ���������
    [TestClass]               // �� ���� ����� ������,
    public class HelperTest   // ������� "Test"
    {
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
    }
}
/* �.�. �������� ����� .Finalize(String) ���� ���� ��������
 * ����� �� ���� �����, ���� �� ��� ����. ���� �, �� �� ����
 * ������� ��� ����� �������� ����� � ���������� ������� 
 * ���������.
 * ������ �������� � ����������� ����������.
 */