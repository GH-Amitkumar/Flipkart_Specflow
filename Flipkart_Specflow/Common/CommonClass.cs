using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace Flipkart_Specflow.Common
{
    public static class CommonClass
    {
        public static  void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                                                    FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                                                    ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                                                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }

                //Create_File(artifactDirectory, fileNameBase + "_source", pageSource);
                //Convert_Html_to_Pdf(artifactDirectory, fileNameBase + "_source", artifactDirectory + @"\" + fileNameBase + "_source", false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }

        /// <summary>
        /// Create HTML file from HTML source code
        /// </summary>
        /// <param name="strDirectoryPath">File to be creating in this path</param>
        /// <param name="FileName">Creating File Name</param>
        /// <param name="strHtmlCode">Html source code</param>
        public static void Create_File(string strDirectoryPath, string FileName, string strHtmlCode)
        {
            try
            {
                if (!Directory.Exists(strDirectoryPath))
                    Directory.CreateDirectory(strDirectoryPath);

                //strFilePathWithName/FileName = "c://test.htm"
                if (File.Exists(strDirectoryPath + "//" + FileName + ".html"))
                    File.Delete(strDirectoryPath + "//" + FileName + ".html");

                using (FileStream fs = new FileStream(strDirectoryPath + "//" + FileName + ".html", FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine(strHtmlCode);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        
        /// <summary>
        /// HTML File to PDF file conversion
        /// </summary>
        /// <param name="FileSavePath">Path to be save file</param>
        /// <param name="FileName">File name to be creating without extension</param>
        /// <param name="strSourcePath">Source file path with File name but without extension</param>
        /// <param name="isHtmlDelete">Take a decession html file save or delete via 'true' or 'false'</param>
        public static void Convert_Html_to_Pdf(string FileSavePath, string FileName, string strSourcePath, bool isHtmlDelete)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                startInfo.Arguments = " --headless --print-to-pdf-no-header --print-to-pdf=\"" + FileSavePath + "//" + FileName + ".pdf\" \"" + strSourcePath + ".html\"";
                Process.Start(startInfo);

                do
                {
                    Thread.Sleep(2000);
                } while (!File.Exists(FileSavePath + "//" + FileName + ".pdf"));

                if (isHtmlDelete)
                {
                    if (File.Exists(strSourcePath + ".html"))
                        File.Delete(strSourcePath + ".html");
                }

                string screenshotPDFFilePath = Path.Combine(FileSavePath + "//" + FileName + ".pdf");
                Console.WriteLine("PDF Source : {0}", new Uri(screenshotPDFFilePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot of PDF: {0}", ex);
            }
        }

    }
}
