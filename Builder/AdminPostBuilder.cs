using MiddelClass.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MiddelClass.Builder
{
    public class AdminPostBuilder
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiddleClass"].ConnectionString;

        //===== Brands Start ======>
        #region Brands
        public void SaveUpdateBrands(BrandsModel brand)
        {
            var Action = string.Empty;
            if (brand.ID != 0)
            {
                Action = "Update";
                brand.Uby = brand.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateBrands", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", brand.ID);
                    cmd.Parameters.AddWithValue("@BrandsName", brand.BrandsName);
                    cmd.Parameters.AddWithValue("@BrandsImage", brand.BrandsImage);
                    cmd.Parameters.AddWithValue("@cby", brand.Cby);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string DeleteBrandsById(int ID)
        {
            string msg = string.Empty;
            BrandsModel userdata = new BrandsModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteBrandsById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Brands
        //===== Brands End ======>

        //===== Size Start =====>
        #region Size
        public void SaveUpdateSize(SizeModel size)
        {
            var Action = string.Empty;
            if (size.ID != 0)
            {
                Action = "Update";
                size.Uby = size.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateSize", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", size.ID);
                    cmd.Parameters.AddWithValue("@Cby", size.Cby);
                    cmd.Parameters.AddWithValue("@SizeName", size.SizeName);
                    cmd.Parameters.AddWithValue("@SizeValue", size.SizeValue);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        public string DeleteSizeById(int ID)
        {
            string msg = string.Empty;
            SizeModel userdata = new SizeModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteSizeById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Size
        //===== Size End =====>

        //===== Material Start =====>
        #region Material
        public void SaveUpdateMaterial(MaterialModel material)
        {
            var Action = string.Empty;
            if (material.ID != 0)
            {
                Action = "Update";
                material.Uby = material.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateMaterial", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", material.ID);
                    cmd.Parameters.AddWithValue("@Cby", material.Cby);
                    cmd.Parameters.AddWithValue("@MaterialName", material.MaterialName);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        public string DeleteMaterialById(int ID)
        {
            string msg = string.Empty;
            MaterialModel userdata = new MaterialModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteMaterialById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Material
        //===== Material End =====>

        //===== Color Start =====>
        #region Color
        public void SaveUpdateColor(ColorModel color)
        {
            var Action = string.Empty;
            if (color.ID != 0)
            {
                Action = "Update";
                color.Uby = color.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateColor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", color.ID);
                    cmd.Parameters.AddWithValue("@Cby", color.Cby);
                    cmd.Parameters.AddWithValue("@ColorName", color.ColorName);
                    cmd.Parameters.AddWithValue("@ColorCode", color.ColorCode);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        public string DeleteColorById(int ID)
        {
            string msg = string.Empty;
            ColorModel userdata = new ColorModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteColorById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Color
        //===== Color End =====>

        //===== Category Start =====>
        #region Category

        public void SaveUpdateCategory(CategoryModel category)
        {
            var Action = string.Empty;
            if (category.ID != 0)
            {
                Action = "Update";
                category.Uby = category.Cby;
            }
            else
            {
                Action = "Insert";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", category.ID);
                    cmd.Parameters.AddWithValue("@Cby", category.Cby);
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public string DeleteCategoryById(int ID)
        {
            string msg = string.Empty;
            CategoryModel userdata = new CategoryModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteCategoryById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion Category
        //===== Category End =====>

        //===== SummerEdit Start =====>
        #region SummerEdit

        public void SaveUpdateSummerEdit(SummerEditModel summer)
        {
            var Action = summer.ID != 0 ? "Update" : "Insert";
            if (summer.ID != 0)
            {
                summer.Uby = summer.Cby;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateSummerEdit1", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", summer.ID);
                    cmd.Parameters.AddWithValue("@Material", summer.Material);
                    cmd.Parameters.AddWithValue("@ProductId", summer.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", summer.Quantity);
                    cmd.Parameters.AddWithValue("@Badge", summer.Badge);
                    cmd.Parameters.AddWithValue("@Category", summer.Category);
                    cmd.Parameters.AddWithValue("@ProductName", summer.ProductName);
                    cmd.Parameters.AddWithValue("@Description", summer.Description);
                    cmd.Parameters.AddWithValue("@DiscountPercentage", summer.DiscountPercentage);
                    cmd.Parameters.AddWithValue("@DiscountedPrice", summer.DiscountPrice);
                    cmd.Parameters.AddWithValue("@Price", summer.Price);
                    cmd.Parameters.AddWithValue("@cby", summer.Cby);
                    cmd.Parameters.AddWithValue("@Status", summer.Status);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    // ✅ Convert List<int> to comma-separated string for Color and Size
                    cmd.Parameters.AddWithValue("@ColorIDs", string.IsNullOrEmpty(summer.Color) ? (object)DBNull.Value : summer.Color);
                    cmd.Parameters.AddWithValue("@SizeIDs", string.IsNullOrEmpty(summer.Size) ? (object)DBNull.Value : summer.Size);

                    // ✅ Handle Image and AllImages properly
                    cmd.Parameters.AddWithValue("@Image", string.IsNullOrEmpty(summer.Image) ? (object)DBNull.Value : summer.Image);
                    cmd.Parameters.AddWithValue("@AllImages", string.IsNullOrEmpty(summer.AllImages) ? (object)DBNull.Value : summer.AllImages);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string DeleteSummerEditById(int ID)
        {
            string msg = string.Empty;
            CategoryModel userdata = new CategoryModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteSummerEditById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }
        #endregion SummerEdit
        //===== SummerEdit End =====>

        //===== Product Start =====>
        #region Product

        public void SaveUpdateProduct(ProductModel product)
        {
            var Action = product.ID != 0 ? "Update" : "Insert";
            if (product.ID != 0)
            {
                product.Uby = product.Cby;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SaveUpdateProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", product.ID);
                    cmd.Parameters.AddWithValue("@Material", product.Material);
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@Badge", product.Badge);
                    cmd.Parameters.AddWithValue("@Category", product.Category);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@DiscountPercentage", product.DiscountPercentage);
                    cmd.Parameters.AddWithValue("@DiscountedPrice", product.DiscountPrice);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@cby", product.Cby);
                    cmd.Parameters.AddWithValue("@Status", product.Status);
                    cmd.Parameters.AddWithValue("@ColorIDs", string.IsNullOrEmpty(product.Color) ? (object)DBNull.Value : product.Color);
                    cmd.Parameters.AddWithValue("@SizeIDs", string.IsNullOrEmpty(product.Size) ? (object)DBNull.Value : product.Size);
                    cmd.Parameters.AddWithValue("@Image", string.IsNullOrEmpty(product.Image) ? (object)DBNull.Value : product.Image);
                    cmd.Parameters.AddWithValue("@AllImages", string.IsNullOrEmpty(product.AllImages) ? (object)DBNull.Value : product.AllImages);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string DeleteProductById(int ID)
        {
            string msg = string.Empty;
            ProductModel userdata = new ProductModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteProductById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    msg = cmd.CommandText;
                }
            }

            return msg;
        }

        #endregion Product
        //===== Product End =====>
    }
}