﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GroupDocs.Conversion.Config;
using GroupDocs.Conversion.Converter.Option;
using GroupDocs.Conversion.Handler;

namespace GroupDocs.Conversion.Examples.CSharp
{
    public static class Rendering
    {
        #region Converts and Render in HTML

        /// <summary>
        /// Converts and Render file to a HTML format and get output as file path
        /// </summary> 

        public static void RenderHTMLAsPath()
        {
            //ExStart:RenderHTMLAsPath
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted HTML documents.
            // Returns paths to the converted HTML documents.
            var saveOptions = new HtmlSaveOptions
            {
                
                PageNumber = 2,
                NumPagesToConvert = 2,
                UsePdf = true,
                
            };
            var convertedDocumentPath = conversionHandler.Convert(Common.inputGUIDFile, new HtmlSaveOptions { });
            convertedDocumentPath.Save("result-" + Common.inputGUIDFile);
            //ExEnd:RenderHTMLAsPath
        }

        /// <summary>
        /// Converts and Render Document as HTML format and outputs the resulting file to a stream
        /// </summary>

        public static void RenderHTMLAsStream()
        {
            //ExStart:RenderHTMLAsStream
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted HTML documents. 
            // Returns the converted HTML documents as IO Stream.
            var convertedDocumentStream = conversionHandler.Convert(Common.inputGUIDFile, new HtmlSaveOptions());
            MemoryStream targetStream = new MemoryStream();
            convertedDocumentStream.Save(targetStream);

            //ExEnd:RenderHTMLAsStream
        }

        /// <summary>
        /// In advance options example Converts and Render Password Protected file to HTML format
        /// </summary

        public static void RenderHTMLAdvanceOptions()
        {
            //ExStart:RenderHTMLAdvanceOptions
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            //Set password to unprotect protected document during loading
            LoadOptions loadOptions = new LoadOptions { Password = "secret" };

            // convert starting from page 2 and convert 2 pages
            SaveOptions saveOptions = new HtmlSaveOptions
            {
                PageNumber = 2,
                FixedLayout = true,
                NumPagesToConvert = 2


            };

            // Unprotect input document, Convert and save HTML documents using advance options.
            // Returns the converted HTML documents as IO Stream.
            var convertedDocumentStream = conversionHandler.Convert(Common.inputGUIDFile, loadOptions, saveOptions);
            MemoryStream targetStream = new MemoryStream();
            convertedDocumentStream.Save(targetStream);

            //ExEnd:RenderHTMLAdvanceOptions
        }

        /// <summary>
        /// Converts and Render streamed document into a HTML formated file and get output as file path
        /// </summary>
        public static void RenderToHTMLFromStreamToFile()
        {
            //ExStart:RenderToHTMLFromStreamToFile
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted HTML documents.
            // Returns paths to the converted HTML documents.
            var saveOptions = new HtmlSaveOptions
            {
                
                PageNumber = 2,
                NumPagesToConvert = 2,
                UsePdf = true,
                
            };

            // read input document as a stream
            FileStream fileStream = new FileStream(Path.Combine(Common.storagePath, Common.inputGUIDFile), FileMode.Open, FileAccess.Read);

            var convertedDocumentPath = conversionHandler.Convert(fileStream, new HtmlSaveOptions { });
            convertedDocumentPath.Save("result-" + Common.inputGUIDFile);

            fileStream.Close();
            //ExEnd:RenderToHTMLFromStreamToFile
        }

        /// <summary>
        /// Converts and Render streamed document into a HTML formated file and get output as stream
        /// </summary>
        public static void RenderToHTMLFromStreamToStream()
        {
            //ExStart:RenderToHTMLFromStreamToStream
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted HTML documents. 
            // Returns the converted HTML documents as IO Stream.
            // read input document as a stream
            FileStream fileStream = new FileStream(Path.Combine(Common.storagePath, Common.inputGUIDFile), FileMode.Open, FileAccess.Read);

            var convertedDocumentStream = conversionHandler.Convert(fileStream, new HtmlSaveOptions()); ;
            MemoryStream targetStream = new MemoryStream();
            convertedDocumentStream.Save(targetStream);


            fileStream.Close();
            //ExEnd:RenderToHTMLFromStreamToStream
        }

        #endregion

        #region Converts and Render in Image


        /// <summary>
        /// Converts and Render file to an Image format and get output as file path
        /// </summary> 
        /// <param name="outputFileType"></param>
        public static void RenderImageAsPath(ImageSaveOptions.ImageFileType outputFileType)
        {
            //ExStart:RenderImageAsPath
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted image file.
            // Returns paths to the converted image file.
            var saveOptions = new ImageSaveOptions
            {
                ConvertFileType = ImageSaveOptions.ImageFileType.Jpg,
            };

            var convertedDocumentPath = conversionHandler.Convert(Common.inputGUIDFile, saveOptions);
            convertedDocumentPath.Save("result-" + Common.inputGUIDFile);
            //ExEnd:RenderImageAsPathi
        }

        /// <summary>
        /// Converts and Render Document as Image format and outputs the resulting file to a stream
        /// </summary>
        /// <param name="outputFileType"></param>
        public static void RenderImageAsStream(ImageSaveOptions.ImageFileType outputFileType)
        {
            //ExStart:RenderImageAsStream
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted image file. 
            // Returns the converted image file as IO Stream.
            var convertedDocumentStream = conversionHandler.Convert<IList<Stream>>(Common.inputGUIDFile, new ImageSaveOptions { ConvertFileType = outputFileType });
            //ExEnd:RenderImageAsStream
        }

        /// <summary>
        /// In advance options example Converts and Render Password Protected file to Image format
        /// </summary>
        /// <param name="outputFileType"></param>
        public static void RenderImageAdvanceOptions(ImageSaveOptions.ImageFileType outputFileType)
        {
            //ExStart:RenderImageAdvanceOptions
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            //Set password to unprotect protected document during loading
            LoadOptions loadOptions = new LoadOptions { Password = "secret" };

            // convert file to Tiff, starting from page 2 and convert 2 pages,
            // use DPI 300, image width 1024, image height 768
            SaveOptions saveOptions = new ImageSaveOptions
            {
                ConvertFileType = outputFileType,
                PageNumber = 2,
                NumPagesToConvert = 2,
                Dpi = 300,
                Width = 1024,
                Height = 768
            };

            // Unprotect input document, Convert and save image file using advance options.
            // Returns the converted image file as IO Stream.
            var convertedDocumentStream = conversionHandler.Convert<IList<Stream>>(Common.inputGUIDFile, loadOptions, saveOptions);
            //ExEnd:RenderImageAdvanceOptions
        }

        /// <summary>
        /// Converts and Render streamed file to an Image format and get output as file path
        /// </summary>
        /// <param name="outputFileType"></param>
        public static void RenderToImageFromStreamToFile(ImageSaveOptions.ImageFileType outputFileType)
        {
            //ExStart:RenderToImageFromStreamToFile
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted image file.
            // Returns paths to the converted image file.
            var saveOptions = new ImageSaveOptions
            {
                ConvertFileType = ImageSaveOptions.ImageFileType.Jpeg,
                
            };

            // read input document as a stream
            FileStream fileStream = new FileStream(Path.Combine(Common.storagePath, Common.inputGUIDFile), FileMode.Open, FileAccess.Read);

            var convertedDocumentPath = conversionHandler.Convert(fileStream, new ImageSaveOptions { });
            convertedDocumentPath.Save("result-" + Common.inputGUIDFile);

            fileStream.Close();
            //ExEnd:RenderToImageFromStreamToFile
        }

        /// <summary>
        /// Converts and Render streamed Document as Image format and outputs the resulting file to a stream
        /// </summary>
        /// <param name="outputFileType"></param>
        public static void RenderToImageFromStreamToStream(ImageSaveOptions.ImageFileType outputFileType)
        {
            //ExStart:RenderToImageFromStreamToStream
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Returns the converted image file as IO Stream.
            // read input document as a stream
            FileStream fileStream = new FileStream(Path.Combine(Common.storagePath, Common.inputGUIDFile), FileMode.Open, FileAccess.Read);

            var convertedDocumentStream = conversionHandler.Convert<IList<Stream>>(fileStream, new ImageSaveOptions { ConvertFileType = outputFileType });

            fileStream.Close();
            //ExEnd:RenderToImageFromStreamToStream
        }

        /// <summary>
        /// Converts and Render file to an PSD Image format and get output as file path
        /// </summary> 
        /// <param name="outputFileType"></param>
        public static void RenderPSDImageAsPath()
        {
            //ExStart:RenderPSDImageAsPath
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted image file.
            // Returns paths to the converted image file.
            var saveOptions = new ImageSaveOptions
            {
                ConvertFileType = ImageSaveOptions.ImageFileType.Psd,
                //PsdOptions = new PsdOptions
                //{
                //    ColorMode = PsdOptions.ColorModes.Grayscale,
                //    CompressionMethod = PsdOptions.CompressionMethods.Raw
                //}
            };

            var convertedDocumentPath = conversionHandler.Convert(Common.inputGUIDFile, saveOptions);
            convertedDocumentPath.Save(Common.outputPath + "result-" + Common.inputGUIDFile);
            //ExEnd:RenderPSDImageAsPath
        }


        /// <summary>
        /// Converts and Render file to an Webp format and get output as file path
        /// </summary> 
        /// <param name="outputFileType"></param>
        public static void RenderWebpAsPath(ImageSaveOptions.ImageFileType outputFileType)
        {
            //ExStart:RenderWebpformatAsPath
            // Instantiating the conversion handler from custom common class
            ConversionHandler conversionHandler = Common.getConversionHandler(); ;

            // Convert and save converted Webp file.
            // Returns paths to the converted Webp file.
            var saveOptions = new ImageSaveOptions
            {
                ConvertFileType = ImageSaveOptions.ImageFileType.Webp,
            };

            var convertedDocumentPath = conversionHandler.Convert(Common.inputGUIDFile, saveOptions);
            convertedDocumentPath.Save("result-" + Common.inputGUIDFile);
            //ExEnd:RenderWebpformatAsPath
        }

        #endregion
    }
}
