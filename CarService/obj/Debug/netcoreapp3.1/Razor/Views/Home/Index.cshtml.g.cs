#pragma checksum "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11a66c0110b9c1b38f2054d77c06f878408515d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\_ViewImports.cshtml"
using CarService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\_ViewImports.cshtml"
using CarService.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11a66c0110b9c1b38f2054d77c06f878408515d0", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c529d585eb1018af216a6ba22525d012622f1cbc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarService.Models.QueryStack.ViewModels.GlobalViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Início";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<fieldset class=\"form-group\">\r\n    <div class=\"container-fluid\">\r\n");
#nullable restore
#line 9 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
         if (ViewBag.Alert != string.Empty && ViewBag.Alert != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <script type=\"text/javascript\">\r\n                    alert(\'");
#nullable restore
#line 12 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
                      Write(ViewBag.Alert);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n            </script>\r\n");
#nullable restore
#line 14 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4 style=\"text-align:center\">Serviço de agendamento de manutenção - Coelho\'s garage</h4>\r\n        <h5 style=\"text-align:center\">Insira seus dados e de seu veículo abaixo</h5>\r\n");
#nullable restore
#line 17 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
         using (Html.BeginForm("SaveData", "Home", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-row\">\r\n                <div class=\"col-sm-6 col-md-6\">\r\n                    <div>\r\n                        <label>Nome</label>\r\n                    </div>\r\n                    ");
#nullable restore
#line 24 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
               Write(Html.TextBoxFor(m => m.Cliente.Nome, new { @class = "form-control form-control-sm", @required = "required", placeholder = "Nome Completo", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-row\">\r\n                <div class=\"col-sm-6 col-md-6\">\r\n                    <div>\r\n                        <label>E-Mail</label>\r\n                    </div>\r\n                    ");
#nullable restore
#line 32 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
               Write(Html.TextBoxFor(m => m.Cliente.EMail, new { @type = "email", @class = "form-control form-control-sm", @required = "required", placeholder = "seuemail@dominio.com.br", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-6 col-md-6\">\r\n                    <div>\r\n                        <label>Telefone</label>\r\n                    </div>\r\n                    ");
#nullable restore
#line 38 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
               Write(Html.TextBoxFor(m => m.Cliente.Telefone, new { @type = "tel", @class = "form-control form-control-sm", @required = "required", placeholder = "(00) 00000-0000", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
            <hr />
            <div class=""form-row"">
                <div class=""col-sm-6"">
                    <div>
                        <label>Marca</label>
                    </div>
                    ");
#nullable restore
#line 47 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
               Write(Html.DropDownListFor(m => m.Veiculo.Marca, Model.VeiculoMarca, "Selecione a Marca", new { @class = "form-control form-control-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-6\">\r\n                    <label>Modelo</label>\r\n                    ");
#nullable restore
#line 51 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
               Write(Html.DropDownListFor(m => m.Veiculo.Modelo, Model.VeiculoModelo, "Selecione o Modelo", new { @class = "form-control form-control-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-6\">\r\n                    <label>Ano</label>\r\n                    ");
#nullable restore
#line 55 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
               Write(Html.DropDownListFor(m => m.Veiculo.AnoVeiculo, Model.VeiculoAno, "Selecione o Ano", new { @class = "form-control form-control-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm-6\">\r\n                    <label>Data para manutenção</label>\r\n                    ");
#nullable restore
#line 59 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
               Write(Html.TextBoxFor(m => m.Servico.DataManutencao, new { @type = "date", @class = "form-control form-control-sm", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
            <hr />
            <h6 style=""text-align:center"">Serviços a serem realizados</h6>
            <div class=""form-row"">
                <div class=""repair"">
                    <div class=""col"">
                        ");
#nullable restore
#line 67 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
                   Write(Html.CheckBoxFor(m => m.Servico.Completo));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Completo\r\n                        ");
#nullable restore
#line 68 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
                   Write(Html.CheckBoxFor(m => m.Servico.Mecanica));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Mecânica/ Elétrica\r\n                        ");
#nullable restore
#line 69 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
                   Write(Html.CheckBoxFor(m => m.Servico.Suspensao));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Suspensão\r\n                        ");
#nullable restore
#line 70 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
                   Write(Html.CheckBoxFor(m => m.Servico.Freio));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Freio\r\n                    </div>\r\n                </div>\r\n                <input class=\"btn btn-outline-dark\" type=\"submit\" value=\"Agendar\">\r\n            </div>\r\n");
#nullable restore
#line 75 "C:\Users\joaop_000\Desktop\Fonts.NET\CarService\CarService\CarService\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</fieldset>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarService.Models.QueryStack.ViewModels.GlobalViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591