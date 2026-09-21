using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportsStore.Domain;
using SportsStore.Infarstructure;
using SportsStore.Infrastructure;
using SportsStore.WebUI.Infarstructure;
using SportsStore.WebUI.Models;
using System.Text;
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


            var connectionString =
    builder.Configuration.GetConnectionString("AppIdentityDbContextConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'AppIdentityDbContextConnection' not found.");

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<SportsStore.Domain.AppUser>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
                // Địa chỉ của Angular dev server
            });


            // 2. Cấu hình Authentication với JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false, // Tạm thời tắt kiểm tra hết hạn để dễ  test
                    ValidateIssuerSigningKey = true
                };
            });

            builder.Services.AddAuthorization();



            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SportsStoreConnection"));
            });


            builder.Services.AddHttpContextAccessor();
            //builder.Services.AddScoped<IProductRepository, FakeProductRepository>();
            builder.Services.AddScoped<IProductRepository, EFProductRepository>();

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
            builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            
            var app = builder.Build();
        

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
               
             
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


            
            app.UseCors("AllowSpecificOrigin"); // Kích hoạt CORS
            
            app.UseSession();

            app.UseRouting();

            // --- SỬA LẠI THỨ TỰ ---
            // Authentication phải đứng trước Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages(); // Đảm bảo dòng này có để các trang Identity hoạt động





            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
            app.Run();
        }
    }
}
