using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product_Stock
{
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }

    public class ProductsStockReport
    {
        public string HeaderPart { get; set; }

        public string BodyPart { get; set; }

        public string FooterPart { get; set; }

        public override string ToString() =>
            new StringBuilder()
             .AppendLine(HeaderPart)
             .AppendLine(BodyPart)  
             .AppendLine(FooterPart)
             .ToString();
    }

    public interface IProductStockReportBuilder
    {
        void BuildHeader();

        void BuildBody();   
       
        void BuildFooter();

        ProductsStockReport GetProductsStockReport();
    }

    public class ProductsStockReportBuilder : IProductStockReportBuilder
    {
        private IEnumerable<Product> products;

        private ProductsStockReport productsStockReport;

        public ProductsStockReportBuilder(IEnumerable<Product> products)
        {
            this.products = products;
            productsStockReport = new ProductsStockReport();
        }

        public void BuildHeader()
        {
            productsStockReport.HeaderPart = $"STOCK REPORT FOR ALL THE PRODUCTS ON DATE: {DateTime.Now}\n";
        }

        public void BuildBody()
        {
            productsStockReport.BodyPart = string.Join(Environment.NewLine, products.Select(p => $"Product name: {p.Name}, product price: {p.Price}"));
        }

        public void BuildFooter()
        {
            productsStockReport.FooterPart = "\nReport, provided by the SAMPLE_PRODUCTS company";
        }

        public ProductsStockReport GetProductsStockReport()
        {
            return productsStockReport;
        }
    }

    public class ProductsStockReportDirector
    {
        private readonly IProductStockReportBuilder productStockReportBuilder;

        public ProductsStockReportDirector(IProductStockReportBuilder productStockReportBuilder)
        {
            this.productStockReportBuilder = productStockReportBuilder; 
        }

        public void BuildStockReport()
        {
            productStockReportBuilder.BuildHeader();
            productStockReportBuilder.BuildBody();
            productStockReportBuilder.BuildFooter();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product { Name = "Monitor", Price = 200.50 },
                new Product { Name = "Mouse", Price = 20.41 },
                new Product { Name = "Keyboard", Price = 30.15 }
            };

            var productsStockReportBuilder = new ProductsStockReportBuilder(products);

            var productsStockReportDirector = new ProductsStockReportDirector(productsStockReportBuilder);

            productsStockReportDirector.BuildStockReport();

            var report = productsStockReportBuilder.GetProductsStockReport();

            Console.WriteLine(report);
        }
    }
}
