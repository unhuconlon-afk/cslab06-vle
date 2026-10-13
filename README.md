# CSLab06 - Array

Bài thực hành Windows Programming with C# - LAB 06, theo tài liệu **CSLab06 - Array.pdf** (Ver 2.0, 2015, FIT, HCMUP; ThS. Lương Trần Hy Hiến).

Tham khảo cấu trúc hai form, cách tạo control động và panel cuộn từ [cslab05](https://github.com/unhuconlon-afk/cslab05). Bản này dùng **Windows Forms / .NET Framework 4.8**, mở được bằng Visual Studio 2022; không cần .NET 10 hoặc gói NuGet.

## Mở và chạy

1. Mở `CSLab06.sln` bằng Visual Studio, với workload **.NET desktop development** và .NET Framework 4.8 targeting pack.
2. Nhấn **F5** (hoặc **Ctrl+F5**).
3. Nhập số dòng và số cột, bấm **Khởi tạo form** hoặc nhấn Enter.
4. Bấm một nút để xem giá trị. Rê chuột lên nút để xem dòng/cột trên tiêu đề form và thanh trạng thái.
5. Đóng form xuất để trở về form nhập và tạo ma trận mới.

Bản biên dịch kèm theo nằm ở `CSLab06/bin/Release/CSLab06.exe` trong gói ZIP. Chạy trên Windows có .NET Framework 4.8.

## Đối chiếu yêu cầu đề

| Mục | Thực hiện |
| --- | --- |
| 2.1 | `frmNhapLieu`, `txtSoDong`, `txtSoCot`, `btnKhoiTao` |
| 2.2 | Form xuất `frmXuat` |
| 2.3 | Hai automatic property `SoDong`, `SoCot`; nhận dữ liệu qua constructor |
| 2.3 | Hai vòng `for`; lưu nút vào mảng hai chiều `Button[,]` |
| 2.3 | `h = 35`, `margin = 5`; `Text = i * SoCot + j + 1`; tọa độ theo công thức trong đề |
| 2.3 | `Tag = "Dòng i cột j"`; `MouseHover` cập nhật tiêu đề; `Click` hiển thị `MessageBox` chứa giá trị |
| 2.4 | `int.TryParse`, mặc định 1 khi không chuyển được; `ShowDialog` hiển thị form xuất ở giữa form nhập |
| 2.5 | Mặc định 3 dòng, 4 cột; 12 nút mang giá trị 1–12 theo từng hàng |

**Quy ước:** giá trị nút bắt đầu từ 1; chỉ số dòng/cột trong `Tag` bắt đầu từ 0, đúng mã mẫu trong PDF. Nút 1 có vị trí `Dòng 0 cột 0`; nút 12 của ma trận 3×4 có vị trí `Dòng 2 cột 3`.

## Xử lý bổ sung

- Ô trống, chữ hoặc giá trị không chuyển được sang `int` được đặt thành 1 theo mục 2.4.
- Số nguyên ngoài khoảng 1–50 bị từ chối bằng ErrorProvider; giới hạn này tránh tạo quá nhiều cửa sổ con khiến giao diện bị treo.
- Cửa sổ tự điều chỉnh kích thước theo ma trận và màn hình. Panel cuộn giúp truy cập ma trận lớn.
- Constructor không tham số và file `.Designer.cs` chỉ khởi tạo giao diện tĩnh. Mảng động được tạo khi form nạp, tránh ghi các nút động vào Designer.
- Các form xuất được giải phóng bằng `using` sau khi đóng.

## Cấu trúc

```text
cslab06/
  CSLab06.sln
  CSLab06/
    CSLab06.csproj
    Program.cs
    frmNhapLieu.cs
    frmNhapLieu.Designer.cs
    frmXuat.cs
    frmXuat.Designer.cs
  tests/
    Verify.cs
    Verify.ps1
  README.md
```

## Kiểm tra

Sau khi build Release, chạy `powershell -NoProfile -ExecutionPolicy Bypass -File tests/Verify.ps1` từ thư mục gốc. Kiểm tra tự động bao gồm số lượng/vị trí/giá trị nút, chỉ số Tag, sự kiện rê chuột, kích thước biên, dữ liệu nhập và việc mở lại form. Kết quả và ảnh chụp form được ghi vào `TestResults`.

Đã build Release bằng MSBuild của Visual Studio 2022 và vượt qua **63 kiểm tra tự động** trên Windows. Không có lỗi hoặc cảnh báo khi build.

Kiểm tra thủ công: nhập 3×4, bấm nút 12 để thấy hộp thoại `12`, đóng form xuất, nhập kích thước khác và tạo lại.
