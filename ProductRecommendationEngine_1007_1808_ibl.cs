// 代码生成时间: 2025-10-07 18:08:54
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductRecommendationSystem
{
    // 定义商品类
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> RelatedProductIds { get; set; } = new List<int>();
    }

    // 商品推荐引擎
    public class ProductRecommendationEngine
    {
        private List<Product> _products;

        // 构造函数，初始化商品数据
        public ProductRecommendationEngine(List<Product> products)
        {
            if(products == null || !products.Any())
            {
                throw new ArgumentException("Product list cannot be null or empty.");
            }

            _products = products;
        }

        // 根据用户购买历史推荐商品
        public List<Product> RecommendProducts(int userId)
        {
            // 这里假设有一个方法 GetPurchaseHistory 获取用户购买历史
            var userPurchaseHistory = GetPurchaseHistory(userId);
            if (userPurchaseHistory == null || !userPurchaseHistory.Any())
            {
                // 如果用户没有购买历史，返回空推荐列表
                return new List<Product>();
            }

            // 对每个购买的商品，查找相关商品并添加到推荐列表
            var recommendedProducts = new List<Product>();
            foreach (var productId in userPurchaseHistory)
            {
                var relatedProducts = _products.FirstOrDefault(p => p.Id == productId)? RELATEDProductIds;
                if (relatedProducts != null)
                {
                    recommendedProducts.AddRange(relatedProducts.Select(p => _products.FirstOrDefault(pr => pr.Id == p)));
                }
            }

            // 去重并返回推荐列表
            return recommendedProducts.DistinctBy(p => p.Id).ToList();
        }

        // 假设的方法，用于获取用户购买历史
        private List<int> GetPurchaseHistory(int userId)
        {
            // 这里应该从数据库或缓存中获取用户购买历史
            // 为了示例，这里返回空列表
            return new List<int>();
        }
    }

    // 程序入口
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Product A", RELATEDProductIds = new List<int> { 2, 3 } },
                    new Product { Id = 2, Name = "Product B", RELATEDProductIds = new List<int> { 1, 4 } },
                    new Product { Id = 3, Name = "Product C", RELATEDProductIds = new List<int> { 1, 4 } },
                    new Product { Id = 4, Name = "Product D", RELATEDProductIds = new List<int> { 2, 3 } }
                };

                var recommendationEngine = new ProductRecommendationEngine(products);
                var recommendedProducts = recommendationEngine.RecommendProducts(1);

                foreach (var product in recommendedProducts)
                {
                    Console.WriteLine($"Recommended Product: {product.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
