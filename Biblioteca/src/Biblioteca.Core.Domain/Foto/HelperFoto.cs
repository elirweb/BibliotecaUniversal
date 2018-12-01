using System;
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
                        //if (redimensiona_imagem(arquivo.FileName.ToLower(), 200, 200))
                            arquivo.SaveAs(diretorio + Path.GetFileName(arquivo.FileName.ToLower()));
                    }
                    else
                    {
                        //if (redimensiona_imagem(arquivo.FileName.ToLower(), 200, 200))
                        //{
                            Directory.CreateDirectory(diretorio);
                            arquivo.SaveAs(diretorio + Path.GetFileName(arquivo.FileName.ToLower()));
                        //}
                    }

                    ret = true;
                }

            }

            return ret;
        }


        public  static bool redimensiona_imagem(string xOrigem, int xLargura, int xAltura)
        {
            System.Drawing.Image original;
            System.Drawing.Image nova;
            Int32 altura = 0;
            var ret = false;

            original = System.Drawing.Image.FromFile(xOrigem);

            // Define a altura
            if (xAltura == 0)
            { altura = (original.Height * xLargura) / original.Width; }
            else
            { altura = xAltura; }

            // Cria a nova imagem, redimensionada se necessario
            try
            {
                if (original.Width > xLargura)
                { nova = original.GetThumbnailImage(xLargura, altura, null, IntPtr.Zero); }
                else
                { nova = original; }
                nova.Save(xOrigem);
                original.Dispose();
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw new Exception(ex.Message);
            }
            return ret;
        }
    }
}
