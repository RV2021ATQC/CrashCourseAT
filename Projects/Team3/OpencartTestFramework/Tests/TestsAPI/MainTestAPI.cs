using NUnit.Framework;

namespace OpencartTestFramework.Tests.TestsAPI
{
  [TestFixture]
    public class MainTestAPI
    {
        [Test]
        public void Add()
        {
            //first argument - productId , second - quantiny
            AddProductAPI.Login();
            AddProductAPI.AddProduct(44, 2);
            AddProductAPI.CheckAddProductByProductId();
        }
        [Test]
        public void Edit()
        {
            EditProductQuantityAPI.Login();
            //first argument - cartId , second - quantity
            EditProductQuantityAPI.EditQuantity(51, 1);
            EditProductQuantityAPI.CheckQuantiny();
        }
        [Test]
        public void Remove()
        {
            RemovePruductAPI.Login();
            //argument - cartId
            RemovePruductAPI.RemoveCart(51);
            RemovePruductAPI.CheckRemoveCartByCartId();
        }
        [Test]
        public void GetInfo()
        {
            GetCartInfoAPI.Login();
            GetCartInfoAPI.GetInfo();
        }
    }
}
