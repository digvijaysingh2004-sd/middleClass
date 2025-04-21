    using MiddelClass.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiddelClass.Builder
{
    public class AdminGetBuilder
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiddleClass"].ConnectionString;

        //===== Brands Start =====>
        #region Brands
        public List<BrandsModel> GetBrands()
        {
            List<BrandsModel> branddata = new List<BrandsModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetBrands", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BrandsModel brand = new BrandsModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0,
                                BrandsImage = reader["BrandsImage"].ToString(),
                                BrandsName = reader["BrandsName"].ToString(),
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            branddata.Add(brand);
                        }
                    }
                }
            }
            return branddata;
        }

        public string GetBrandsImage(int ID)
        {
            string IMAGE = string.Empty;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetBrandsImage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IMAGE = reader["BrandsImage"].ToString();
                        }
                    }
                }
            }
            return IMAGE;
        }

        public BrandsModel GetBrandsById(int ID)
        {
            BrandsModel brand = new BrandsModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetBrandsById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            brand.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            brand.BrandsImage = reader["BrandsImage"].ToString();
                            brand.BrandsName = reader["BrandsName"].ToString();
                        }
                    }
                }
            }

            return brand;
        }
        #endregion Brands
        //===== Brands End =====>

        //===== Size Start =====>
        #region Size 
        public List<SizeModel> GetSize()
        {
            List<SizeModel> userdata = new List<SizeModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSize", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SizeModel size = new SizeModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                SizeName = reader["SizeName"].ToString(),
                                SizeValue = reader["SizeValue"] != DBNull.Value ? Convert.ToInt32(reader["Sizevalue"]) : 0,
                                Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0,
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(size);
                        }
                    }
                }
            }

            return userdata;
        }

        public SizeModel GetSizeById(int ID)
        {
            SizeModel size = new SizeModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSizeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            size.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            size.SizeName = reader["SizeName"].ToString();
                            size.SizeValue = Convert.ToInt32(reader["SizeValue"].ToString());


                        }
                    }
                }
            }

            return size;
        }
        #endregion size
        //===== Size End =====>

        //===== Material Start =====>
        #region Material
        public List<MaterialModel> GetMaterial()
        {
            List<MaterialModel> userdata = new List<MaterialModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetMaterial", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MaterialModel material = new MaterialModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                MaterialName = reader["MaterialName"].ToString(),
                                Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0,
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(material);
                        }
                    }
                }
            }

            return userdata;
        }

        public MaterialModel GetMaterialById(int ID)
        {
            MaterialModel material = new MaterialModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetMaterialById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            material.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            material.MaterialName = reader["MaterialName"].ToString();
                        }
                    }
                }
            }

            return material;
        }
        #endregion Material
        //===== Material End =====>

        //===== Color Start =====>
        #region Color 
        public List<ColorModel> GetColor()
        {
            List<ColorModel> userdata = new List<ColorModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetColor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ColorModel color = new ColorModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                ColorName = reader["ColorName"].ToString(),
                                ColorCode = reader["ColorCode"].ToString(),
                                Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0,
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(color);
                        }
                    }
                }
            }

            return userdata;
        }

        public ColorModel GetColorById(int ID)
        {
            ColorModel color = new ColorModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetColorById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            color.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            color.ColorName = reader["ColorName"].ToString();
                            color.ColorCode = reader["ColorCode"].ToString();
                        }
                    }
                }
            }

            return color;
        }
        #endregion Color
        //===== Color End =====>

        //===== Category Start =====>
        #region Category

        public List<CategoryModel> GetCategory()
        {
            List<CategoryModel> userdata = new List<CategoryModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoryModel category = new CategoryModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                CategoryName = reader["CategoryName"].ToString(),
                                Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0,
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"].ToString(),
                                Uby = reader["Uby"].ToString()
                            };

                            userdata.Add(category);
                        }
                    }
                }
            }

            return userdata;
        }

        public CategoryModel GetCategoryById(int ID)
        {
            CategoryModel category = new CategoryModel();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCategoryById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category.ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0;
                            category.CategoryName = reader["CategoryName"].ToString();
                        }
                    }
                }
            }

            return category;
        }
        #endregion Category
        //===== Category End =====>

        //===== SummerEdit Start =====>
        #region SummerEdit

        public List<SummerEditModel> GetSummerEdit()
        {
            List<SummerEditModel> summerdata = new List<SummerEditModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSummerEdit1", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SummerEditModel summer = new SummerEditModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                DiscountPercentage = reader["DiscountPercentage"] != DBNull.Value ? Convert.ToInt32(reader["DiscountPercentage"]) : 0,
                                Price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0,
                                DiscountPrice = reader["DiscountPrice"] != DBNull.Value ? Convert.ToInt32(reader["DiscountPrice"]) : 0,
                                Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0,
                                Category = reader["Category"] != DBNull.Value ? Convert.ToInt32(reader["Category"]) : 0,
                                Material = reader["Material"] != DBNull.Value ? Convert.ToInt32(reader["Material"]) : 0,
                                Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : string.Empty, // Ensure it's stored as NVARCHAR in DB
                                Size = reader["Size"] != DBNull.Value ? reader["Size"].ToString() : string.Empty,   // Ensure it's stored as NVARCHAR in DB
                                Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0,
                                Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : string.Empty,
                                ProductId = reader["ProductId"] != DBNull.Value ? reader["ProductId"].ToString() : string.Empty,
                                Badge = reader["Badge"] != DBNull.Value ? reader["Badge"].ToString() : string.Empty,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : string.Empty,
                                SizeName = reader["SizeName"] != DBNull.Value ? reader["SizeName"].ToString() : string.Empty,
                                CategoryName = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"].ToString() : string.Empty,
                                MaterialName = reader["MaterialName"] != DBNull.Value ? reader["MaterialName"].ToString() : string.Empty,
                                ColorName = reader["ColorName"] != DBNull.Value ? reader["ColorName"].ToString() : string.Empty,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"] != DBNull.Value ? reader["Cby"].ToString() : string.Empty,
                                Uby = reader["Uby"] != DBNull.Value ? reader["Uby"].ToString() : string.Empty
                            };

                            summerdata.Add(summer);
                        }
                    }
                }
            }
            return summerdata;
        }

        public string GetSummerEditImage(int ID)
        {
            string IMAGE = string.Empty;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSummerEditImage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IMAGE = reader["Image"].ToString();
                        }
                    }
                }
            }
            return IMAGE;
        }
        #endregion SummerEdit
        //===== SummerEdit End =====>

        //===== Product Start =====>
        #region Product

        public List<ProductModel> GetProduct()
        {
            List<ProductModel> productdata = new List<ProductModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                DiscountPercentage = reader["DiscountPercentage"] != DBNull.Value ? Convert.ToInt32(reader["DiscountPercentage"]) : 0,
                                Price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0,
                                DiscountPrice = reader["DiscountPrice"] != DBNull.Value ? Convert.ToInt32(reader["DiscountPrice"]) : 0,
                                Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0,
                                Category = reader["Category"] != DBNull.Value ? Convert.ToInt32(reader["Category"]) : 0,
                                Material = reader["Material"] != DBNull.Value ? Convert.ToInt32(reader["Material"]) : 0,
                                Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : string.Empty, // Ensure it's stored as NVARCHAR in DB
                                Size = reader["Size"] != DBNull.Value ? reader["Size"].ToString() : string.Empty,   // Ensure it's stored as NVARCHAR in DB
                                Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0,
                                Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : string.Empty,
                                ProductId = reader["ProductId"] != DBNull.Value ? reader["ProductId"].ToString() : string.Empty,
                                Badge = reader["Badge"] != DBNull.Value ? reader["Badge"].ToString() : string.Empty,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : string.Empty,
                                SizeName = reader["SizeName"] != DBNull.Value ? reader["SizeName"].ToString() : string.Empty,
                                CategoryName = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"].ToString() : string.Empty,
                                MaterialName = reader["MaterialName"] != DBNull.Value ? reader["MaterialName"].ToString() : string.Empty,
                                ColorName = reader["ColorName"] != DBNull.Value ? reader["ColorName"].ToString() : string.Empty,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                                Cdate = reader["Cdate"] != DBNull.Value ? Convert.ToDateTime(reader["Cdate"]) : (DateTime?)null,
                                Udate = reader["Udate"] != DBNull.Value ? Convert.ToDateTime(reader["Udate"]) : (DateTime?)null,
                                Cby = reader["Cby"] != DBNull.Value ? reader["Cby"].ToString() : string.Empty,
                                Uby = reader["Uby"] != DBNull.Value ? reader["Uby"].ToString() : string.Empty
                            };

                            productdata.Add(product);
                        }
                    }
                }
            }
            return productdata;
        }

        public string GetProductImage(int ID)
        {
            string IMAGE = string.Empty;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetProductImage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IMAGE = reader["Image"].ToString();
                        }
                    }
                }
            }
            return IMAGE;
        }
        #endregion Product
        //===== Product End =====>
    }
}