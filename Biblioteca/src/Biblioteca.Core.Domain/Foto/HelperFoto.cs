using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Biblioteca.Core.Domain.Foto
{
    public class HelperFoto
    {
        private bool ret = false;
      
        public bool ArquivarFoto(HttpPostedFileBase arquivo)
        {
            if (arquivo != null && arquivo.ContentLength > 0)
            {
                var Ext = Path.GetExtension(arquivo.FileName);
                if (Ext.ToLower() == ".jpg" || Ext.ToLower() == ".gif" ||
                    Ext.ToLower() == ".jpeg" || Ext.ToLower() == ".png")
                {

                   var diretorio = HttpContext.Current.Server.MapPath("~/") + "Fotos/";
                    if (Directory.Exists(diretorio))
                    {
                        var imagem = Image.FromStream(arquivo.InputStream);
                        
                        ResizeImage(imagem, 200, 200);
                        arquivo.SaveAs(diretorio + Path.GetFileName(arquivo.FileName.ToLower()));
                    }
                    else
                    {
                        var imagem = Image.FromStream(arquivo.InputStream);
                        ResizeImage(imagem, 200, 200);
                        Directory.CreateDirectory(diretorio);
                        arquivo.SaveAs(diretorio + Path.GetFileName(arquivo.FileName.ToLower()));
                        
                    }

                    ret = true;
                }

            }

            return ret;
        }


        public Bitmap ResizeImage(Image image, int width, int height)

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
