using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM.ViewModels;

namespace MVVMTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vm = new ViewCViewModel();
            vm.OKButtonExecute();
        }
    }
}