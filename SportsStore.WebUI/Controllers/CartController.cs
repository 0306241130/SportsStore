using SportsStore.Domain;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.Infarstructure;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        //Dữ liệu giả thay cho dữ liệu thực tế
        private readonly List<Product> _mockDatabase = new List<Product>
        {
            new Product {ProductID = 1 , name = "Giày chạy bộ" , Price = 100},
            new Product {ProductID = 2 , name = "Vợt cầu lông" , Price = 50},
        };

        //Hàm dùng chung moi giỏ hàng từ session
        private Cart GetCart()
        {

            //Gọi hàm GetJson đã viết ở bước 1
            //Nếu session "Cart" rỗng thì tạo mới Cart new Cart()
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            
        }

        //Hành động (Action) hiển thị trang giỏ hàng . 'returnURL' là link trang khách vừa mới đứng

        public IActionResult Index(string returnUrl)
        {
            // nhét returnURL cho ViewBag để View có thể lấy ra làm link cho nút "Quay lại"
            ViewBag.returnUrl = returnUrl;

            return View(GetCart());
        }

        //Đánh dấu [HttpPost] để bảo mật , chỉ cho phép form submit ,chặn việt gõ url trực tiếp
        [HttpPost]
        public IActionResult AddToCart(int productId, string returnUrl)
        {
            Product? product = _mockDatabase.FirstOrDefault(p => p.ProductID == productId);

            if (product != null) // tìm thấy hàng
            { 
                Cart  cart  = GetCart();//1.lấy ra giỏ hàng hiện tại
                cart.AddItem(product,1);//2.Thêm sản phẩm vào giỏ hàng
                HttpContext.Session.SetJson("Cart", cart);// lưu đè giỏ hàng mới vào lại Session

                //Nếu có returnUrl (Khách bấm từ trang thêm danh sách), đá khách về lại trang đó
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }
                //Nếu không có returnUrl đá khách sang trang xem chi tiết giỏ hàng (Action Index ỏ trên)    
              
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFormCart(int productId,string returnUrl)
        {
            Product? product = _mockDatabase.FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product); // Gọi hàm xóa khỏi giỏ;
                HttpContext.Session.SetJson("Cart", cart); // Lưu cập nhật vào Session;
            }
            //xóa xong thì load lại trang giỏ hàng , đồng thời nhớ mang theo returnUrl cũ (nếu có)
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}
