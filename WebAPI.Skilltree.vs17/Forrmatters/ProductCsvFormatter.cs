﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using WebAPI.Skilltree.vs17.Models;

namespace WebAPI.Skilltree.vs17.Forrmatters
{
    public class ProductCsvFormatter : BufferedMediaTypeFormatter
    {
        public ProductCsvFormatter()
        {
            // 加入 "text/csv" 到支援清單
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            if (type == typeof(Product))
            {
                return true;
            }
            else
            {
                Type enumerableType = typeof(IEnumerable<Product>);
                return enumerableType.IsAssignableFrom(type);
            }
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                // 集合
                var products = value as IEnumerable<Product>;
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        WriteItem(product, writer);
                    }
                }
                else
                {
                    // 單一
                    var singleProduct = value as Product;
                    if (singleProduct == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }
                    WriteItem(singleProduct, writer);
                }
            }
        }

        // 將 Products 物件序列化 CSV 格式 
        private void WriteItem(Product product, StreamWriter writer)
        {
            writer.WriteLine("{0},{1},{2},{3}",
                            Escape(product.ProductID),
                            Escape(product.ProductName),
                            Escape(product.CategoryID),
                            Escape(product.UnitPrice));
        }

        // CSV格式 非常簡單，它是使用“，”（逗號）來分隔資料項目。
        // 如果碰到一些特別符號可能讓CSV輸出格式出現問題，例如，字串內有“，”（逗點）。
        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };
        private string Escape(object o)
        {
            if (o == null)
            {
                return "";
            }
            string field = o.ToString();
            if (field.IndexOfAny(_specialChars) != -1)
            {
                return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
            }
            else return field;
        }
    }
}