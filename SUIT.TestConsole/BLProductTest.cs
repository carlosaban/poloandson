
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.Recetas.BE;
using SUIT.Recetas.BL;


using System.Configuration;


namespace SUIT.TestConsole
{
    
    public class BL_ProductTest
    {
        public BL_ProductTest()
        {
            List<VE_Product> lista = BL_ProductTest.get();
            BE_Product obj = lista.Count == 0 ? new BE_Product() { } : (BE_Product)lista[0];
            obj.code = obj.code + "777";
            //obj = BL_ProductTest.create((BE_Product)obj);

            BL_ProductTest.Update(obj);
            BL_ProductTest.Delete(obj);



        }

        private static void Delete(BE_Product BE_Product)
        {
            try
            {
                BL_Product BL_Product = new BL_Product();
                BL_Product.connectionString = ConfigurationManager.ConnectionStrings["pagosapp"].ConnectionString; ;
                
                int result = BL_Product.DeleteProduct(BE_Product.productId);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Update(BE_Product BE_Product)
        {
            try
            {
                BL_Product BL_Product = new BL_Product();
                BL_Product.connectionString = ConfigurationManager.ConnectionStrings["pagosapp"].ConnectionString; ;
                
                BE_Product result = BL_Product.UpdateProduct(BE_Product);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<VE_Product> get()
        {
            try
            {
                BL_Product BL_Product = new BL_Product();
                BL_Product.connectionString = ConfigurationManager.ConnectionStrings["pagosapp"].ConnectionString; ;
                List<VE_Product> list = BL_Product.GetProduct();


                return list;



            }
            catch (Exception ex)
            {

                throw;
            }

            //return new List<VE_Product>();

        }
        public static BE_Product create(BE_Product view)
        {
            try
            {

                BL_Product BL_Product = new BL_Product();
                //view..UserAudit = "carlosaban";
                BL_Product.connectionString = ConfigurationManager.ConnectionStrings["pagosapp"].ConnectionString; ;
                BE_Product result = BL_Product.CreateProduct(view);
                return result;



            }
            catch (Exception ex)
            {

                throw ex;

            }


        }


    }
}
