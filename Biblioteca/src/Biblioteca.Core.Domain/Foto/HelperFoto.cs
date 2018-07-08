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
                var Ext = System.IO.Path.GetExtension(arquivo.FileName);
                if (Ext.ToLower() == ".jpg" || Ext.ToLower() == ".gif" ||
                    Ext.ToLower() == ".jpeg" || Ext.ToLower() == ".png")
                {
                    var diretorio = HttpContext.Current.Server.MapPath("~/") + "Fotos/";
                    if (System.IO.Directory.Exists(diretorio))
                    {
                        arquivo.SaveAs(diretorio + System.IO.Path.GetFileName(arquivo.FileName.ToLower()));
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(diretorio);
                        arquivo.SaveAs(diretorio + System.IO.Path.GetFileName(arquivo.FileName.ToLower()));

                    }

                    ret = true;
                }

            }else
            {
                ret = false;
            }

            return ret;
        }
    }
}
