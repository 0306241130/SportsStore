using SportsStore.Domain;
using SportsStore.Infarstructure;
using static System.Collections.Specialized.BitVector32;
namespace SportsStore.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Huỳnh Thế Nghĩa - 0306241130
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IProductRepository, FakeProductRepository>();
            //Bước 1 :Cung câp kho lưu trữ cho sesion
            //Session cần một nơi để cất dữ liệu AddDistributedMemoryCache() cung cấp
            // một kho lưu trữ ngay trong bộ nhớ của server. Đây là lựa chọn đơn giản nhất.
            builder.Services.AddDistributedMemoryCache();
            // BƯỚC 2: Đăng ký dịch vụ Session (Thuê nhân viên trông tủ)
            // Dòng này đăng ký các dịch vụ cần thiết để quản lý việc tạo Session ID,
            // đọc/ghi cookie, và truy cập vào kho lưu trữ.
            builder.Services.AddSession(options =>
            {
                // Bạn có thể cấu hình thêm, ví dụ: thời gian hết hạn của session
                options.IOTimeout = TimeSpan.FromMinutes(30);
                // Bảo mật: Không cho phép JavaScript ở trình duyệt đọc được Cookie chứa ID Session
                options.Cookie.HttpOnly = true;
                // Đánh dấu Cookie này là thiết yếu, không bị chặn bởi các quy định GDPR(luật bảo vệ dữ liệu)
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // BƯỚC 3: Kích hoạt Middleware Session (Mở cửa phòng gửi đồ)
            // Middleware là một "trạm kiểm soát" cho mỗi request. UseSession() sẽ
            // tự động kiểm tra cookie "chìa khóa" trên mỗi request đến và
            // thiết lập HttpContext.Session để bạn có thể sử dụng trong Controller.
            // QUAN TRỌNG: Nó phải được gọi trước UseRouting() và UseEndpoints().


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
