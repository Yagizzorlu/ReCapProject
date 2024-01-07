using Core.Utilites.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Core.Constants;

namespace Core.Utilites.Helpers.FileHelper
{
    public class FileHelper 
    {
            private static string CurrentDirectory = Environment.CurrentDirectory + "\\wwwroot";
            private const string FolderName = "\\Images\\";

            public static IResult Upload(IFormFile file)
            {
                var fileExists = CheckFileExists(file);
                if (fileExists.Message != null)
                {
                    return new ErrorResult(fileExists.Message);
                }

                var type = Path.GetExtension(file.FileName);
                var typeValid = CheckFileType(type);
                var randomName = Guid.NewGuid().ToString();

                if (typeValid.Message != null)
                {
                    return new ErrorResult(typeValid.Message);
                }

                CheckDirectory(CurrentDirectory + FolderName);
                CreateImageFile(CurrentDirectory + FolderName + randomName + type, file);
                return new SuccessResult((FolderName + randomName + type).Replace("\\", "/"));
            }

            public static IResult Update(IFormFile file, string carImagePath)
            {
                var fileExists = CheckFileExists(file);
                if (fileExists.Message != null)
                {
                    return new ErrorResult(fileExists.Message);
                }

                var type = Path.GetExtension(file.FileName);  //dosyanın uzantısını alır.Ne ise ona dönüştürür.Bu uzantı değeri type adlı değişkene atanır.
                var typeValid = CheckFileType(type);     //Çağırılan methoda type değişkeni gönderiliyor.Dosya türünün geçerli olup olmadığı kontrol edilir.
                var randomName = Guid.NewGuid().ToString();       //GUID stringe dönüştürülür ve random name a atılır.İsimlerin çakışmasını önlemek için vardır.

                if (typeValid.Message != null)
                {
                    return new ErrorResult(typeValid.Message);
                }

                DeleteOldImageFile((CurrentDirectory + carImagePath).Replace("/", "\\"));
                CheckDirectory(CurrentDirectory + FolderName);
                CreateImageFile(CurrentDirectory + FolderName + randomName + type, file);
                return new SuccessResult((FolderName + randomName + type).Replace("\\", "/"));
            }

            public static IResult Delete(string carImagepath)
            {
                DeleteOldImageFile((CurrentDirectory + carImagepath).Replace("/", "\\"));
                return new SuccessResult();
            }

            private static IResult CheckFileExists(IFormFile file)
            {
                if (file != null && file.Length > 0)
                {
                    return new SuccessResult();
                }
                return new ErrorResult(Messages.FileNotExist);
            }

            private static IResult CheckFileType(string type)
            {
                if (type == ".jpeg" || type == ".png" || type == ".jpg")
                {
                    return new SuccessResult();
                }
                return new ErrorResult();
            }

            private static void CheckDirectory(string directory)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            private static void CreateImageFile(string directory, IFormFile file)
            {
                using (FileStream fileStream = File.Create(directory))
                {
                    file.CopyTo(fileStream);      //dosyanın kopyalanacağı yer söylendi.
                    fileStream.Flush();          //Arabellekten silme
                };
            }

            private static void DeleteOldImageFile(string directory)
            {
                if (File.Exists(directory.Replace("/", "\\")))
                {
                    File.Delete(directory.Replace("/", "\\"));
                }
            }
        }
    }
