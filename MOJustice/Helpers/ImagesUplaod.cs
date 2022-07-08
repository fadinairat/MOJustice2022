using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http.Headers;
using System.Text;

namespace MOE.Helpers
{
    public class ImagesUplaod
    {
        public static (string, string, string) UploadImage(HttpContext httpContext, string fileSaveFloderName, string webRootPath)
        {
            var newFileName = string.Empty;
            var fileName = string.Empty;
            string PathDB = string.Empty;
            string largPathDB = string.Empty;
            string smallPathDB = string.Empty;

            var files = httpContext.Request.Form.Files;
            
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    //Getting FileName
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var FileExtension = Path.GetExtension(fileName);

                    // concating  FileName + FileExtension
                    newFileName = myUniqueFileName + FileExtension;

                    // Combines two strings into a path.
                    //, "Default"
                    fileName = Path.Combine(webRootPath, fileSaveFloderName) + $@"\{newFileName}";

                    // if you want to store path of folder in database
                    PathDB = "~/" + fileSaveFloderName + newFileName;

                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fs);

                        fs.Flush();
                    }
                    var baseImage = Image.FromFile(fileName);

                    largPathDB = "~/" + fileSaveFloderName + "Larg/" + newFileName;
                    string largFileName = Path.Combine(webRootPath, fileSaveFloderName, "Larg") + $@"\{newFileName}";
                    Image largImageResized = ResizeImage(baseImage,775, 433);
                    largImageResized.Save(largFileName, ImageFormat.Jpeg);
                    largImageResized.Dispose();

                    smallPathDB = "~/" + fileSaveFloderName + "Small/" + newFileName;
                    string smallFileName = Path.Combine(webRootPath, fileSaveFloderName, "Small") + $@"\{newFileName}";
                    if(fileSaveFloderName == "image/VideosThumImg/")
                    {
                        Image smallImageResized = ResizeImage(baseImage, 470, 290);
                        smallImageResized.Save(smallFileName, ImageFormat.Jpeg);
                        smallImageResized.Dispose();
                    }
                    else
                    {
                        Image smallImageResized = ResizeImage(baseImage, 300, 290);
                        smallImageResized.Save(smallFileName, ImageFormat.Jpeg);
                        smallImageResized.Dispose();
                    }
                }
            }
            return (PathDB, largPathDB, smallPathDB);
        }

        public static (string, string, string) UploadSingleImage(HttpContext httpContext, string fileSaveFloderName, string webRootPath,string FileArg)
        {
            var newFileName = string.Empty;
            var fileName = string.Empty;
            string PathDB = string.Empty;
            string largPathDB = string.Empty;
            string smallPathDB = string.Empty;

            var files = httpContext.Request.Form.Files;
            try
            {
                var file = files.GetFile(FileArg);
                if (file!= null && file.Length > 0)
                {
                    //Getting FileName
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var FileExtension = Path.GetExtension(fileName);

                    // concating  FileName + FileExtension
                    newFileName = myUniqueFileName + FileExtension;

                    // Combines two strings into a path.
                    //, "Default"
                    fileName = Path.Combine(webRootPath, fileSaveFloderName) + $@"\{newFileName}";

                    // if you want to store path of folder in database
                    PathDB = "~/" + fileSaveFloderName + newFileName;

                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fs);

                        fs.Flush();
                    }
                    var baseImage = Image.FromFile(fileName);

                    largPathDB = "~/" + fileSaveFloderName + "Larg/" + newFileName;
                    string largFileName = Path.Combine(webRootPath, fileSaveFloderName, "Larg") + $@"\{newFileName}";
                    Image largImageResized = ResizeImage(baseImage, 775, 433);
                    largImageResized.Save(largFileName, ImageFormat.Jpeg);
                    largImageResized.Dispose();

                    smallPathDB = "~/" + fileSaveFloderName + "Small/" + newFileName;
                    string smallFileName = Path.Combine(webRootPath, fileSaveFloderName, "Small") + $@"\{newFileName}";
                    if (fileSaveFloderName == "image/VideosThumImg/")
                    {
                        Image smallImageResized = ResizeImage(baseImage, 470, 290);
                        smallImageResized.Save(smallFileName, ImageFormat.Jpeg);
                        smallImageResized.Dispose();
                    }
                    else
                    {
                        Image smallImageResized = ResizeImage(baseImage, 300, 290);
                        smallImageResized.Save(smallFileName, ImageFormat.Jpeg);
                        smallImageResized.Dispose();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            //foreach (var file in files)
            //{
                
            //}
            return (PathDB, largPathDB, smallPathDB);
        }

        public static string UploadFile(HttpContext httpContext, string fileSaveFloderName, string webRootPath, string FileArg)
        {
            var newFileName = string.Empty;
            var fileName = string.Empty;
            string PathDB = string.Empty;
            

            var files = httpContext.Request.Form.Files;
            try
            {
                var file = files.GetFile(FileArg);
                if (file != null && file.Length > 0)
                {
                    //Getting FileName
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var FileExtension = Path.GetExtension(fileName);

                    // concating  FileName + FileExtension
                    newFileName = myUniqueFileName + FileExtension;

                    // Combines two strings into a path.
                    //, "Default"
                    fileName = Path.Combine(webRootPath, fileSaveFloderName) + $@"\{newFileName}";

                    // if you want to store path of folder in database
                    PathDB = "~/" + fileSaveFloderName + newFileName;

                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fs);

                        fs.Flush();
                    }
                    var baseImage = Image.FromFile(fileName);

                    //largPathDB = "~/" + fileSaveFloderName + "Larg/" + newFileName;
                    //string largFileName = Path.Combine(webRootPath, fileSaveFloderName, "Larg") + $@"\{newFileName}";
                    //Image largImageResized = ResizeImage(baseImage, 775, 433);
                    //largImageResized.Save(largFileName, ImageFormat.Jpeg);
                    //largImageResized.Dispose();

                    //smallPathDB = "~/" + fileSaveFloderName + "Small/" + newFileName;
                    //string smallFileName = Path.Combine(webRootPath, fileSaveFloderName, "Small") + $@"\{newFileName}";
                    //if (fileSaveFloderName == "image/VideosThumImg/")
                    //{
                    //    Image smallImageResized = ResizeImage(baseImage, 470, 290);
                    //    smallImageResized.Save(smallFileName, ImageFormat.Jpeg);
                    //    smallImageResized.Dispose();
                    //}
                    //else
                    //{
                    //    Image smallImageResized = ResizeImage(baseImage, 300, 290);
                    //    smallImageResized.Save(smallFileName, ImageFormat.Jpeg);
                    //    smallImageResized.Dispose();
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }


            //foreach (var file in files)
            //{

            //}
            return PathDB;
        }


        public static (string, string, string) UploadImageXml(string filePath, string fileName,  string fileSaveFloderName, string webRootPath)
        {
            var newFileName = string.Empty;
            string PathDB = string.Empty;
            string largPathDB = string.Empty;
            string smallPathDB = string.Empty;
            string oldFilePath = string.Empty;
            string oldFileName = string.Empty;


            if (fileName.Length > 0)
                {
                //Getting FileName
                    oldFileName = fileName;

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var FileExtension = Path.GetExtension(fileName);

                    // concating  FileName + FileExtension
                    newFileName = myUniqueFileName + FileExtension;

                    // Combines two strings into a path.
                    fileName = Path.Combine(webRootPath, fileSaveFloderName, "Default") + $@"\{newFileName}";

                    // if you want to store path of folder in database
                    PathDB = "~/" + fileSaveFloderName + "Default/" + newFileName;

                    oldFilePath = Path.Combine(filePath, oldFileName);

                    System.IO.File.Copy(oldFilePath, fileName, true);



                    var baseImage = Image.FromFile(fileName);

                    largPathDB = "~/" + fileSaveFloderName + "Larg/" + newFileName;
                    string largFileName = Path.Combine(webRootPath, fileSaveFloderName, "Larg") + $@"\{newFileName}";
                    Image largImageResized = ResizeImage(baseImage, 775, 433);
                    largImageResized.Save(largFileName, ImageFormat.Jpeg);
                    largImageResized.Dispose();

                    smallPathDB = "~/" + fileSaveFloderName + "Small/" + newFileName;
                    string smallFileName = Path.Combine(webRootPath, fileSaveFloderName, "Small") + $@"\{newFileName}";
                    if (fileSaveFloderName == "image/VideosThumImg/")
                    {
                        Image smallImageResized = ResizeImage(baseImage, 470, 290);
                        smallImageResized.Save(smallFileName, ImageFormat.Jpeg);
                        smallImageResized.Dispose();

                    }
                    else
                    {
                        Image smallImageResized = ResizeImage(baseImage, 300, 290);
                        smallImageResized.Save(smallFileName, ImageFormat.Jpeg);
                        smallImageResized.Dispose();

                    }


                }
            
            return (PathDB, largPathDB, smallPathDB);
        }



        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
