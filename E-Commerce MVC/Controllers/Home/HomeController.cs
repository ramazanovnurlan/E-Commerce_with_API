using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using E_Commerce_MVC.Areas.Admin.Models.AllMenu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace E_Commerce_MVC.Controllers.Home
{
    public class HomeController : Controller
    {
        RestClient client = new RestClient();

        //Index------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Product/getProduct");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getProduct = JsonConvert.DeserializeObject<List<Product>>(context);

            return View(getProduct);
        }

        //Shop-------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> Shop()
        {
            Product_and_ProductFilter list = new Product_and_ProductFilter();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Product/getProduct");
            var response1 = await client.ExecuteAsync(request, CancellationToken.None);
            string context1 = response1.Content;
            var getProduct = JsonConvert.DeserializeObject<List<Product>>(context1);

            request.Resource = ("http://localhost:59964/api/Product/getFilter");
            var response2 = await client.ExecuteAsync(request, CancellationToken.None);
            string context2 = response2.Content;
            var getFilter = JsonConvert.DeserializeObject<ProductFilter>(context2);

            list.Products = getProduct;
            list.ProductFilter = getFilter;

            return View(list);
        }

        //ProductDetail----------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> ProductDetail(int id)
        {
            ProductDetail list = new ProductDetail();

            RestRequest request1 = new RestRequest(Method.GET);
            request1.Resource = ("http://localhost:59964/api/Product/getProduct");
            var response1 = await client.ExecuteAsync(request1, CancellationToken.None);
            var context1 = response1.Content;
            var getProduct = JsonConvert.DeserializeObject<List<Product>>(context1);

            RestRequest request2 = new RestRequest(Method.GET);
            request2.Resource = ("http://localhost:59964/api/Product/getPicture");
            var response2 = await client.ExecuteAsync(request2, CancellationToken.None);
            var context2 = response2.Content;
            var getPicture = JsonConvert.DeserializeObject<List<Pictures>>(context2);

            list.Product = getProduct.Where(x => x.ID == id).FirstOrDefault();
            list.Pictures = getPicture.Where(x => x.ProductId == id).ToList();

            return View(list);
        }

        //Filter Products--------------------------------------------------------------------------//

        public async Task<IActionResult> SelectedProducts(int submenuID, int[] brandID, int minPrice, int maxPrice, int[] colorID, int[] opSystemID, int[] processorID, int[] ramID, int[] storageID, int[] ssdID, int[] graphicsCardID, int[] styleJoinID, int[] frontCameraID, int[] rearCameraID)
        {
            ProductFilter productFilter = new ProductFilter();

            List<Product> selectedProducts = new List<Product>();
            List<Product> brandList = new List<Product>();
            List<Product> colorList = new List<Product>();
            List<Product> opSystemList = new List<Product>();
            List<Product> processorList = new List<Product>();
            List<Product> ramList = new List<Product>();
            List<Product> storageList = new List<Product>();
            List<Product> ssdList = new List<Product>();
            List<Product> graphicsCardList = new List<Product>();
            List<Product> styleJoinList = new List<Product>();
            List<Product> frontCameraList = new List<Product>();
            List<Product> rearCameraList = new List<Product>();


            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Product/product");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getProduct = JsonConvert.DeserializeObject<List<Product>>(context);


            if (brandID.Count() == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
            {
                selectedProducts = getProduct.Where(x => x.SubmenuID == submenuID).ToList();
            }

            //Brand
            if (brandID.Count() == 1)
            {
                if (minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in brandID)
                    {
                        selectedProducts = getProduct.Where(x => x.BrandID == item).ToList();
                    }
                }
                else
                {
                    if (selectedProducts.Count == 0)
                    {
                        foreach (var item in brandID)
                        {
                            selectedProducts = getProduct.Where(x => x.BrandID == item).ToList();
                        }
                    }
                    else
                    {
                        foreach (var item in brandID)
                        {
                            selectedProducts = selectedProducts.Where(x => x.BrandID == item).ToList();
                        }
                    }
                    
                }
            }
            else if (brandID.Count() > 1)
            {
                if (minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in brandID)
                    {
                        brandList.AddRange(getProduct.Where(x => x.BrandID == item).ToList());
                    }
                    selectedProducts = brandList;
                }
                else
                {
                    if (selectedProducts.Count == 0)
                    {
                        foreach (var item in brandID)
                        {
                            brandList.AddRange(getProduct.Where(x => x.BrandID == item).ToList());
                        }
                        selectedProducts = brandList;
                    }
                    else
                    {
                        foreach (var item in brandID)
                        {
                            brandList.AddRange(selectedProducts.Where(x => x.BrandID == item).ToList());
                        }
                        selectedProducts = brandList;
                    }
                }
            }

            //Price
            if (0 < minPrice && 0 < maxPrice)
            {
                if (brandID.Count() == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    selectedProducts = getProduct.Where(d => (int)d.Price >= minPrice && (int)d.Price <= maxPrice).ToList();
                }
                else
                {
                    if (selectedProducts.Count == 0)
                    {
                        selectedProducts = getProduct.Where(d => (int)d.Price >= minPrice && (int)d.Price <= maxPrice).ToList();
                    }
                    else
                    {
                        selectedProducts = selectedProducts.Where(d => (int)d.Price >= minPrice && (int)d.Price <= maxPrice).ToList();
                    }
                }
            }
            else if (minPrice == 0 && maxPrice == 0)
            {
                selectedProducts.ToList();
            }
            else if (minPrice == 0)
            {
                if (brandID.Count() == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    selectedProducts = getProduct.Where(d => (int)d.Price <= maxPrice).ToList();
                }
                else
                {
                    if (selectedProducts.Count == 0)
                    {
                        selectedProducts = getProduct.Where(d => (int)d.Price <= maxPrice).ToList();
                    }
                    else
                    {
                        selectedProducts = selectedProducts.Where(d => (int)d.Price <= maxPrice).ToList();
                    }
                }
            }
            else
            {
                selectedProducts.ToList();
            }
            

            //Color
            if (colorID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in colorID)
                    {
                        selectedProducts = getProduct.Where(x => x.ColorID == item).ToList();
                    }
                }
                else
                {
                    if (selectedProducts.Count == 0)
                    {
                        foreach (var item in colorID)
                        {
                            selectedProducts = getProduct.Where(x => x.ColorID == item).ToList();
                        }
                    }
                    else
                    {
                        foreach (var item in colorID)
                        {
                            selectedProducts = selectedProducts.Where(x => x.ColorID == item).ToList();
                        }
                    }

                }
            }
            else if (colorID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in colorID)
                    {
                        colorList.AddRange(getProduct.Where(x => x.ColorID == item).ToList());
                    }
                    selectedProducts = colorList;
                }
                else
                {
                    if (selectedProducts.Count == 0)
                    {
                        foreach (var item in colorID)
                        {
                            colorList.AddRange(getProduct.Where(x => x.ColorID == item).ToList());
                        }
                        selectedProducts = colorList;
                    }
                    else
                    {
                        foreach (var item in colorID)
                        {
                            colorList.AddRange(selectedProducts.Where(x => x.ColorID == item).ToList());
                        }
                        selectedProducts = colorList;
                    }

                }
            }

            //opSystem
            if (opSystemID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in opSystemID)
                    {
                        selectedProducts = getProduct.Where(x => x.OpSystemID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in opSystemID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.OpSystemID == item).ToList();
                    }
                }
            }
            else if (opSystemID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in opSystemID)
                    {
                        opSystemList.AddRange(getProduct.Where(x => x.OpSystemID == item).ToList());
                    }
                    selectedProducts = opSystemList;
                }
                else
                {
                    foreach (var item in opSystemID)
                    {
                        opSystemList.AddRange(selectedProducts.Where(x => x.OpSystemID == item).ToList());
                    }
                    selectedProducts = opSystemList;
                }
            }

            //Processor
            if (processorID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in processorID)
                    {
                        selectedProducts = getProduct.Where(x => x.ProcessorID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in processorID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.ProcessorID == item).ToList();
                    }
                }
            }
            else if (processorID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in processorID)
                    {
                        processorList.AddRange(getProduct.Where(x => x.ProcessorID == item).ToList());
                    }
                    selectedProducts = processorList;
                }
                else
                {
                    foreach (var item in processorID)
                    {
                        processorList.AddRange(selectedProducts.Where(x => x.ProcessorID == item).ToList());
                    }
                    selectedProducts = processorList;
                }
            }

            //RAM
            if (ramID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in ramID)
                    {
                        selectedProducts = getProduct.Where(x => x.RAMID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in ramID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.RAMID == item).ToList();
                    }
                }
            }
            else if (ramID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in ramID)
                    {
                        ramList.AddRange(getProduct.Where(x => x.RAMID == item).ToList());
                    }
                    selectedProducts = ramList;
                }
                else
                {
                    foreach (var item in ramID)
                    {
                        ramList.AddRange(selectedProducts.Where(x => x.RAMID == item).ToList());
                    }
                    selectedProducts = ramList;
                }
            }

            //Storage
            if (storageID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in storageID)
                    {
                        selectedProducts = getProduct.Where(x => x.StorageID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in storageID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.StorageID == item).ToList();
                    }
                }
            }
            else if (storageID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in storageID)
                    {
                        storageList.AddRange(getProduct.Where(x => x.StorageID == item).ToList());
                    }
                    selectedProducts = storageList;
                }
                else
                {
                    foreach (var item in storageID)
                    {
                        storageList.AddRange(selectedProducts.Where(x => x.StorageID == item).ToList());
                    }
                    selectedProducts = storageList;
                }
            }

            //SSD
            if (ssdID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in ssdID)
                    {
                        selectedProducts = getProduct.Where(x => x.SSDID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in ssdID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.SSDID == item).ToList();
                    }
                }
            }
            else if (ssdID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in ssdID)
                    {
                        ssdList.AddRange(getProduct.Where(x => x.SSDID == item).ToList());
                    }
                    selectedProducts = ssdList;
                }
                else
                {
                    foreach (var item in ssdID)
                    {
                        ssdList.AddRange(selectedProducts.Where(x => x.SSDID == item).ToList());
                    }
                    selectedProducts = ssdList;
                }
            }

            //GraphicsCard
            if (graphicsCardID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in graphicsCardID)
                    {
                        selectedProducts = getProduct.Where(x => x.GraphicsCardID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in graphicsCardID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.GraphicsCardID == item).ToList();
                    }
                }
            }
            else if (graphicsCardID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in graphicsCardID)
                    {
                        graphicsCardList.AddRange(getProduct.Where(x => x.GraphicsCardID == item).ToList());
                    }
                    selectedProducts = graphicsCardList;
                }
                else
                {
                    foreach (var item in graphicsCardID)
                    {
                        graphicsCardList.AddRange(selectedProducts.Where(x => x.GraphicsCardID == item).ToList());
                    }
                    selectedProducts = graphicsCardList;
                }
            }

            //StyleJoin
            if (styleJoinID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in styleJoinID)
                    {
                        selectedProducts = getProduct.Where(x => x.StyleJoinID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in styleJoinID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.StyleJoinID == item).ToList();
                    }
                }
            }
            else if (styleJoinID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && frontCameraID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in styleJoinID)
                    {
                        styleJoinList.AddRange(getProduct.Where(x => x.StyleJoinID == item).ToList());
                    }
                    selectedProducts = styleJoinList;
                }
                else
                {
                    foreach (var item in styleJoinID)
                    {
                        styleJoinList.AddRange(selectedProducts.Where(x => x.StyleJoinID == item).ToList());
                    }
                    selectedProducts = styleJoinList;
                }
            }

            //FrontCamera
            if (frontCameraID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in frontCameraID)
                    {
                        selectedProducts = getProduct.Where(x => x.FrontCameraID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in frontCameraID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.FrontCameraID == item).ToList();
                    }
                }
            }
            else if (frontCameraID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && rearCameraID.Count() == 0)
                {
                    foreach (var item in frontCameraID)
                    {
                        frontCameraList.AddRange(getProduct.Where(x => x.FrontCameraID == item).ToList());
                    }
                    selectedProducts = frontCameraList;
                }
                else
                {
                    foreach (var item in frontCameraID)
                    {
                        frontCameraList.AddRange(selectedProducts.Where(x => x.FrontCameraID == item).ToList());
                    }
                    selectedProducts = frontCameraList;
                }
            }

            //RearCamera
            if (rearCameraID.Count() == 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0)
                {
                    foreach (var item in rearCameraID)
                    {
                        selectedProducts = getProduct.Where(x => x.RearCameraID == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in rearCameraID)
                    {
                        selectedProducts = selectedProducts.Where(x => x.RearCameraID == item).ToList();
                    }
                }
            }
            else if (rearCameraID.Count() > 1)
            {
                if (brandID.Count() == 0 && minPrice == 0 && maxPrice == 0 && colorID.Count() == 0 && opSystemID.Count() == 0 && processorID.Count() == 0 && ramID.Count() == 0 && storageID.Count() == 0 && ssdID.Count() == 0 && graphicsCardID.Count() == 0 && styleJoinID.Count() == 0 && frontCameraID.Count() == 0)
                {
                    foreach (var item in rearCameraID)
                    {
                        rearCameraList.AddRange(getProduct.Where(x => x.RearCameraID == item).ToList());
                    }
                    selectedProducts = rearCameraList;
                }
                else
                {
                    foreach (var item in rearCameraID)
                    {
                        rearCameraList.AddRange(selectedProducts.Where(x => x.RearCameraID == item).ToList());
                    }
                    selectedProducts = rearCameraList;
                }
            }

            productFilter.Products = selectedProducts;

            return PartialView("SelectedProducts", productFilter);
        }

        //Pagination-------------------------------------------------------------------------------//



    }
}
