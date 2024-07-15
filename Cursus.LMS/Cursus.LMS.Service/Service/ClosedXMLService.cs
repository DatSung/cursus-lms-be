using ClosedXML.Excel;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Cursus.LMS.Service.Service;

public class ClosedXMLService : IClosedXMLService
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _config;

    public ClosedXMLService(IWebHostEnvironment env, IConfiguration config)
    {
        _env = env;
        _config = config;
    }

    public async Task<string> ExportInstructorExcel(List<InstructorInfoDTO> instructorInfoDtos)
    {
        // Tạo đường dẫn đến thư mục lưu trữ file Excel
        string exportFolderPath = Path.Combine(_env.ContentRootPath, _config["FolderPath:ExcelExportFolderPath"]);

        // Tạo thư mục nếu chưa tồn tại
        if (!Directory.Exists(exportFolderPath))
        {
            Directory.CreateDirectory(exportFolderPath);
        }

        // Tạo tên file duy nhất
        string fileName = $"Instructors_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        string filePath = Path.Combine(exportFolderPath, fileName);

        using (var workBook = new XLWorkbook())
        {
            var workSheet = workBook.Worksheets.Add("Instructors");

            // Create header
            workSheet.Cell(1, 1).Value = "Instructor Id";
            workSheet.Cell(1, 2).Value = "UserId";
            workSheet.Cell(1, 3).Value = "FullName";
            workSheet.Cell(1, 4).Value = "Email";
            workSheet.Cell(1, 5).Value = "PhoneNumber";
            workSheet.Cell(1, 6).Value = "Gender";
            workSheet.Cell(1, 7).Value = "BirthDate";
            workSheet.Cell(1, 8).Value = "Country";
            workSheet.Cell(1, 9).Value = "Address";
            workSheet.Cell(1, 10).Value = "Degree";
            workSheet.Cell(1, 11).Value = "Industry";
            workSheet.Cell(1, 12).Value = "Introduction";
            workSheet.Cell(1, 13).Value = "TaxNumber";
            workSheet.Cell(1, 14).Value = "IsAccepted";

            // // Lấy danh sách các thuộc tính của lớp Instructor
            // var properties = typeof(InstructorInfoDTO).GetProperties();
            //
            // // Đặt tên cột cho hàng đầu tiên trong Excel từ các thuộc tính của lớp Instructor
            // for (int i = 0; i < properties.Length; i++)
            // {
            //     workSheet.Cell(1, i + 1).Value = properties[i].Name;
            // }

            // Create data
            for (int i = 0; i < instructorInfoDtos.Count; i++)
            {
                workSheet.Cell(i + 2, 1).Value = instructorInfoDtos[i].InstructorId.ToString();
                workSheet.Cell(i + 2, 2).Value = instructorInfoDtos[i].UserId;
                workSheet.Cell(i + 2, 3).Value = instructorInfoDtos[i].FullName;
                workSheet.Cell(i + 2, 4).Value = instructorInfoDtos[i].Email;
                workSheet.Cell(i + 2, 5).Value = instructorInfoDtos[i].PhoneNumber;
                workSheet.Cell(i + 2, 6).Value = instructorInfoDtos[i].Gender;
                workSheet.Cell(i + 2, 7).Value = instructorInfoDtos[i].BirthDate;
                workSheet.Cell(i + 2, 8).Value = instructorInfoDtos[i].Country;
                workSheet.Cell(i + 2, 9).Value = instructorInfoDtos[i].Address;
                workSheet.Cell(i + 2, 10).Value = instructorInfoDtos[i].Degree;
                workSheet.Cell(i + 2, 11).Value = instructorInfoDtos[i].Industry;
                workSheet.Cell(i + 2, 12).Value = instructorInfoDtos[i].Introduction;
                workSheet.Cell(i + 2, 13).Value = instructorInfoDtos[i].TaxNumber;
                workSheet.Cell(i + 2, 14).Value = instructorInfoDtos[i].IsAccepted.ToString();
            }

            workSheet.Columns().AdjustToContents();
            // // Điền dữ liệu từ danh sách instructors vào các ô tương ứng
            // for (int rowIndex = 0; rowIndex < instructorInfoDtos.Count; rowIndex++)
            // {
            //     for (int colIndex = 0; colIndex < properties.Length; colIndex++)
            //     {
            //         var propertyValue = properties[colIndex].GetValue(instructorInfoDtos[rowIndex]);
            //         workSheet.Cell(rowIndex + 2, colIndex + 1).Value = propertyValue?.ToString();
            //     }
            // }

            // Export to memory stream
            workBook.SaveAs(filePath);

            // using (var stream = new MemoryStream())
            // {
            //     workBook.SaveAs(stream);
            //     stream.Position = 0;
            //     var fileName = $"Instructors_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            //     var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //
            //     return new ClosedXMLResponseDTO()
            //     {
            //         Stream = stream,
            //         ContentType = contentType,
            //         FileName = fileName
            //     };
            // }

            return fileName;
        }
    }

    public async Task<string> ExportStudentExcel(List<StudentFullInfoDTO> studentInfoDtos)
{
    // Tạo đường dẫn đến thư mục lưu trữ file Excel
    string exportFolderPath = Path.Combine(_env.ContentRootPath, _config["FolderPath:StudentExportFolderPath"]);

    // Tạo thư mục nếu chưa tồn tại
    if (!Directory.Exists(exportFolderPath))
    {
        Directory.CreateDirectory(exportFolderPath);
    }

    // Tạo tên file duy nhất
    string fileNameStudent = $"Students_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
    string filePath = Path.Combine(exportFolderPath, fileNameStudent);

    using (var workBook = new XLWorkbook())
    {
        var workSheet = workBook.Worksheets.Add("Students");

        // Create header
        workSheet.Cell(1, 1).Value = "Student Id";
        workSheet.Cell(1, 2).Value = "UserId";
        workSheet.Cell(1, 3).Value = "FullName";
        workSheet.Cell(1, 4).Value = "Email";
        workSheet.Cell(1, 5).Value = "PhoneNumber";
        workSheet.Cell(1, 6).Value = "Gender";
        workSheet.Cell(1, 7).Value = "BirthDate";
        workSheet.Cell(1, 8).Value = "Country";
        workSheet.Cell(1, 9).Value = "Address";
        workSheet.Cell(1, 10).Value = "University";

        // Create data
        for (int i = 0; i < studentInfoDtos.Count; i++)
        {
            var student = studentInfoDtos[i];

            workSheet.Cell(i + 2, 1).Value = student.StudentId.ToString();
            workSheet.Cell(i + 2, 2).Value = student.UserId;
            workSheet.Cell(i + 2, 3).Value = student.FullName;
            workSheet.Cell(i + 2, 4).Value = student.Email;
            workSheet.Cell(i + 2, 5).Value = student.PhoneNumber;
            workSheet.Cell(i + 2, 6).Value = student.Gender;
            workSheet.Cell(i + 2, 7).Value = student.BirthDate?.ToString("yyyy-MM-dd");
            workSheet.Cell(i + 2, 8).Value = student.Country;
            workSheet.Cell(i + 2, 9).Value = student.Address;
            workSheet.Cell(i + 2, 10).Value = student.University;
        }

        workSheet.Columns().AdjustToContents();

        // Export to memory stream
        workBook.SaveAs(filePath);

        return fileNameStudent;
    }
}
}