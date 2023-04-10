using System.Web;
using System.Web.Optimization;

namespace SoteloProjectFramework
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.bundle.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/cssAdmin").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/sb-admin-2.css",
                      "~/Content/lib/datatables/dataTables.bootstrap4.css",
                      "~/Content/lib/sweetalert2/dist/sweetalert2.css",
                      "~/Content/lib/font-awesome/css/all.css",
                      "~/Content/lib/font-awesome/css/fontawesome.css",
                      "~/Content/lib/select2/dist/css/select2.css"));
            
            bundles.Add(new Bundle("~/bundles/libraries").Include(
                        "~/Content/js/sb-admin-2.js",
                        "~/Content/lib/Chart.js/chart.umd.js",
                        "~/Content/lib/datatables.net/jquery.dataTables.js",
                        "~/Content/lib/sweetalert2/dist/sweetalert2.js",
                        "~/Content/lib/font-awesome/js/all.js",
                        "~/Content/lib/font-awesome/js/fontawesome.js",
                        "~/Content/lib/select2/dist/js/select2.js"));
        }
    }
}
