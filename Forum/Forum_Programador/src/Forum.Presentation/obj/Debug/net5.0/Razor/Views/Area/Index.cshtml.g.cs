#pragma checksum "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f3b6a6d5bc3ee8749f5b60cd490088cb75b9db1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Area_Index), @"mvc.1.0.view", @"/Views/Area/Index.cshtml")]
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
#line 1 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\_ViewImports.cshtml"
using Forum.Presentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\_ViewImports.cshtml"
using Forum.Presentation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f3b6a6d5bc3ee8749f5b60cd490088cb75b9db1", @"/Views/Area/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5bcc5aa94de854f258aa10409c3707396d8154b", @"/Views/_ViewImports.cshtml")]
    public class Views_Area_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Forum.Application.DTO.AreaDTO>>
    {
        private global::AspNetCore.Views_Area_Index.__Generated__SummaryViewComponentTagHelper __SummaryViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Area", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-secondary badge"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Pagination", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
  
    ViewData["Title"] = "Section";

    var pager = ViewBag.Pager;
    int pageNo = 0;

    if (ViewBag.Pagination != null)
    {
        pager = ViewBag.Pagination;
        pageNo = pager.CurrentPage;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<style>\r\n    body {\r\n        margin-top: 20px;\r\n        background: #f8f8f8\r\n    }\r\n</style>\r\n\r\n<div class=\"container\">\r\n    <div class=\"row flex-lg-nowrap\">\r\n\r\n        <div class=\"col\">\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:summary", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f3b6a6d5bc3ee8749f5b60cd490088cb75b9db17443", async() => {
            }
            );
            __SummaryViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_Area_Index.__Generated__SummaryViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__SummaryViewComponentTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

            <div class=""row flex-lg-nowrap"">
                <div class=""col mb-3"">
                    <div class=""e-panel card"">
                        <div class=""card-body"">
                            <div class=""card-title"">
                                <h6 class=""mr-2""><span>Area Forum</span></h6>
                            </div>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3b6a6d5bc3ee8749f5b60cd490088cb75b9db18726", async() => {
                WriteLiteral("Create");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3b6a6d5bc3ee8749f5b60cd490088cb75b9db110198", async() => {
                WriteLiteral("Back Admin Area");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                            <div class=""e-table"">
                                <div class=""table-responsive table-lg mt-3"">
                                    <table class=""table table-bordered"">
                                        <thead>
                                            <tr>
                                                <th class=""max-width"">Name</th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
");
#nullable restore
#line 53 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
                                             if (Model.Any())
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
                                                 foreach (var item in Model)
                                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n                                                        <td> ");
#nullable restore
#line 59 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
                                                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </td>

                                                        <td class=""text-center align-middle"">
                                                            <div class=""btn-group align-top"">
                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f3b6a6d5bc3ee8749f5b60cd490088cb75b9db113657", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
                                                                                                                                                                            WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                                <button class=\"btn btn-sm btn-outline-secondary badge\" type=\"button\" data-toggle=\"modal\" id=\"deleteClicked\" onclick=\"getAreaId(this)\"");
            BeginWriteAttribute("value", " value=\"", 2657, "\"", 2673, 1);
#nullable restore
#line 64 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
WriteAttributeValue("", 2665, item.Id, 2665, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" data-target=""#delete-section-modal""><i class=""fa fa-trash""></i></button>
                                                            </div>
                                                        </td>
                                                    </tr>
");
#nullable restore
#line 68 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </tbody>\r\n                                    </table>\r\n                                </div>\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f3b6a6d5bc3ee8749f5b60cd490088cb75b9db117963", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
#nullable restore
#line 76 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = pager;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <!-- ""Modal Delete Area -->
            <div class=""modal"" tabindex=""-1"" role=""dialog"" id=""delete-section-modal"">
                <div class=""modal-dialog"" role=""document"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <h5 class=""modal-title"">Delete Area</h5>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                <span aria-hidden=""true"">&times;</span>
                            </button>
                        </div>
                        <div class=""modal-body"">
                            <p>You sure that want to delete this Area?.</p>
                        </div>
                        <div class=""modal-footer"">
                            <button type=""button"" class=");
            WriteLiteral(@"""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                            <button type=""button"" onclick=""deleteArea()"" class=""btn btn-danger"">Confirm</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">

        var idArea;

        function getAreaId(event) {
            debugger
            idArea = event.value;
            alert(idArea)
        }

        function deleteArea() {

            debugger

            $.ajax({
                type: ""DELETE"",
                url: '");
#nullable restore
#line 128 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Area\Index.cshtml"
                 Write(Url.Action("Delete", "Area"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                data: { id: idArea },
                success: function () {
                    location.reload();
                },
                error: function (xhr, status, error) {
                    alert('An error occured');
                }
            });
        }

    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Forum.Application.DTO.AreaDTO>> Html { get; private set; }
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:summary")]
        public class __Generated__SummaryViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__SummaryViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("Summary", ProcessInvokeAsyncArgs(__context));
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
            private Dictionary<string, object> ProcessInvokeAsyncArgs(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context)
            {
                Dictionary<string, object> args = new Dictionary<string, object>();
                return args;
            }
        }
    }
}
#pragma warning restore 1591
