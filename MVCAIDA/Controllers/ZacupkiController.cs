using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MVCAIDA.Models;
using System.Net;

namespace MVCAIDA.Controllers
{
    public class ZacupkiController : Controller
    {

    
            private ProductDBContext db = new ProductDBContext();

            // GET: /Movies/
            public ActionResult Index()
            {
                return View(db.ProductModels.ToList());
            }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel movie = db.ProductModels.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }









        string connectionString = @"Data Source=DESKTOP-HPCIQLA\SQLEXPRESS;Initial Catalog=MVCAIDA;Integrated Security=True";
        [HttpGet]
        // GET: Zacupki
        public ActionResult Index1()
        {
            DataTable dtbProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Zacupki", sqlCon);
                sqlData.Fill(dtbProduct);
            }
            return View(dtbProduct);
        }

        [HttpGet]
        // GET: Zacupki/Create
        public ActionResult Create()
        {   
            return View(new ProductModel());
        }

        // POST: Zacupki/Create
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO Zacupki VALUES(@Name, @Type, @Region, @Organization,  @Since, @End, @Status)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Name", productModel.Name);
                    sqlCmd.Parameters.AddWithValue("@Type", productModel.Type);
                    sqlCmd.Parameters.AddWithValue("@Region", productModel.Region);
                    sqlCmd.Parameters.AddWithValue("@Organization", productModel.Organization);              
                    sqlCmd.Parameters.AddWithValue("@Since", productModel.Since);
                    sqlCmd.Parameters.AddWithValue("@End", productModel.End);
                    sqlCmd.Parameters.AddWithValue("@Status", productModel.Status);
                    sqlCmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
         
        }


    // GET: Zacupki/Edit/5
    public ActionResult Edit(int id)
        {
            ProductModel productModel = new ProductModel();
            DataTable dtbProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDat = new SqlDataAdapter("SELECT * FROM Zacupki WHERE ProductID = @ProductID", sqlCon);
                sqlDat.SelectCommand.Parameters.AddWithValue("@ProductID", id);
                sqlDat.Fill(dtbProduct);
            }
            if (dtbProduct.Rows.Count == 1)
            {
                //productModel.ProductID = Convert.ToInt32(dtbProduct.Rows[0][0].ToString());
                productModel.Name = dtbProduct.Rows[0][1].ToString();
                productModel.Type = dtbProduct.Rows[0][2].ToString();
                productModel.Region = dtbProduct.Rows[0][3].ToString();
                productModel.Organization = dtbProduct.Rows[0][4].ToString();
                productModel.Since = dtbProduct.Rows[0][5].ToString();
                productModel.End = dtbProduct.Rows[0][6].ToString();
                productModel.Status = dtbProduct.Rows[0][7].ToString();
                return View(productModel);
            }
            else
            {
                return Redirect("Index");
            }
        }

        // POST: Zacupki/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel productModel)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Zacupki SET Name = @Name, Type = @Type, Region = @Region, Organization = @Organization, Since = @Since, End = @End, Status = @Status  WHERE ProductID = @ProductID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    //sqlCmd.Parameters.AddWithValue("@ProductID", productModel.ProductID);
                    sqlCmd.Parameters.AddWithValue("@Name", productModel.Name);
                    sqlCmd.Parameters.AddWithValue("@Type", productModel.Type);
                    sqlCmd.Parameters.AddWithValue("@Region", productModel.Region);
                    sqlCmd.Parameters.AddWithValue("@Organization", productModel.Organization);
                    sqlCmd.Parameters.AddWithValue("@Since", productModel.Since);
                    sqlCmd.Parameters.AddWithValue("@End", productModel.End);
                    sqlCmd.Parameters.AddWithValue("@Status", productModel.Status);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zacupki/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Zacupki  WHERE ProductID=@ProductID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProductID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Flat()
        {
            //float x = Convert.ToInt32(Console.ReadLine());
            //float y= Convert.ToInt32(Console.ReadLine());
            //float z = x * y;
            //return z;
            ViewBag.Message = "Your project page.";
            return View();
        }
    }

}
