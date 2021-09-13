using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace IntouchBilling.Areas.Admin.Pages
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public string ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string ImageName { get; set; }

        //public string files { get; set; }

        private string fullPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "UploadImages";

        private IHostingEnvironment _environment;

        private readonly IArticleRepository articleRepository;

        [BindProperty]
        public List<Article> ArticleData { get; set; }
       
        public CreateModel(IArticleRepository articleRepository, IHostingEnvironment environment)
        {
            this.articleRepository = articleRepository;
            _environment = environment;
            //this.mapper = mapper;
        }
        public void OnGet()
        {
            var articles = articleRepository.GetAllArticles();
            this.ArticleData = articles.Result.ToList();
        }
        
        public void OnPost()
        {
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
        };

            //Creating upload folder
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            var files = HttpContext.Request.Form.Files;
            var ImageFile = "";

            if (files.Count > 0)
            {
                ImageFile = files[0].FileName;
                var ext = Path.GetExtension(ImageFile);
                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {

                    if (ImageFile.Length > 0)
                    {

                        var FileDic = "Images";

                        string FilePath = Path.Combine(_environment.WebRootPath, FileDic);

                        if (!Directory.Exists(FilePath))

                            Directory.CreateDirectory(FilePath);

                        var filePath = Path.Combine(FilePath, ImageFile);

                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                using (FileStream fs = System.IO.File.Create(filePath))

                                {

                                    file.CopyTo(fs);
                                    fs.Flush();

                                }
                            }
                        }
                    }
                    Article article = new Article
                    {
                        Title = this.Title,
                        Content = this.Content,
                        ImageName = ImageFile
                    };

                    var articleId = articleRepository.Add(article);
                }
            }
            else
            {
                //ViewBag.message = "Please choose only Image file";
            }
        }

    }
}
