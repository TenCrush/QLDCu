using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Safenet.Bussiness.File;
using Safenet.Bussiness.File.Dto;
using Safenet.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Safenet.Controllers
{
    [AbpMvcAuthorize]
    [Route("api/[controller]/[action]")]
    public class FileController : AbpController
    {
        private readonly List<string> allowFileExtension = new List<string>()
        {
            ".JPEG", ".PNG", ".GIF",".TIFF",".PSD",".PDF",".EPS",".AI",".INDD",".RAW",
            ".JPG", ".MP4", ".MOV",".WMV",".FLV",".AVI",".WebM",".MKV"
        };
        private readonly IRepository<Bussiness.File.File, long> _fileRepository;
        private readonly IConfigurationRoot _appConfiguration;

        public FileController(
            IWebHostEnvironment env,
            IRepository<Bussiness.File.File, long> fileRepository)
        {
            _appConfiguration = env.GetAppConfiguration();
            _fileRepository = fileRepository;
        }


        [HttpPost]
        public async Task<FileDTO> UploadFile([FromForm] IFormFile file)
        {
            var errorDTO = new FileDTO
            {
                Id = -1
            };
            if (file == null) return errorDTO;

            long size = file.Length;

            if (file.Length > 0)
            {
                var currentDate = DateTime.Now.ToString("yyyy/MM/dd");
                var rootLocation = _appConfiguration["App:FileLocation"];
                var storeFileLocation = rootLocation + currentDate;
                if (!Directory.Exists(storeFileLocation))
                    Directory.CreateDirectory(storeFileLocation);
                var fileEntity = new Bussiness.File.File();
                fileEntity.Size = size;
                fileEntity.Loai = Path.GetExtension(file.FileName);
                fileEntity.Ten = file.FileName;
                if (string.IsNullOrEmpty(fileEntity.Loai) || !allowFileExtension.Contains(fileEntity.Loai.ToUpper()))
                {
                    return new FileDTO
                    {
                        Id = 0
                    };
                }
                long milliseconds = DateTime.Now.Ticks;
                var newName = Path.GetFileNameWithoutExtension(file.FileName);
                newName = newName + "_" + AbpSession.UserId + "_" + milliseconds + Path.GetExtension(file.FileName);
                using (var stream = System.IO.File.Create(storeFileLocation + "\\" + newName))
                {
                    await file.CopyToAsync(stream);
                }

                fileEntity.Ten = newName;
                fileEntity.URL = _appConfiguration["App:RequestFileLocation"] + "/" + currentDate + "/" + fileEntity.Ten;
                var id = await _fileRepository.InsertAndGetIdAsync(fileEntity);
                var response = new FileDTO
                {
                    Id = id,
                    Ten = fileEntity.Ten,
                    URL = fileEntity.URL
                };
                return response;
            }
            return errorDTO;
        }
    }
}
