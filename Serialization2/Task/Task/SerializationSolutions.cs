using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.DB;
using Task.TestHelpers;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace Task
{
	[TestClass]
	public class SerializationSolutions
	{
		Northwind dbContext;

		[TestInitialize]
		public void Initialize()
		{
			dbContext = new Northwind();
		}

		[TestMethod]
		public void ISerializable()
		{
            dbContext.Configuration.LazyLoadingEnabled = false;
            dbContext.Configuration.ProxyCreationEnabled = false;
			var tester = new XmlDataContractSerializerTester<IEnumerable<Product>>(new NetDataContractSerializer(), true);
            var t = (dbContext as IObjectContextAdapter).ObjectContext;
            var products = dbContext.Products.ToList();
            foreach (var product in products)
            {
                t.LoadProperty(product, f => f.Category);
            }
            
            tester.SerializeAndDeserialize(products);
		}

        [TestMethod]
        public void ISerializable2()
        {
            dbContext.Configuration.LazyLoadingEnabled = false;
            dbContext.Configuration.ProxyCreationEnabled = false;
            var tester = new XmlDataContractSerializerTester<IEnumerable<Product>>(new NetDataContractSerializer(), true);
            var products = dbContext.Products.Include("Category").AsNoTracking().ToList();

            tester.SerializeAndDeserialize(products);
        }

        [TestMethod]
        public void ISerializable3()
        {
            dbContext.Configuration.LazyLoadingEnabled = false;
            dbContext.Configuration.ProxyCreationEnabled = false;
            var tester = new XmlDataContractSerializerTester<IEnumerable<Product>>(new NetDataContractSerializer(), true);
            var products = dbContext.Products.ToList().Select(x=> new Product() { ProductID = 1, Category = new Category() { CategoryID = 1} }).ToList();

            tester.SerializeAndDeserialize(products);
        }

        [TestMethod]
		public void ISerializationSurrogate()
		{
			dbContext.Configuration.ProxyCreationEnabled = false;
            using (Stream stream = new MemoryStream())
            {
                SurrogateSelector ss = new SurrogateSelector();

                ss.AddSurrogate(typeof(Order_Detail),
                new StreamingContext(StreamingContextStates.All),
                new SerializationSurrogate());

                IFormatter formatter = new NetDataContractSerializer();

                formatter.SurrogateSelector = ss;

                var orderDetails = dbContext.Order_Details.Include("Product").AsNoTracking().ToList();

                formatter.Serialize(stream,orderDetails);

                stream.Position = 0;

                List<Order_Detail> ord = (List<Order_Detail>)formatter.Deserialize(stream);

                var t = ord;
            }
		}
        public class SerializationSurrogate : ISerializationSurrogate
        {
            public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
            {
                var f = (Order_Detail)obj;
                info.AddValue("Product", f.Product);
            }

            public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
            {
                var f = (Order_Detail)obj;
                f.Product = (Product)info.GetValue("Product", typeof(Product));
                return f;
            }
        }
    }
}
