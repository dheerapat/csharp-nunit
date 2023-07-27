using NUnit.Framework;

namespace HPlusSportTDD.Core
{
	class ShoppingCartTests
	{
		[SetUp]
		public void SetUp()
		{
		}
		
		[Test]
		public void ShouldReturnArticleAddedToCart()
		{
			var item = new AddToCartItem()
			{
				ArticleId = 42,
				Quantity = 5
			};
			
			var request = new AddToCartRequest()
			{
				Item = item
			};
			
			var manager = new ShoppingCartManager();
			AddToCartResponse response = manager.AddToCart(request);
			
			Assert.NotNull(response);
			Assert.Contains(item, response.Items);
		}

		[Test]
		public void ShouldReturnArticlesAddedToCart()
		{
			var item1 = new AddToCartItem()
			{
				ArticleId = 42,
				Quantity = 5
			};
			
			var request = new AddToCartRequest()
			{
				Item = item1
			};

			var manager = new ShoppingCartManager();
			AddToCartResponse response = manager.AddToCart(request);

			var item2 = new AddToCartItem()
			{
				ArticleId = 43,
				Quantity = 10
			};
			
			request = new AddToCartRequest()
			{
				Item = item2
			};
			
			response = manager.AddToCart(request);
			
			Assert.NotNull(response);
			Assert.Contains(item1, response.Items);
			Assert.Contains(item2, response.Items);
		}

		[Test]
		public void ShouldReturnCombinedArticlesAddedToCart()
		{
			var item1 = new AddToCartItem()
			{
				ArticleId = 42,
				Quantity = 5
			};
			
			var request = new AddToCartRequest()
			{
				Item = item1
			};

			var manager = new ShoppingCartManager();
			AddToCartResponse response = manager.AddToCart(request);

			var item2 = new AddToCartItem()
			{
				ArticleId = 42,
				Quantity = 10
			};
			
			request = new AddToCartRequest()
			{
				Item = item2
			};
			
			response = manager.AddToCart(request);
			
			Assert.NotNull(response);
			Assert.That(Array.Exists(response.Items, x => x.ArticleId == 42 && x.Quantity == 15));
		}
	}
}