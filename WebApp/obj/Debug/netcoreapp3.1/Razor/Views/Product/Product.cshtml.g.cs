#pragma checksum "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e4d727f154bdd134088e3492e23f2dbe85962c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Product), @"mvc.1.0.view", @"/Views/Product/Product.cshtml")]
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
#line 1 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e4d727f154bdd134088e3492e23f2dbe85962c0", @"/Views/Product/Product.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Product : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModel.ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/blog.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placement", new global::Microsoft.AspNetCore.Html.HtmlString("bottom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-original-title", new global::Microsoft.AspNetCore.Html.HtmlString("Add to Cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shopping", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
  
    ViewData["Title"] = "Product";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5e4d727f154bdd134088e3492e23f2dbe85962c06299", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"container bootdey text-center\">\r\n\r\n");
#nullable restore
#line 9 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
     if (Model == null || Model.ProductList == null || Model.ProductList.Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n        <h2 class=\"disabled\">Product not found.</h2>\r\n        <br />\r\n");
#nullable restore
#line 14 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-md-3 mx-auto\">\r\n");
#nullable restore
#line 19 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
                  var count = Model.ProductList.Count; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
                  int columns = Model.ColumnsByRow; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
                  int rest = count % columns == 0 ? 0 : columns - count % columns; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2 class=\"text-primary\">");
#nullable restore
#line 22 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
                                    Write(Model.ProductList.FirstOrDefault().Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <div class=\"box-product-outer col-sm\">\r\n                    <div class=\"box-product\">\r\n                        <div class=\"img-wrapper\">\r\n                            <a href=\"#\">\r\n                                <img alt=\"Product\"");
            BeginWriteAttribute("src", " src=\"", 990, "\"", 1046, 1);
#nullable restore
#line 27 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
WriteAttributeValue("", 996, Url.Content("~/Images/default-product-image.png"), 996, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </a>\r\n                            <div class=\"option\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e4d727f154bdd134088e3492e23f2dbe85962c010175", async() => {
                WriteLiteral("\r\n                                    <i class=\"ace-icon fa fa-shopping-cart\"></i>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-accountKey", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
                                                                                                                                                                                        WriteLiteral(Model.ProductList.FirstOrDefault().Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["accountKey"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-accountKey", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["accountKey"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"price\">\r\n                            <h6 class=\"text-dark\">Category: ");
#nullable restore
#line 36 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
                                                       Write(Model.ProductList.FirstOrDefault().Category?.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                            <h4 class=\"text-success\">");
#nullable restore
#line 37 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
                                                Write(Model.ProductList.FirstOrDefault().Price.ToString("$###,###,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""container bootstrap snippets bootdey"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""blog-comment"">
                            <h3 class=""text-info"">Comments</h3>
                            <hr />
                            <ul class=""comments"">
                                <li class=""clearfix"">
                                    <img src=""https://bootdey.com/img/Content/user_1.jpg"" class=""avatar""");
            BeginWriteAttribute("alt", " alt=\"", 2505, "\"", 2511, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                    <div class=""post-comments"">
                                        <p class=""meta"">Dec 18, 2014 <a href=""#"">JohnDoe</a> says : <i class=""pull-right""><a href=""#""><small>Reply</small></a></i></p>
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                            Etiam a sapien odio, sit amet
                                        </p>
                                    </div>
                                </li>
                                <li class=""clearfix"">
                                    <img src=""https://bootdey.com/img/Content/user_2.jpg"" class=""avatar""");
            BeginWriteAttribute("alt", " alt=\"", 3258, "\"", 3264, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                    <div class=""post-comments"">
                                        <p class=""meta"">Dec 19, 2014 <a href=""#"">JohnDoe</a> says : <i class=""pull-right""><a href=""#""><small>Reply</small></a></i></p>
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                            Etiam a sapien odio, sit amet
                                        </p>
                                    </div>

                                    <ul class=""comments"">
                                        <li class=""clearfix"">
                                            <img src=""https://bootdey.com/img/Content/user_3.jpg"" class=""avatar""");
            BeginWriteAttribute("alt", " alt=\"", 4049, "\"", 4055, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                            <div class=""post-comments"">
                                                <p class=""meta"">Dec 20, 2014 <a href=""#"">JohnDoe</a> says : <i class=""pull-right""><a href=""#""><small>Reply</small></a></i></p>
                                                <p>
                                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                                    Etiam a sapien odio, sit amet
                                                </p>
                                            </div>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
");
#nullable restore
#line 90 "D:\JEspinoza\Educacion\Cenfotec\Net Core\Github\FinalProject\FinalProject\WebApp\Views\Product\Product.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModel.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
