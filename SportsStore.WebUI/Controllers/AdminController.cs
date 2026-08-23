using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _repository;

        public AdminController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index() => View(_repository.Products);

        //Action Get de hien thi form tao moi
        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public async Task<IActionResult> Create(Product product , IFormFile? image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    //tao duong dan luu file
                    var fileName = Guid.NewGuid().ToString()+ Path.GetExtension(image.FileName);
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images" ,fileName);
                    //luu file
                    using(var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    //cap nhat duong dan anh cho san pham;
                    product.ImgUrl = "/images/" + fileName;

                    _repository.SaveProduct(product);
                    TempData["message"] = $"{product.Name} has been save";
                    return RedirectToAction("Index");
                }
               
            }
            //Neu co loi tra ve view voi du lieu da nhap
            return View("Edit", product);
        }

        public ViewResult Edit(int productId) => View(_repository.Products.FirstOrDefault(p => p.ProductId == productId));

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile? image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    Product? pr = _repository.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                    //xoa file anh cu neu co
                    if (!string.IsNullOrEmpty(pr.ImgUrl))
                    {
                        string paht = pr.ImgUrl.TrimStart('/');
                        var imagePath =
                            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", paht);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                    }
                    //tao duong dan luu file
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);
                    //luu file
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    //cap nhat duong dan anh cho san pham;
                    product.ImgUrl = "/images/" + fileName;

                    _repository.SaveProduct(product);
                    TempData["message"] = $"{product.Name} has been save";
                    return RedirectToAction("Index");
                }

            }
            //Neu co loi tra ve view voi du lieu da nhap
            return View( product);
        }

        [HttpPost]
        public IActionResult Delete (int productID)
        {
            Product? deletedProduct = _repository.DeleteProduct(productID);

            if(deletedProduct != null)
            {
                //xoa file anh lien quan
                if (!string.IsNullOrEmpty(deletedProduct.ImgUrl))
                {
                    string paht = deletedProduct.ImgUrl.TrimStart('/');
                    var imagePath =
                        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", paht);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                }
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }

            return RedirectToAction("Index");
        }
    }

   
}
