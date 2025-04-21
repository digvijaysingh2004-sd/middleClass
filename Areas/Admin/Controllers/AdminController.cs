using MiddelClass.Builder;
using MiddelClass.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiddelClass.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiddleClass"].ConnectionString;
        AdminGetBuilder AGB = new AdminGetBuilder();
        AdminPostBuilder APB = new AdminPostBuilder();

        public ActionResult Index()
        {
            return View();
        }

        //====== Brands Start =====>
        #region Brands

        public ActionResult Brands()
        {
            List<BrandsModel> brand = new List<BrandsModel>();
            brand = AGB.GetBrands();
            return View(brand);
        }

        public ActionResult GetBrands()
        {
            var brand = AGB.GetBrands();
            return Json(brand, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBrandsById(int ID)
        {
            BrandsModel brand = new BrandsModel();
            brand = AGB.GetBrandsById(ID);
            return Json(brand, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveUpdateBrands(BrandsModel brand)
        {
            HttpFileCollectionBase files = Request.Files;
            var imageUrl = Request.Form["IMAGE  URL"];
            if (brand.ID != 0)
            {
                imageUrl = AGB.GetBrandsImage(brand.ID);
            }
            try
            {
                // Handle file uploads
                var imagedata = string.Empty;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        string FileName = brand.BrandsName + "" + DateTime.Now.ToString("yyyyMMddHHmmss") + "" + fname;
                        imagedata = "/UploadedImages/" + FileName;
                        fname = Path.Combine(Server.MapPath("/UploadedImages/"), FileName);
                        brand.BrandsImage = imagedata;
                        file.SaveAs(fname);
                    }
                }

                // If no file was uploaded, use the existing URL
                if (string.IsNullOrEmpty(brand.BrandsImage) && !string.IsNullOrEmpty(imageUrl))
                {
                    brand.BrandsImage = imageUrl;
                }

                brand.Cby = Session["name"].ToString();
                APB.SaveUpdateBrands(brand);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log the exception for further debugging
                Console.WriteLine(ex.Message);
                return Json(new { success = false, message = "Error storing the details: " + ex.Message });
            }
        }

        public ActionResult DeleteBrandsById(int ID)
        {
            string msg = string.Empty;
            msg = APB.DeleteBrandsById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion Brands
        //===== Brands End ======>

        //===== Category Start =====>
        #region Category
        public ActionResult Category()
        {
            List<CategoryModel> category = new List<CategoryModel>();
            category = AGB.GetCategory();
            return View(category);
        }

        public ActionResult GetCategory()
        {
            var category = AGB.GetCategory();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryById(int ID)
        {
            CategoryModel category = new CategoryModel();
            category = AGB.GetCategoryById(ID);
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveCategoryUpdate(CategoryModel category)
        {
            if (category.CategoryName != null)
            {
                category.Cby = (string)Session["CategoryName"];
                APB.SaveUpdateCategory(category);
                return RedirectToAction("Category");
            }
            return RedirectToAction("Category");
        }

        public ActionResult DeleteCategoryById(int ID)
        {
            string msg = string.Empty;
            msg = APB.DeleteCategoryById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion Category
        //===== Category End =====>

        //===== Size Start =====>
        #region Size
        
        public ActionResult Size()
        {
            List<SizeModel> size = new List<SizeModel>();
            size = AGB.GetSize();
            return View(size);
        }
        public ActionResult GetSize()
        {
            var data = AGB.GetSize();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSizeById(int ID)
        {
            SizeModel size = new SizeModel();
            size = AGB.GetSizeById(ID);
            return Json(size, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveSizeUpdate(SizeModel size)
        {
            if (size.SizeName != null)
            {
                size.Cby = (string)Session["SizeName"];
                APB.SaveUpdateSize(size);
                return RedirectToAction("Size");
            }
            return RedirectToAction("Size");
        }

        public ActionResult DeleteSizeById(int ID)
        {
            string msg = string.Empty;
            msg = APB.DeleteSizeById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion Size
        //===== Size End =====>

        //===== Material Start =====>
        #region Material

        public ActionResult Material()
        {
            List<MaterialModel> material = new List<MaterialModel>();
            material = AGB.GetMaterial();
            return View(material);
        }

        public ActionResult GetMaterial()
        {
            var material = AGB.GetMaterial();
            return Json(material, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMaterialById(int ID)
        {
            MaterialModel material = new MaterialModel();
            material = AGB.GetMaterialById(ID);
            return Json(material, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveMaterialUpdate(MaterialModel material)
        {
            if (material.MaterialName != null)
            {
                material.Cby = (string)Session["MaterialName"];
                APB.SaveUpdateMaterial(material);
                return RedirectToAction("Material");
            }
            return RedirectToAction("Material");
        }

        public ActionResult DeleteMaterialById(int ID)
        {
            string msg = string.Empty;
            msg = APB.DeleteMaterialById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion Material
        //===== Material End =====>

        //===== Color Start =====>
        #region Color

        public ActionResult Color()
        {
            List<ColorModel> color = new List<ColorModel>();
            color = AGB.GetColor();
            return View(color);
        }

        public ActionResult GetColor()
        {
            var data = AGB.GetColor();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColorById(int ID)
        {
            ColorModel color = new ColorModel();
            color = AGB.GetColorById(ID);
            return Json(color, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveColorUpdate(ColorModel color)
        {
            if (color.ColorName != null)
            {
                color.Cby = Session["name"].ToString();
                APB.SaveUpdateColor(color);
                return RedirectToAction("Color");
            }
            return RedirectToAction("Color");
        }

        public ActionResult DeleteColorById(int ID)
        {
            string msg = string.Empty;
            msg = APB.DeleteColorById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion Color
        //===== Color End =====>

        //===== SummerEdit Start =====>
        #region SummerEdit

        public ActionResult SummerEdit()
        {
            List<SummerEditModel> summer = new List<SummerEditModel>();
            summer = AGB.GetSummerEdit();
            return View(summer);
        }

        [HttpPost]
        public ActionResult SaveUpdateSummerEdit(SummerEditModel model)
        {
            HttpFileCollectionBase files = Request.Files;
            var imageUrl = Request.Form["IMAGE  URL"];
            List<string> imagePaths = new List<string>();

            if (model.ID != 0 && imageUrl == null)
            {
                imageUrl = AGB.GetSummerEditImage(model.ID);
            }

            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Unique file name using timestamp
                        string FileName = model.ProductName + "  " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "  " + fname;
                        string imagePath = "/UploadedImages/" + FileName;
                        string savePath = Path.Combine(Server.MapPath("/UploadedImages/"), FileName);

                        file.SaveAs(savePath);
                        imagePaths.Add(imagePath);
                    }
                }

                // Save first image separately
                if (imagePaths.Count > 0)
                {
                    model.Image = imagePaths[0]; // First image
                }
                else if (string.IsNullOrEmpty(model.Image) && !string.IsNullOrEmpty(imageUrl))
                {
                    model.Image = imageUrl; // Use existing image if no new one uploaded
                }

                // Save all images in comma-separated format
                model.AllImages = string.Join(", ", imagePaths);

                //model.Cby = Session["name"].ToString();
                APB.SaveUpdateSummerEdit(model);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public JsonResult GetSummerEditById(int ID)
        {
            SummerEditModel product = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetSummerEditById", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new SummerEditModel
                            {
                                ID = Convert.ToInt32(reader["ID"].ToString()),
                                ProductId = reader["ProductId"].ToString(),
                                Badge = reader["Badge"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Description = reader["Description"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                                Price = Convert.ToDecimal(reader["Price"]),
                                DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                                DiscountPrice = Convert.ToDecimal(reader["DiscountPrice"]),
                                Image = reader["Image"].ToString(),
                                AllImages = reader["AllImages"].ToString(),
                                Category = reader["Category"] != DBNull.Value ? Convert.ToInt32(reader["Category"]) : 0,
                                Material = reader["Material"] != DBNull.Value ? Convert.ToInt32(reader["Material"]) : 0,
                                Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : "",
                                Size = reader["Size"] != DBNull.Value ? reader["Size"].ToString() : "",
                            };
                        }
                    }
                }
            }
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteSummerEditById(int ID)
        {
            string msg = string.Empty;
            msg = APB.DeleteSummerEditById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion SummerEdit
        //===== SummerEdit End =====>

        //===== Product Start =====>
        #region Product

        public ActionResult Product()
        {
            List<ProductModel> product = new List<ProductModel>();
            product = AGB.GetProduct();
            return View(product);
        }

        [HttpPost]
        public ActionResult SaveUpdateProduct(ProductModel model)
        {
            HttpFileCollectionBase files = Request.Files;
            var imageUrl = Request.Form["IMAGE  URL"];
            List<string> imagePaths = new List<string>();

            if (model.ID != 0 && imageUrl == null)
            {
                imageUrl = AGB.GetProductImage(model.ID);
            }

            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Unique file name using timestamp
                        string FileName = model.ProductName + "  " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "  " + fname;
                        string imagePath = "/UploadedImages/" + FileName;
                        string savePath = Path.Combine(Server.MapPath("/UploadedImages/"), FileName);

                        file.SaveAs(savePath);
                        imagePaths.Add(imagePath);
                    }
                }

                // Save first image separately
                if (imagePaths.Count > 0)
                {
                    model.Image = imagePaths[0]; // First image
                }
                else if (string.IsNullOrEmpty(model.Image) && !string.IsNullOrEmpty(imageUrl))
                {
                    model.Image = imageUrl; // Use existing image if no new one uploaded
                }

                // Save all images in comma-separated format
                model.AllImages = string.Join(", ", imagePaths);

                //model.Cby = Session["name"].ToString();
                APB.SaveUpdateProduct(model);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public JsonResult GetProductById(int ID)
        {
            ProductModel product = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetProductById", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new ProductModel
                            {
                                ID = Convert.ToInt32(reader["ID"].ToString()),
                                ProductId = reader["ProductId"].ToString(),
                                Badge = reader["Badge"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Description = reader["Description"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                                Price = Convert.ToDecimal(reader["Price"]),
                                DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                                DiscountPrice = Convert.ToDecimal(reader["DiscountPrice"]),
                                Image = reader["Image"].ToString(),
                                AllImages = reader["AllImages"].ToString(),
                                Category = reader["Category"] != DBNull.Value ? Convert.ToInt32(reader["Category"]) : 0,
                                Material = reader["Material"] != DBNull.Value ? Convert.ToInt32(reader["Material"]) : 0,
                                Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : "",
                                Size = reader["Size"] != DBNull.Value ? reader["Size"].ToString() : "",
                            };
                        }
                    }
                }
            }
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteProductById(int ID)
        {
            string msg = string.Empty;
            msg = APB.DeleteProductById(ID);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion Product
        //===== Product End =====>
    }
}