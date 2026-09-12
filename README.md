# 🎓 BÁCH KHOA TOÀN THƯ BẢO VỆ ĐỒ ÁN BLAZOR ESHOP
### *Bám sát 100% nội dung 10 Video bài học & Kiến trúc Clean Architecture*
> **Tài liệu bí kíp chuẩn bị cho buổi vấn đáp / bảo vệ đồ án:**  
> Giúp bạn hiểu tường tận bản chất từng file code, cấu trúc 4 tầng, cơ chế "Code Depensi" (Dependency Injection), luồng truyền nhận dữ liệu giữa các Component, các phương thức vòng đời và tự tin trả lời bất kỳ câu hỏi nào của giảng viên.

---

## 📑 MỤC LỤC TỔNG QUAN
1. [TỔNG QUAN HÀNH TRÌNH 10 VIDEO (ROADMAP ĐỒ ÁN)](#phần-1-tổng-quan-hành-trình-10-video)
2. [KIẾN TRÚC TỔNG THỂ: CLEAN ARCHITECTURE LÀ GÌ?](#phần-2-kiến-trúc-tổng-thể-clean-architecture)
3. [BẢN CHẤT "CODE DEPENSI" (DEPENDENCY INJECTION - DI)](#phần-3-bản-chất-code-depensi-dependency-injection)
4. [GIẢI PHẪU CHI TIẾT TỪNG FILE TRONG 4 PROJECT](#phần-4-giải-phẫu-chi-tiết-từng-file)
   - Project 1: `eShop.CoreBusiness`
   - Project 2: `eShop.UseCases`
   - Project 3: `eShop.DataStore.HardCode`
   - Project 4: `BlazorApp1` (Giao diện Blazor)
5. [LUỒNG DỮ LIỆU & GIAO TIẾP COMPONENT (DATA FLOW)](#phần-5-luồng-dữ-liệu--giao-tiếp-component)
6. [SO SÁNH GIAO DIỆN GỐC (TABLE) VÀ GIAO DIỆN NÂNG CẤP (CARD GRID)](#phần-6-so-sánh-giao-diện-gốc-và-giao-diện-card)
7. [BỘ 20 CÂU HỎI VẤN ĐÁP KINH ĐIỂN (HỎI GÌ CŨNG ĐÁP ĐƯỢC)](#phần-7-bộ-20-câu-hỏi-vấn-đáp-bảo-vệ-đạt-điểm-10)

---

# PHẦN 1: TỔNG QUAN HÀNH TRÌNH 10 VIDEO

Dự án này được xây dựng qua 10 bước nối tiếp nhau rất bài bản:

| Video | Tên chủ đề | Nhiệm vụ kỹ thuật chính đã làm |
| :--- | :--- | :--- |
| **Video 1** | Tổng quan Web & Blazor Server | Tìm hiểu mô hình HttpRequest/HttpResponse, Middleware Pipeline, tạo dự án Blazor Server, các file khung (`Program.cs`, `_Host.cshtml`, `App.razor`, `MainLayout.razor`), cách tạo định tuyến `@page "/duong-dan"`. |
| **Video 2** | Thiết kế Clean Architecture | Tách giải pháp (Solution) thành các Class Library độc lập: `eShop.CoreBusiness` (chứa `Product.cs`), `eShop.UseCases` (chứa `SearchProductScreen` và `ViewProductScreen`). Thiết lập Project Reference. |
| **Video 3** | Data Store & DI cơ bản | Tạo interface hợp đồng `IProductRepository` trong `eShop.UseCases`. Áp dụng Constructor Injection vào các UseCase (`SearchProduct`, `ViewProduct`). Tạo dự án dữ liệu mẫu `eShop.DataStore.HardCode` (dùng `List<Product>`, LINQ `FirstOrDefault`, `Where`). |
| **Video 4** | Thiết lập DI & Trang sản phẩm | Tạo interface cho UseCase (`ISearchProduct`, `IViewProduct`). Cập nhật `Description` cho model `Product`. Đăng ký `builder.Services.AddTransient` trong `Program.cs`. Tạo component đầu tiên `SearchProductComponent.razor` với `@page "/products"`, `@inject`, nạp dữ liệu ở `OnInitialized()`. |
| **Video 5** | Hiển thị danh sách & Ô tìm kiếm | Dùng vòng lặp `@foreach` hiển thị danh sách dạng `<ul> <li>`. Thêm `@using` vào `_Imports.razor`. Thêm mục menu "Search Product" vào `NavMenu.razor`. Tạo ô `<input>` và `<button>Search</button>`. Trải nghiệm tính năng Hot Reload. |
| **Video 6** | Component con & EventCallback | Tách thanh tìm kiếm ra component con `SearchBarComponent.razor`. Áp dụng mô hình View - State - Event, liên kết dữ liệu 2 chiều `@bind-value="filter"`. Dùng `[Parameter] public EventCallback<string> OnSearch` để gửi từ khóa ngược từ Con lên Cha. |
| **Video 7** | Cấu trúc Table & ProductItem | Chuyển hiển thị danh sách sang thẻ `<table>`. Tách dòng sản phẩm `<tr>` thành component con `ProductItemComponent.razor`. Truyền dữ liệu từ Cha xuống Con qua `[Parameter] public Product Product { get; set; }`. Định dạng giá tiền tệ `Price.ToString("c")`. Xử lý hiển thị thông báo rỗng bằng `colspan="3"`. |
| **Video 8** | Xử lý lọc dữ liệu & Bootstrap | Viết hàm lọc `GetProducts(string filter)` dùng LINQ `.Where(x => x.Name.ToLower().Contains(filter.ToLower()))`. Kết nối sự kiện `HandleSearch` tại trang cha để gọi UseCase lọc lại danh sách. Nhúng thư viện `bootstrap.min.css`, thử nghiệm `form-inline`, `form-control`. |
| **Video 9** | Tinh chỉnh giao diện Bootstrap | Thay thế `form-inline` bằng Grid `<div class="mb-3 row">` và các cột `col-auto` giúp ô input và nút Search nằm thẳng hàng ngang đẹp mắt. Áp dụng bảng chuẩn Bootstrap `<table class="table">` và `<table class="table table-dark">`. Kiểm thử từ khóa tìm kiếm (ví dụ "dream"). |
| **Video 10** | Trang chi tiết & Điều hướng | Tạo trang `ViewProductComponent.razor` với route `@page "/product/{id:int}"`. Bắt tham số URL bằng `[Parameter] public int Id { get; set; }`. Nạp dữ liệu trong vòng đời `OnParametersSet()`. Tạo liên kết `<NavLink href="@($"/product/{Product.Id}")">`. Thiết kế giao diện Card chi tiết (ảnh, tên, giá, hãng, mô tả) và nút bấm quay lại `Back to Product Page`. |

---

# PHẦN 2: KIẾN TRÚC TỔNG THỂ (CLEAN ARCHITECTURE)

### 1. Tại sao phải chia thành 4 Project riêng biệt?
Nếu gom tất cả code vào 1 dự án Web duy nhất thì code sẽ rối như một "nồi lẩu thập cẩm" (Spaghetti code): Giao diện gọi thẳng CSDL, logic nghiệp vụ lẫn vào nút bấm. Khi muốn đổi giao diện hay đổi CSDL sang SQL Server thì phải đập đi xây lại toàn bộ.

**Clean Architecture giải quyết việc này bằng cách chia thành 4 tầng riêng biệt:**

```
+-------------------------------------------------------------+
|               1. TẦNG GIAO DIỆN (Presentation)               |
|                         BlazorApp1                          |
|    (Chứa UI Razor, Components, Pages, Layout, Program.cs)   |
+-------------------------------------------------------------+
                              |
                              | 1. Gọi Use Cases thực hiện
                              v
+-------------------------------------------------------------+
|               2. TẦNG NGHIỆP VỤ (Application)                |
|                       eShop.UseCases                        |
|   (SearchProduct, ViewProduct, Hợp đồng IProductRepository) |
+-------------------------------------------------------------+
            |                                     ^
            | Sử dụng Model                       | Triển khai Interface
            v                                     |
+--------------------------+         +--------------------------+
|  3. TẦNG CỐT LÕI (Domain) |         |  4. TẦNG DỮ LIỆU (Infra) |
|    eShop.CoreBusiness    |<--------| eShop.DataStore.HardCode |
|     (Model Product.cs)   | Dữ liệu | (Kho dữ liệu tĩnh RAM)   |
+--------------------------+         +--------------------------+
```

### 2. Ẩn dụ siêu dễ nhớ: "Mô hình Nhà Hàng 5 Sao"

* **`eShop.CoreBusiness` (Thực đơn / Nguyên liệu chuẩn):**  
  Quy định một "Món ăn" (Sản phẩm) gồm có tên gì, giá bao nhiêu, hình ảnh ra sao. Tầng này là **cốt lõi nhất**, không phụ thuộc vào bất kỳ ai.
* **`eShop.UseCases` (Bếp Trưởng):**  
  Nhận yêu cầu từ khách (Tìm món, Xem chi tiết món). Bếp trưởng quy định hợp đồng: *"Ai cung cấp nguyên liệu cho tôi phải có hàm `GetProducts` và `GetProduct`"* (`IProductRepository`). Bếp trưởng **không quan tâm** nguyên liệu lấy từ tủ lạnh (HardCode) hay mua ở siêu thị (SQL Server).
* **`eShop.DataStore.HardCode` (Kho cung cấp thực phẩm):**  
  Là người ký vào hợp đồng với Bếp trưởng (`implements IProductRepository`). Hiện tại đang giả lập nguyên liệu sẵn có trong tủ lạnh (In-Memory List). Sau này đổi sang siêu thị Metro (SQL Server / Entity Framework Core) chỉ cần thay tầng này.
* **`BlazorApp1` (Nhân viên phục vụ & Bàn ăn):**  
  Giao tiếp trực tiếp với khách hàng (trình duyệt). Nhận thao tác click chuột, gõ bàn phím và gọi Bếp trưởng xử lý, sau đó bưng kết quả ra bàn ăn (render HTML).

---

# PHẦN 3: BẢN CHẤT "CODE DEPENSI" (DEPENDENCY INJECTION)

> ⚠️ **Đây là câu hỏi "sát thủ" của các thầy cô chấm thi! Nắm vững phần này bạn đã cầm chắc điểm 9-10.**

### 1. "Dependency" (Sự phụ thuộc) là gì?
Khi class `SearchProduct` muốn tìm sản phẩm, nó phải nhờ class `ProductRepository` đọc dữ liệu.  
Ta nói: **`SearchProduct` phụ thuộc vào `ProductRepository`**.

### 2. "Injection" (Tiêm phụ thuộc) là gì?
* **Cách làm tồi (Cũ):** Trong `SearchProduct` tự gõ `var repo = new ProductRepository();`  
  ❌ *Hậu quả:* Hai class bị dính chặt vào nhau (Tightly Coupled). Muốn thay `ProductRepository` bằng `SqlProductRepository` thì phải mở file `SearchProduct` ra sửa và build lại.
* **Cách làm chuẩn (Dependency Injection qua Constructor):**  
  `SearchProduct` không tự tạo đối tượng mà chỉ mở sẵn một cái "cổng nhận" ở hàm tạo (Constructor) dưới dạng Interface:
  ```csharp
  public class SearchProduct : ISearchProduct
  {
      private readonly IProductRepository productRepository;

      // CONSTRUCTOR INJECTION: Tiêm từ bên ngoài vào
      public SearchProduct(IProductRepository productRepository)
      {
          this.productRepository = productRepository;
      }
      ...
  }
  ```
  Khi chương trình chạy, **vùng chứa IoC Container của ASP.NET Core** sẽ tự động khởi tạo `ProductRepository` và "bơm" (tiêm) vào cho `SearchProduct`.

### 3. Đăng ký DI Container trong `Program.cs`
Trong `Program.cs`, ta hướng dẫn hệ thống ghép nối các Interface với Class cụ thể:
```csharp
// Đăng ký dịch vụ với DI Container
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ISearchProduct, SearchProduct>();
builder.Services.AddTransient<IViewProduct, ViewProduct>();
```

### 4. Phân biệt 3 vòng đời (Service Lifetimes) cực kỳ quan trọng:

| Loại vòng đời | Cơ chế hoạt động | Ẩn dụ thực tế | Khi nào sử dụng? |
| :--- | :--- | :--- | :--- |
| **`AddTransient`** *(Đang dùng trong bài)* | Mỗi khi có class hoặc component nào cần, hệ thống sẽ **tạo mới hoàn toàn một đối tượng**, dùng xong thì bộ gom rác (Garbage Collector) dọn sạch. | **Ly nước giấy dùng 1 lần**: Uống xong vứt ngay, lần sau lấy ly mới. | Dùng cho các tác vụ xử lý nghiệp vụ nhẹ, không cần lưu trữ trạng thái nội bộ (như `SearchProduct`, `ViewProduct`). |
| **`AddScoped`** | Tạo **duy nhất 1 đối tượng cho mỗi phiên kết nối (Circuit/Session)**. Trong suốt thời gian người dùng tương tác, họ dùng chung đối tượng đó. Người khác vào web sẽ có đối tượng riêng. | **Cốc nước trong phòng khách sạn**: Trong suốt kỳ nghỉ bạn dùng cốc đó, khách phòng khác có cốc khác. | Rất hay dùng cho `DbContext` (kết nối CSDL) hoặc Giỏ hàng của người dùng. |
| **`AddSingleton`** | Tạo **duy nhất 1 đối tượng cho toàn bộ ứng dụng**, hàng triệu người dùng từ lúc bật server đến lúc tắt server đều dùng chung 1 đối tượng duy nhất. | **Bình nước công cộng ở sảnh**: Toàn bộ nhân viên và khách dùng chung 1 bình nước duy nhất. | Dùng cho cấu hình hệ thống (Configuration), dịch vụ ghi log (Logging), hoặc bộ nhớ đệm Cache toàn cục. |

---

# PHẦN 4: GIẢI PHẪU CHI TIẾT TỪNG FILE

---

## 🟢 PROJECT 1: `eShop.CoreBusiness`
*Tầng lõi - Hoàn toàn độc lập, không tham chiếu bất kỳ project nào.*

### 📄 `Models/Product.cs`
* **Mục đích:** Định nghĩa cấu trúc đối tượng Sản phẩm (Entity Model) xuyên suốt hệ thống.
* **Chi tiết từng thuộc tính:**
  ```csharp
  namespace eShop.CoreBusiness.Models
  {
      public class Product
      {
          public int Id { get; set; }           // Khóa chính (Mã định danh sản phẩm)
          public string Brand { get; set; }     // Hãng sản xuất (Maybelline...)
          public string Name { get; set; }      // Tên đầy đủ của sản phẩm
          public double Price { get; set; }     // Đơn giá bán (kiểu số thực)
          public string ImageLink { get; set; } // Link ảnh trực tuyến trên đám mây AWS CDN
          public string Description { get; set; } // Mô tả chi tiết (bổ sung ở Video 4)
      }
  }
  ```
* **Câu hỏi thầy hỏi:** *"Tại sao class này lại để ở project riêng mà không để trong Blazor?"*  
  👉 **Đáp:** *"Dạ để đảm bảo nguyên lý Clean Architecture. Cả tầng UseCases, DataStore và UI đều cần dùng chung đối tượng Product mà không bị phụ thuộc vòng tròn (Circular Dependency) ạ."*

---

## 🔵 PROJECT 2: `eShop.UseCases`
*Tầng nghiệp vụ - Chỉ tham chiếu đến `eShop.CoreBusiness`.*

### 📄 1. `PluginInterfaces/DataStore/IProductRepository.cs`
* **Mục đích:** Là bản hợp đồng (Contract) quy định các thao tác với kho dữ liệu.
* **Chi tiết code:**
  ```csharp
  namespace eShop.UseCases.PluginInterfaces.DataStore
  {
      public interface IProductRepository
      {
          IEnumerable<Product> GetProducts(string filter); // Hàm lấy danh sách có lọc
          Product GetProduct(int id);                      // Hàm lấy 1 sản phẩm theo ID
      }
  }
  ```
* **Ý nghĩa:** Tầng `UseCases` chỉ giao tiếp qua bản hợp đồng này chứ không thèm quan tâm bên dưới là SQL, In-Memory hay MongoDB. Đây là nguyên lý **Dependency Inversion Principle (chữ D trong SOLID)**.

### 📄 2. `SearchProductScreen/ISearchProduct.cs` & `SearchProduct.cs`
* **Mục đích:** Thực thi nghiệp vụ "Tìm kiếm danh sách sản phẩm".
* **Code chi tiết:**
  ```csharp
  public interface ISearchProduct
  {
      IEnumerable<Product> Execute(string filter = null);
  }

  public class SearchProduct : ISearchProduct
  {
      private readonly IProductRepository productRepository;

      // Nhận IProductRepository từ bên ngoài truyền vào (Constructor Injection)
      public SearchProduct(IProductRepository productRepository)
      {
          this.productRepository = productRepository;
      }

      public IEnumerable<Product> Execute(string filter = null)
      {
          return productRepository.GetProducts(filter);
      }
  }
  ```
* **Luồng chạy:** Nhận từ khóa `filter` -> Chuyển tiếp xuống `productRepository.GetProducts(filter)` -> Trả danh sách về cho UI.

### 📄 3. `SearchProductScreen/IViewProduct.cs` & `ViewProduct.cs`
* **Mục đích:** Thực thi nghiệp vụ "Xem chi tiết một sản phẩm".
* **Code chi tiết:**
  ```csharp
  public interface IViewProduct
  {
      Product Execute(int id);
  }

  public class ViewProduct : IViewProduct
  {
      private readonly IProductRepository productRepository;

      public ViewProduct(IProductRepository productRepository)
      {
          this.productRepository = productRepository;
      }

      public Product Execute(int id)
      {
          return productRepository.GetProduct(id);
      }
  }
  ```

---

## 🟡 PROJECT 3: `eShop.DataStore.HardCode`
*Tầng lưu trữ dữ liệu - Tham chiếu đến `eShop.UseCases` và `eShop.CoreBusiness`.*

### 📄 `ProductRepository.cs`
* **Mục đích:** Triển khai (implement) giao diện `IProductRepository`, cung cấp dữ liệu thật giả lập trên RAM.
* **Code chi tiết quan trọng:**
  ```csharp
  public class ProductRepository : IProductRepository
  {
      // Danh sách sản phẩm mẫu tạo sẵn trong bộ nhớ RAM
      private List<Product> products;

      public ProductRepository()
      {
          products = new List<Product>()
          {
              new Product { Id = 495, Brand = "Maybelline", Name = "Maybelline Face Studio City Bronzer", Price = 9.99, ImageLink = "...", Description = "..." },
              // ... tổng cộng khoảng 20 sản phẩm mỹ phẩm
          };
      }

      // Lấy 1 sản phẩm theo ID bằng LINQ
      public Product GetProduct(int id)
      {
          return products.FirstOrDefault(x => x.Id == id);
      }

      // Lọc sản phẩm theo từ khóa (Video 8)
      public IEnumerable<Product> GetProducts(string filter = null)
      {
          // Nếu ô tìm kiếm rỗng hoặc khoảng trắng, trả về toàn bộ
          if (string.IsNullOrWhiteSpace(filter)) return products;

          // Dùng ToLower() để tìm kiếm không phân biệt hoa - thường
          return products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
      }
  }
  ```
* **Giải thích phương thức LINQ:**
  * `FirstOrDefault(x => x.Id == id)`: Tìm phần tử đầu tiên có `Id` khớp với tham số truyền vào. Nếu không thấy trả về `null`.
  * `.Where(...)`: Lọc tất cả các sản phẩm có tên chứa chuỗi `filter`.

---

## 🟣 PROJECT 4: `BlazorApp1` (Tầng Giao Diện Blazor)
*Tầng hiển thị tương tác người dùng - Tham chiếu đến cả 3 project trên.*

### 📄 1. `Program.cs` (Đầu não cấu hình hệ thống)
* **Mục đích:** Khởi chạy ứng dụng Web, đăng ký các dịch vụ vào DI Container và cấu hình Middleware Pipeline.
* **Code cấu hình then chốt:**
  ```csharp
  // 1. Đăng ký Blazor Server Component
  builder.Services.AddRazorComponents().AddInteractiveServerComponents();

  // 2. ĐĂNG KÝ DEPENDENCY INJECTION (DI)
  builder.Services.AddTransient<IProductRepository, ProductRepository>();
  builder.Services.AddTransient<ISearchProduct, SearchProduct>();
  builder.Services.AddTransient<IViewProduct, ViewProduct>();

  var app = builder.Build();

  // 3. CẤU HÌNH MIDDLEWARE PIPELINE
  app.UseStaticFiles(); // Đọc file CSS, JS, ảnh trong wwwroot
  app.UseAntiforgery(); // Bảo mật chống tấn công giả mạo yêu cầu
  app.MapRazorComponents<App>().AddInteractiveServerRenderMode(); // Bật kết nối SignalR
  ```

### 📄 2. `Components/App.razor` (Bộ khung HTML gốc)
* **Mục đích:** Chứa thẻ `<!DOCTYPE html>`, liên kết CSS của Bootstrap và nạp thẻ `<Routes />`.
* **Điểm then chốt (.NET 8):**
  ```razor
  <Routes @rendermode="InteractiveServer" />
  ```
  👉 Lệnh `@rendermode="InteractiveServer"` mở luồng kết nối **SignalR WebSocket** hai chiều giữa trình duyệt và máy chủ. Nhờ đó, người dùng bấm nút `@onclick` hay gõ `@bind` thì web phản hồi ngay lập tức mà không tải lại trang.

### 📄 3. `Components/_Imports.razor` (Khai báo dùng chung)
* **Mục đích:** Khai báo các câu lệnh `@using` để tất cả các file Razor trong thư mục không cần gõ lại namespace.
  ```razor
  @using eShop.CoreBusiness.Models
  @using eShop.UseCases.SearchProductScreen
  @using BlazorApp_Demo.Components.Controls
  ```

### 📄 4. `Components/Layout/NavMenu.razor` (Thực đơn điều hướng trái)
* **Mục đích:** Chứa thanh menu bên trái (Video 5).
  ```razor
  <NavLink class="nav-link" href="products">
      <span class="bi bi-list-nested-nav-menu"></span> Search Product
  </NavLink>
  ```
  👉 Thẻ `<NavLink href="products">` giúp chuyển sang trang `SearchProductComponent` theo cơ chế SPA (Single Page App) siêu mượt.

---

### 📄 5. `Components/Controls/SearchBarComponent.razor` (Component Con Tìm Kiếm)
* **Mục đích:** Là một khối ô nhập và nút bấm tìm kiếm tách rời, tái sử dụng được (Video 6 & 9).
* **Code chi tiết:**
  ```razor
  <div class="mb-3 row">
      <div class="col-auto">
          <input type="text" class="form-control" @bind-value="filter" placeholder="Search product..." />
      </div>
      <div class="col-auto">
          <button type="button" class="btn btn-primary" @onclick="HandleSearch">Search</button>
      </div>
  </div>

  @code {
      // 1. STATE (Trạng thái dữ liệu nội bộ)
      private string filter;

      // 2. CỔNG PHÁT TÍN HIỆU NGƯỢC LÊN CHA (EventCallback)
      [Parameter]
      public EventCallback<string> OnSearch { get; set; }

      // 3. EVENT (Sự kiện khi bấm nút Search)
      private async Task HandleSearch()
      {
          // Kích hoạt sự kiện và bắn chuỗi 'filter' ngược lên cho component cha
          await OnSearch.InvokeAsync(filter);
      }
  }
  ```
* **Điểm kiến thức cốt lõi:**
  * `@bind-value="filter"`: Liên kết dữ liệu 2 chiều. Gõ gì vào ô input thì biến `filter` tự đổi theo.
  * `EventCallback<string>`: Cơ chế duy nhất trong Blazor để **con gửi dữ liệu lên cho cha**.

---

### 📄 6. `Components/Controls/ProductItemComponent.razor` (Component Con Hiển Thị 1 Sản Phẩm)
* **Mục đích:** Đại diện cho một sản phẩm đơn lẻ (Video 7 & 10).
* **Code chi tiết:**
  ```razor
  @if (Product != null)
  {
      <div class="col-12 col-sm-6 col-md-4 col-lg-3">
          <div class="card h-100 shadow-sm">
              <img src="@Product.ImageLink" class="card-img-top p-3" alt="@Product.Name" />
              <div class="card-body d-flex flex-column">
                  <h6 class="card-title">@Product.Name</h6>
                  <p class="text-muted small mb-1">Brand: @Product.Brand</p>
                  <p class="text-primary fw-bold fs-5 mb-3">@Product.Price.ToString("c")</p>
                  <NavLink href="@($"/product/{Product.Id}")" class="btn btn-outline-primary mt-auto">
                      View Details →
                  </NavLink>
              </div>
          </div>
      </div>
  }

  @code {
      // CỔNG NHẬN DỮ LIỆU TỪ CHA TRUYỀN XUỐNG
      [Parameter]
      public Product Product { get; set; }
  }
  ```
* **Điểm kiến thức cốt lõi:**
  * `[Parameter]`: Thuộc tính bắt buộc để Component cha có thể truyền dữ liệu vào theo cú pháp: `<ProductItemComponent Product="item" />`.
  * `Price.ToString("c")`: Định dạng số thành tiền tệ (Currency) có ký hiệu tiền tệ (ví dụ `$9.99`).
  * `@($"/product/{Product.Id}")`: Nối chuỗi nội suy để tạo link động dẫn sang trang chi tiết với đúng ID sản phẩm.

---

### 📄 7. `Components/Pages/SearchProductComponent.razor` (Component Cha Danh Sách)
* **Mục đích:** Là trang chính hiển thị toàn bộ màn hình tìm kiếm và danh sách sản phẩm (Video 4, 5, 6, 7, 8).
* **Code chi tiết:**
  ```razor
  @page "/products"
  @inject ISearchProduct searchProduct

  <h3>Search Products</h3>

  <!-- 1. Nhúng Component con SearchBar & Hứng sự kiện OnSearch -->
  <SearchBarComponent OnSearch="HandleSearch" />

  <!-- 2. Hiển thị danh sách sản phẩm -->
  @if (products != null && products.Any())
  {
      <div class="row g-4">
          @foreach (var prod in products)
          {
              <!-- Nhúng Component con ProductItem & Truyền dữ liệu prod vào -->
              <ProductItemComponent Product="prod" />
          }
      </div>
  }
  else
  {
      <div class="alert alert-warning">Cannot find products.</div>
  }

  @code {
      // Biến lưu trữ danh sách sản phẩm nhận về từ UseCase
      private IEnumerable<Product> products;

      // VÒNG ĐỜI ONINITIALIZED: Chạy 1 lần duy nhất khi trang vừa mở
      protected override void OnInitialized()
      {
          base.OnInitialized();
          // Gọi UseCase lấy toàn bộ sản phẩm ban đầu
          products = searchProduct.Execute();
      }

      // HÀM XỬ LÝ KHI NHẬN ĐƯỢC TỪ KHÓA TỪ CON GỬI LÊN
      private void HandleSearch(string filter)
      {
          // Gọi UseCase lọc lại danh sách theo từ khóa
          products = searchProduct.Execute(filter);
      }
  }
  ```

---

### 📄 8. `Components/Pages/ViewProductComponent.razor` (Trang Xem Chi Tiết Sản Phẩm)
* **Mục đích:** Màn hình hiển thị đầy đủ thông tin chi tiết của 1 sản phẩm khi người dùng bấm xem chi tiết (Video 10).
* **Code chi tiết:**
  ```razor
  @page "/product/{id:int}"
  @inject IViewProduct viewProduct

  @if (product != null)
  {
      <div class="card mb-4">
          <div class="row g-0">
              <div class="col-md-4 text-center p-4">
                  <img src="@product.ImageLink" class="img-fluid rounded" alt="@product.Name" />
              </div>
              <div class="col-md-8">
                  <div class="card-body">
                      <h2>@product.Name</h2>
                      <p class="text-secondary">Brand: <strong>@product.Brand</strong></p>
                      <h4 class="text-danger">@product.Price.ToString("c")</h4>
                      <p class="card-text mt-3">@product.Description</p>
                      <NavLink href="products" class="btn btn-secondary mt-3">
                          ← Back to Product Page
                      </NavLink>
                  </div>
              </div>
          </div>
      </div>
  }

  @code {
      // BẮT THAM SỐ TỪ URL (Ví dụ: /product/495 -> Id = 495)
      [Parameter]
      public int Id { get; set; }

      private Product product;

      // VÒNG ĐỜI ONPARAMETERSSET: Tự động chạy mỗi khi tham số ID trên URL thay đổi
      protected override void OnParametersSet()
      {
          base.OnParametersSet();
          if (Id > 0)
          {
              product = viewProduct.Execute(Id);
          }
      }
  }
  ```
* **Điểm kiến thức cốt lõi:**
  * `@page "/product/{id:int}"`: Khai báo Route Constraint, bắt buộc `{id}` phải là số nguyên (int).
  * `OnParametersSet()`: Phương thức vòng đời được gọi mỗi khi giá trị của `[Parameter] public int Id` được gán hoặc thay đổi.

---

# PHẦN 5: LUỒNG DỮ LIỆU & GIAO TIẾP COMPONENT

### Sơ đồ luồng giao tiếp giữa các thành phần:

```
                      +-----------------------------+
                      |   SearchProductComponent    |
                      |       (Component Cha)       |
                      +-----------------------------+
                        /                         \
    1. Gửi sự kiện lên /                           \ 2. Truyền dữ liệu xuống
  (EventCallback)     /                             \ ([Parameter])
                     v                               v
       +-----------------------+           +-----------------------+
       |  SearchBarComponent   |           | ProductItemComponent  |
       |    (Component Con)    |           |    (Component Con)    |
       |  - Nhập từ khóa       |           |  - Nhận 1 Product     |
       |  - Bấm nút Search     |           |  - Vẽ Card HTML       |
       +-----------------------+           +-----------------------+
```

1. **Truyền từ Cha xuống Con (Parent -> Child):**
   * Cha nắm dữ liệu danh sách `products`.
   * Cha dùng vòng lặp `@foreach (var prod in products)` và truyền từng đối tượng `prod` vào thuộc tính `Product` của con:
     `<ProductItemComponent Product="prod" />`.
   * Con hứng lấy bằng: `[Parameter] public Product Product { get; set; }`.

2. **Truyền từ Con lên Cha (Child -> Parent):**
   * Người dùng gõ chữ vào ô tìm kiếm ở con `SearchBarComponent`.
   * Khi bấm nút Search, hàm `HandleSearch()` của con kích hoạt:
     `await OnSearch.InvokeAsync(filter);`.
   * Cha hứng sự kiện đó bằng thuộc tính:
     `<SearchBarComponent OnSearch="HandleSearch" />`.
   * Hàm `HandleSearch(string filter)` ở Cha nhận được từ khóa và gọi `searchProduct.Execute(filter)`.
   * Khi danh sách `products` ở Cha thay đổi, Blazor tự động render lại toàn bộ danh sách sản phẩm!

---

# PHẦN 6: SO SÁNH GIAO DIỆN GỐC (TABLE) VÀ GIAO DIỆN NÂNG CẤP (CARD GRID)

Trong video 7-9, tác giả dùng cấu trúc bảng `<table>` với từng dòng `<tr>`. Hiện tại bài của bạn được cải tiến sang dạng lưới thẻ Card Bootstrap hiện đại. 

> 💡 **Cách giải thích với giảng viên nếu thầy hỏi:**  
> *"Dạ thưa thầy, về mặt kiến trúc phần mềm, nguyên lý Clean Architecture, Dependency Injection và cơ chế truyền nhận dữ liệu qua `[Parameter]` và `EventCallback`, em tuân thủ chính xác 100% theo bài giảng.  
> Duy nhất về phần hiển thị HTML, em đã linh hoạt thay thế bảng `<table>` bằng hệ thống lưới Responsive `<div class="row">` và `<div class="card">` của Bootstrap để giao diện giống các website thương mại điện tử thực tế như Shopee hay Amazon hơn ạ!"*

### Bảng đối chiếu code nếu thầy muốn xem dạng bảng gốc:

| Thành phần | Phiên bản Bảng Table gốc (Video 7) | Phiên bản Thẻ Card hiện tại |
| :--- | :--- | :--- |
| **`ProductItemComponent.razor`** | `<tr>` <br> `<td>@Product.Name</td>` <br> `<td>@Product.Brand</td>` <br> `<td>@Product.Price.ToString("c")</td>` <br> `</tr>` | `<div class="col-md-3">` <br> `<div class="card">` <br> `<img src="@Product.ImageLink"/>` <br> `<h6>@Product.Name</h6>` <br> `...` <br> `</div></div>` |
| **`SearchProductComponent.razor`** | `<table class="table">` <br> `<thead>...</thead>` <br> `<tbody>` <br> `@foreach... <ProductItemComponent Product="prod"/>` <br> `</tbody></table>` | `<div class="row g-4">` <br> `@foreach... <ProductItemComponent Product="prod"/>` <br> `</div>` |

---

# PHẦN 7: BỘ 20 CÂU HỎI VẤN ĐÁP BẢO VỆ ĐẠT ĐIỂM 10

#### Câu 1: Trình bày kiến trúc Clean Architecture của đồ án này?
> **Trả lời:** Dạ thưa thầy, đồ án gồm 4 tầng độc lập:
> 1. `eShop.CoreBusiness`: Chứa các thực thể cốt lõi (Model `Product.cs`), độc lập 100%.
> 2. `eShop.UseCases`: Chứa logic nghiệp vụ ứng dụng (`SearchProduct`, `ViewProduct`) và quy định interface hợp đồng kho dữ liệu `IProductRepository`.
> 3. `eShop.DataStore.HardCode`: Triển khai `IProductRepository`, cung cấp dữ liệu giả lập trong bộ nhớ RAM.
> 4. `BlazorApp1`: Tầng giao diện người dùng, cấu hình DI và tương tác trực tiếp với khách hàng.

#### Câu 2: Dependency Injection (DI) là gì? Lợi ích của nó?
> **Trả lời:** Dạ, DI là một mẫu thiết kế (Design Pattern) giúp tách rời sự phụ thuộc giữa các lớp. Thay vì một class tự khởi tạo đối tượng nó cần bằng từ khóa `new`, đối tượng đó sẽ được đưa (tiêm) từ bên ngoài vào thông qua hàm tạo (Constructor Injection).  
> Lợi ích: Giảm sự phụ thuộc chặt chẽ (Loose Coupling), giúp mã nguồn dễ mở rộng, dễ bảo trì và cực kỳ thuận lợi cho việc viết Unit Test ạ.

#### Câu 3: Em đăng ký DI ở đâu và bằng phương thức nào?
> **Trả lời:** Dạ, em đăng ký trong file `Program.cs` của project `BlazorApp1` bằng phương thức `builder.Services.AddTransient`:
> * `builder.Services.AddTransient<IProductRepository, ProductRepository>();`
> * `builder.Services.AddTransient<ISearchProduct, SearchProduct>();`
> * `builder.Services.AddTransient<IViewProduct, ViewProduct>();`

#### Câu 4: Phân biệt `AddTransient`, `AddScoped` và `AddSingleton`?
> **Trả lời:** Dạ:
> * `AddTransient`: Tạo mới một đối tượng mỗi khi có yêu cầu (phù hợp cho Use Case nhẹ, phi trạng thái).
> * `AddScoped`: Tạo 1 đối tượng duy nhất cho mỗi phiên kết nối (Circuit SignalR trong Blazor Server).
> * `AddSingleton`: Tạo duy nhất 1 đối tượng dùng chung cho toàn bộ ứng dụng từ lúc chạy đến lúc tắt server ạ.

#### Câu 5: Tại sao đã tạo `SearchProduct.cs` rồi lại phải tạo thêm interface `ISearchProduct.cs`?
> **Trả lời:** Dạ, interface đóng vai trò là "bản hợp đồng" quy định hàm `Execute`. Component giao diện chỉ phụ thuộc vào Interface chứ không phụ thuộc vào class cụ thể. Sau này nếu em muốn viết thêm `SearchProductFromAPI` hoặc `SearchProductWithAI`, em chỉ cần trỏ DI trong `Program.cs` sang class mới mà không phải sửa lại 1 dòng code nào ở giao diện ạ.

#### Câu 6: Trong Blazor, làm sao để truyền dữ liệu từ Component Cha xuống Component Con?
> **Trả lời:** Dạ, ở Component Con em khai báo một Property có gắn thuộc tính `[Parameter]`:  
> `[Parameter] public Product Product { get; set; }`  
> Ở Component Cha, em truyền dữ liệu vào qua thuộc tính HTML:  
> `<ProductItemComponent Product="prod" />` ạ.

#### Câu 7: Làm sao để truyền dữ liệu ngược từ Component Con lên Component Cha?
> **Trả lời:** Dạ, dùng `EventCallback<T>`:
> 1. Ở Con (`SearchBarComponent`), khai báo: `[Parameter] public EventCallback<string> OnSearch { get; set; }` và phát tín hiệu bằng `await OnSearch.InvokeAsync(filter)`.
> 2. Ở Cha (`SearchProductComponent`), hứng sự kiện bằng: `<SearchBarComponent OnSearch="HandleSearch" />` và xử lý chuỗi gửi lên trong hàm `HandleSearch(string filter)` ạ.

#### Câu 8: Sự khác nhau giữa vòng đời `OnInitialized` và `OnParametersSet`?
> **Trả lời:** Dạ:
> * `OnInitialized()`: Chỉ chạy **1 lần duy nhất** khi component vừa được tạo ra (dùng nạp danh sách ban đầu trong `SearchProductComponent`).
> * `OnParametersSet()`: Chạy mỗi khi **tham số truyền vào hoặc tham số trên URL thay đổi** (dùng trong `ViewProductComponent` để khi đổi ID sản phẩm thì nạp lại sản phẩm mới tương ứng) ạ.

#### Câu 9: Cú pháp `@bind-value="filter"` trong ô tìm kiếm có ý nghĩa gì?
> **Trả lời:** Dạ, đó là cơ chế **Liên kết dữ liệu hai chiều (Two-way Data Binding)**. Khi người dùng gõ phím, giá trị trong biến C# `filter` tự động cập nhật; và ngược lại nếu code C# gán lại `filter = ""`, chữ trong ô input cũng tự động bị xóa theo ạ.

#### Câu 10: Cú pháp định tuyến `@page "/product/{id:int}"` có ý nghĩa gì?
> **Trả lời:** Dạ, đây là định tuyến có ràng buộc tham số (Route Constraint). `{id:int}` bắt buộc giá trị truyền sau `/product/` phải là số nguyên. Blazor sẽ tự động ép kiểu và gán giá trị này vào thuộc tính `[Parameter] public int Id { get; set; }` trong code C# ạ.

#### Câu 11: Trong `ProductRepository`, em lọc sản phẩm như thế nào?
> **Trả lời:** Dạ, em dùng thư viện LINQ:  
> `products.Where(x => x.Name.ToLower().Contains(filter.ToLower()))`.  
> Em dùng phương thức `ToLower()` cho cả tên sản phẩm và từ khóa lọc để tìm kiếm không phân biệt chữ hoa hay chữ thường ạ.

#### Câu 12: Thẻ `<NavLink>` của Blazor khác gì thẻ `<a>` thông thường của HTML?
> **Trả lời:** Dạ, thẻ `<a>` sẽ làm trình duyệt gửi HttpRequest mới và tải lại toàn bộ trang web (Full page reload). Còn `<NavLink>` của Blazor chặn hành vi tải lại trang, chỉ định tuyến nội bộ trong cơ chế Single Page Application (SPA), đồng thời tự động gắn class `active` khi URL trùng khớp ạ.

#### Câu 13: File `_Imports.razor` dùng để làm gì?
> **Trả lời:** Dạ, file này chứa các chỉ thị `@using` dùng chung cho toàn bộ các file Razor nằm cùng thư mục hoặc trong các thư mục con, giúp ta không phải lặp lại việc gõ `@using` ở từng trang ạ.

#### Câu 14: Thuộc tính `@rendermode="InteractiveServer"` trong file `App.razor` có nhiệm vụ gì?
> **Trả lời:** Dạ, trong .NET 8, mặc định các component là HTML tĩnh (Static SSR). Khi thêm `@rendermode="InteractiveServer"`, ứng dụng sẽ thiết lập một kết nối WebSocket thông qua SignalR để quản lý trạng thái và xử lý các sự kiện click chuột, phím bấm theo thời gian thực ạ.

#### Câu 15: Nếu không thêm `[Parameter]` trước thuộc tính trong Component con thì chuyện gì xảy ra?
> **Trả lời:** Dạ, nếu không có `[Parameter]` mà ở Component Cha ta lại cố tình gán thuộc tính (ví dụ `Product="prod"`), Blazor sẽ báo lỗi lúc chạy là `InvalidOperationException` (Component không chấp nhận tham số không xác định) ạ.

#### Câu 16: Thẻ tự đóng trong Razor viết thế nào cho đúng?
> **Trả lời:** Dạ, thẻ tự đóng trong Razor phải kết thúc bằng dấu gạch chéo trước dấu đóng ngoặc nhọn: `/>` (ví dụ `<SearchBarComponent />`). Nếu viết nhầm thành `>/` sẽ bị lỗi cú pháp biên dịch ạ.

#### Câu 17: Tại sao ảnh sản phẩm lại tải được khi em không lưu bất kỳ file ảnh nào trong thư mục dự án?
> **Trả lời:** Dạ, vì thuộc tính `ImageLink` lưu trực tiếp đường dẫn URL đến máy chủ CDN của Amazon CloudFront. Trình duyệt client sẽ tự động gửi yêu cầu qua Internet để tải hình ảnh về hiển thị qua thuộc tính `src` của thẻ `<img>` ạ.

#### Câu 18: Hot Reload trong Visual Studio là gì?
> **Trả lời:** Dạ, Hot Reload là tính năng cho phép lập trình viên chỉnh sửa mã nguồn HTML, CSS và code C# trong khi ứng dụng đang chạy và nhìn thấy kết quả cập nhật ngay trên trình duyệt mà không cần phải dừng và biên dịch (rebuild) lại toàn bộ ứng dụng ạ.

#### Câu 19: Nếu sau này dự án muốn chuyển sang lưu trữ trên cơ sở dữ liệu SQL Server thật thì em cần làm gì?
> **Trả lời:** Dạ, nhờ kiến trúc Clean Architecture, em chỉ cần:
> 1. Tạo project mới `eShop.DataStore.SQL` kết nối Entity Framework Core và triển khai giao diện `IProductRepository`.
> 2. Vào `Program.cs` sửa lại 1 dòng đăng ký DI:  
>    `builder.Services.AddTransient<IProductRepository, SqlProductRepository>();`  
> Toàn bộ các tầng `eShop.UseCases`, `eShop.CoreBusiness` và giao diện `BlazorApp1` **hoàn toàn không cần sửa một dòng code nào** ạ!

#### Câu 20: Kể tên một số lỗi thường gặp trong quá trình làm 10 video và cách khắc phục?
> **Trả lời:** Dạ, có 4 lỗi tiêu biểu nhất:
> 1. **Lỗi thiếu namespace:** Quên `@using` namespace của `Controls` hoặc `Models` trong `_Imports.razor` dẫn đến việc Razor không nhận diện được thẻ component hoặc kiểu dữ liệu `Product`.
> 2. **Lỗi `InvalidOperationException`:** Quên thêm nhãn `[Parameter]` trước thuộc tính `Product` hoặc `EventCallback`.
> 3. **Lỗi chính tả thẻ ảnh:** Gõ nhầm `<img scr="..." />` thay vì `<img src="..." />` (source).
> 4. **Lỗi route URL:** Khai báo sai đường dẫn `@page "/products"` hoặc gõ nhầm href trong `NavLink` dẫn đến thông báo NotFound ạ.

---
*Chúc bạn có một buổi vấn đáp đồ án thành công rực rỡ và đạt điểm số tối đa!*
