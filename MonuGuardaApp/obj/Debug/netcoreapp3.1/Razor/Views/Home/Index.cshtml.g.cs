#pragma checksum "C:\Users\diogo\Documents\GitHub\MonuGuardaApp\MonuGuardaApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3ca88527457ff87b62809d83a29344e75fd4017"
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
#line 1 "C:\Users\diogo\Documents\GitHub\MonuGuardaApp\MonuGuardaApp\Views\_ViewImports.cshtml"
using MonuGuardaApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\diogo\Documents\GitHub\MonuGuardaApp\MonuGuardaApp\Views\_ViewImports.cshtml"
using MonuGuardaApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3ca88527457ff87b62809d83a29344e75fd4017", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7320a48455bf588e434efbb0b559d1e4583a328f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\diogo\Documents\GitHub\MonuGuardaApp\MonuGuardaApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3ca88527457ff87b62809d83a29344e75fd40173299", async() => {
                WriteLiteral(@"
    <header>
        <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
            <ol class=""carousel-indicators"">
                <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
                <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
                <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
            </ol>
            <div class=""carousel-inner"" role=""listbox"">
                <!-- Slide One - Set the background image for this slide in the line below -->
                <div class=""carousel-item active"" style=""background-image: url('https://cdn.olhares.pt/client/files/foto/big/167/1671491.jpg')"">
                    <div class=""carousel-caption d-none d-md-block"">
                        <h3>Sé-Catedral da Guarda</h3>
                    </div>
                </div>
                <!-- Slide Two - Set the background image for this slide in the line below -->
       ");
                WriteLiteral(@"         <div class=""carousel-item"" style=""background-image: url('https://live.staticflickr.com/621/23887647145_6faf135948.jpg')"">
                    <div class=""carousel-caption d-none d-md-block"">
                        <h3>Castelo da Guarda</h3>
                    </div>
                </div>
                <!-- Slide Three - Set the background image for this slide in the line below -->
                <div class=""carousel-item"" style=""background-image: url('https://www.cm-sabugal.pt/wp-content/uploads/2019/05/carmina-burana-1.jpg')"">
                    <div class=""carousel-caption d-none d-md-block"">
                        <h3>Castelo de Sabugal</h3>
                    </div>
                </div>
            </div>
            <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Previous</span>
            </a>
  ");
                WriteLiteral(@"          <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Next</span>
            </a>
        </div>
    </header>
    <!-- /.row -->
    <!-- Features Section -->
    <div style=""margin-top: 30px""
    <div class=""row"">
        <div class=""col-lg-6"">
            <h2>Visitas Guiadas</h2>
            <p>Planeie connosco a sua visita à Cidade mais alta!</p>
            <p>
                Os nossos guias são profissionais experientes, juntos irão percorrer a cidade da Guarda e conhecer os principais monumentos assim como ruas, restaurantes entre
                outros locais. Com preços extremamente acessiveis a MonuGuarda é sem duvida o sitio a escolher para conhecer melhor que ninguém a Guarda!
            </p>
            <div class=""col-md-7"">
                <a class=""btn btn-lg btn-secondary btn-block"" href=""/Reserva");
                WriteLiteral("Visita/Create\">Inscreve-te aqui</a>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-lg-6\">\r\n            <img class=\"img-fluid rounded\" src=\"https://codigopostal.ciberforma.pt/images/cidades/cidade-da-guarda.jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 3349, "\"", 3355, 0);
                EndWriteAttribute();
                WriteLiteral(@">
        </div>
    </div>
    </div>

    <!-- Page Content -->
    <div class=""container"">

        <h1 class=""my-4"">Eventos Culturais</h1>

        <!-- Marketing Icons Section -->
        <div class=""row"">
            <div class=""col-lg-4 mb-4"">
                <div class=""card h-100"">
                    <h4 class=""card-header"">GuardaFolia</h4>
                    <div class=""card-body"">
                        <p class=""card-text"">
                            Trata-se  de um Carnaval genuinamente português que tem no Domingo Gordo o seu  auge de festejo com o Desfile e Julgamento do Galo do Entrudo, que vai ser queimado por ""todos os males"". Do  diversificado cartaz constam ainda o Desfile Infantil, as Tabernas do Entrudo, a Fun Run  que promete muita diversão e muito mais.
                        </p>
                    </div>
                    <div class=""card-footer"">
                        <a href=""#"" class=""btn btn-primary"">Saber mais</a>
                    </div>
     ");
                WriteLiteral(@"           </div>
            </div>
            <div class=""col-lg-4 mb-4"">
                <div class=""card h-100"">
                    <h4 class=""card-header"">Feira de São João</h4>
                    <div class=""card-body"">
                        <p class=""card-text"">
                            Colectividades, associações, artesãos, animadores, grupos de música e teatro, vendedores e artistas populares compõem evocação da feira de inícios do século XX.
                        </p>
                    </div>
                    <div class=""card-footer"">
                        <a href=""#"" class=""btn btn-primary"">Saber mais</a>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 mb-4"">
                <div class=""card h-100"">
                    <h4 class=""card-header"">Madeiro de Natal</h4>
                    <div class=""card-body"">
                        <p class=""card-text"">
                            Na Guarda, na noite de consoa");
                WriteLiteral(@"da, enquanto esperas pela Missa do Galo, poderás ir até à Praça Luís de Camões onde encontrarás muitas pessoas à volta da fogueira em frente à Sé catedral. Ali partilham-se vivências e evocam-se recordações. Apesar do frio noturno, vais sentir-te confortável junto do grande braseiro resultante do madeiro.
                        </p>
                    </div>
                    <div class=""card-footer"">
                        <a href=""#"" class=""btn btn-primary"">Saber mais</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->
        <!-- Portfolio Section -->
        <h2>O que visitar</h2>

        <div class=""row"">
            <div class=""col-lg-4 col-sm-6 portfolio-item"">
                <div class=""card h-100"">
                    <a href=""#""><img class=""card-img-top"" src=""https://cdn.visitportugal.com/sites/www.visitportugal.com/files/mediateca/shutterstock_141500719_SeCatedralGuarda_CN_LianeM_660x371.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 6403, "\"", 6409, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
                    <div class=""card-body"">
                        <h4 class=""card-title"">
                            <a href=""#"">Sé-Catedral da Guarda</a>
                        </h4>
                        <p class=""card-text"">
                            Foi erguida no seguimento do pedido de D. Sancho I ao Papa Inocêncio III para transferir a diocese de Egitânia para a nova cidade da Guarda. Da original construção, de estilo românico, nada resta. Foram, no entanto, encontrados alguns vestígios que apontam para um edifício simples.
                        </p>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-sm-6 portfolio-item"">
                <div class=""card h-100"">
                    <a href=""#""><img class=""card-img-top"" src=""https://media-cdn.tripadvisor.com/media/photo-s/0b/97/90/a0/torre-de-nmebagem-castelo.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 7325, "\"", 7331, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
                    <div class=""card-body"">
                        <h4 class=""card-title"">
                            <a href=""#"">Castelo da Guarda</a>
                        </h4>
                        <p class=""card-text"">
                            Em posição dominante sobre a cidade mais alta do país, ergue-se a 1.056,3 metros do nível do mar. Apesar de muito descaracterizado pelas intervenções particularmente a partir do século XIX, os troços remanescentes de seus antigos muros ainda definem, em alguns trechos, os limites urbanos.
                        </p>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-sm-6 portfolio-item"">
                <div class=""card h-100"">
                    <a href=""#""><img class=""card-img-top"" src=""https://www.cm-sabugal.pt/wp-content/uploads/2016/01/cm-sabugal131.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 8231, "\"", 8237, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
                    <div class=""card-body"">
                        <h4 class=""card-title"">
                            <a href=""#"">Castelo do Sabugal</a>
                        </h4>
                        <p class=""card-text"">
                            Em posição dominante sobre a povoação, num pequeno planalto da serra da Malcata, controla a travessia do rio Côa em sua margem direita, donde a sua importância na antiguidade e na época medieval.
                        </p>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-sm-6 portfolio-item"">
                <div class=""card h-100"">
                    <a href=""#""><img class=""card-img-top"" src=""https://mb.web.sapo.io/c97c37ab175a09375dcb9d5dfab58b0341cd51a3.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 9041, "\"", 9047, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
                    <div class=""card-body"">
                        <h4 class=""card-title"">
                            <a href=""#"">Castelo de Linhares da Beira</a>
                        </h4>
                        <p class=""card-text"">
                            Situado num cabeço rochoso num contraforte a noroeste da serra da Estrela, domina o vale do rio Mondego. O seu passado mergulha nas lendas, sendo considerado uma das fortificações medievais mais importantes da Beira Alta Interior.
                        </p>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-sm-6 portfolio-item"">
                <div class=""card h-100"">
                    <a href=""#""><img class=""card-img-top"" src=""https://www.viajecomigo.com/wp-content/uploads/2017/11/Castelo-e-arvore-Trancoso-Portugal-%C2%A9-Viaje-Comigo.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 9942, "\"", 9948, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
                    <div class=""card-body"">
                        <h4 class=""card-title"">
                            <a href=""#"">Castelo de Trancoso</a>
                        </h4>
                        <p class=""card-text"">
                            Ergue-se sobre um planalto na região Nordeste da Beira, vizinho à nascente do rio Távora, afluente do rio Douro, e ao Castelo de Penedono, distante cerca de cinco léguas, com o qual compartilha caraterísticas comuns.
                        </p>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-sm-6 portfolio-item"">
                <div class=""card h-100"">
                    <a href=""#""><img class=""card-img-top"" src=""https://www.aldeiashistoricasdeportugalblog.pt/wp-content/uploads/2018/04/42019488690_8f4489116c_k-1024x683.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 10818, "\"", 10824, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
                    <div class=""card-body"">
                        <h4 class=""card-title"">
                            <a href=""#"">Praça-forte de Almeida</a>
                        </h4>
                        <p class=""card-text"">
                            A par com a Praça-forte de Valença e com a Praça-forte de Elvas, esta é considerada como a mais monumental das praças do país. Confrontava-se com o Real Fuerte de la Concepción, no lado oposto da fronteira.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap core JavaScript -->
    <script src=""vendor/jquery/jquery.min.js""></script>
    <script src=""vendor/bootstrap/js/bootstrap.bundle.min.js""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
