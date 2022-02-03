#pragma checksum "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4081dd1972891990e94fed424a680e07cd5c36d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Topics), @"mvc.1.0.view", @"/Views/Admin/Topics.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4081dd1972891990e94fed424a680e07cd5c36d1", @"/Views/Admin/Topics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5bcc5aa94de854f258aa10409c3707396d8154b", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Topics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Forum.Application.DTO.TopicDTO>>
    {
        private global::AspNetCore.Views_Admin_Topics.__Generated__SummaryViewComponentTagHelper __SummaryViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-secondary badge"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UsersDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Pagination", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
  
    ViewData["Title"] = "Topics";

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:summary", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4081dd1972891990e94fed424a680e07cd5c36d16504", async() => {
            }
            );
            __SummaryViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_Admin_Topics.__Generated__SummaryViewComponentTagHelper>();
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
                                <h6 class=""mr-2""><span>Topics in Forum</span></h6>
                            </div>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4081dd1972891990e94fed424a680e07cd5c36d17794", async() => {
                WriteLiteral("Back Admin Area");
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
            WriteLiteral(@"

                            <div class=""e-table"">
                                <div class=""table-responsive table-lg mt-3"">
                                    <table class=""table table-bordered"">
                                        <thead>
                                            <tr>
                                                <th class=""max-width"">Name</th>
                                                <th class=""max-width"">Creator</th>
                                                <th class=""max-width"">Create Date</th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
");
#nullable restore
#line 54 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                                             if (Model.Any())
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                                                 foreach (var item in Model)
                                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td> ");
#nullable restore
#line 60 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                                                Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                                <td> ");
#nullable restore
#line 61 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                                                Write(item.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                                <td> ");
#nullable restore
#line 62 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                                                Write(item.CreationDate.ToString("dd//MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                                <td class=\"align-middle\" style=\"width: 100px;\">\r\n                                                    <div class=\"btn-group align-top\">\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4081dd1972891990e94fed424a680e07cd5c36d112151", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                                                                                                                                                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"                                                            <button class=""btn btn-sm btn-outline-secondary badge"" type=""button"" data-toggle=""modal"" id=""deleteClicked"" data-toggle=""tooltip"" data-placement=""top"" title=""Remove"" data-toggle=""modal"" id=""deleteClicked"" onclick=""getTopicId(this)""");
            BeginWriteAttribute("value", " value=\"", 3043, "\"", 3059, 1);
#nullable restore
#line 68 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
WriteAttributeValue("", 3051, item.Id, 3051, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-target=\"#remove-topic-modal\"><i class=\"fa fa-trash\" style=\"color: red;\"></i></button>\r\n");
            WriteLiteral("\r\n                                                    </div>\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 75 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        </tbody>\r\n                                    </table>\r\n                                </div>\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4081dd1972891990e94fed424a680e07cd5c36d116661", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 83 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
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


            <!-- ""Modal Delete Topic -->
            <div class=""modal"" tabindex=""-1"" role=""dialog"" id=""remove-topic-modal"">
                <div class=""modal-dialog"" role=""document"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <h5 class=""modal-title"">Delete this Topic</h5>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                <span aria-hidden=""true"">&times;</span>
                            </button>
                        </div>
                        <div class=""modal-body"">
                            <p>You sure that want to delete this?</p>
                        </div>
                        <div class=""modal-footer"">
                            <button type=""button"" class=""");
            WriteLiteral(@"btn btn-secondary"" data-dismiss=""modal"">Close</button>
                            <button type=""button"" onclick=""deleteTopic()"" class=""btn btn-danger"">Confirm</button>
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

        var topicId;

        function getTopicId(event) {
            debugger
            topicId = event.value;
            //alert(userId)
        }

        function deleteTopic() {

            debugger

            $.ajax({
                type: ""POST"",
                url: '");
#nullable restore
#line 136 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Admin\Topics.cshtml"
                 Write(Url.Action("DeleteTopic", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                data: { topicId: topicId },
                success: function () {
                    location.reload();
                    alert('Topic Deleted Successfully');
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Forum.Application.DTO.TopicDTO>> Html { get; private set; }
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
                var __helperContent = await __helper.InvokeAsync("Summary", new {  });
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
        }
    }
}
#pragma warning restore 1591
