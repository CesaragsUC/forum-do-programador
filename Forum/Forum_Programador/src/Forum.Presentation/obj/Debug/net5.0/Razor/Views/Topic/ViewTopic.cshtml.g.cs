#pragma checksum "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5eeef1ac0c60924b1d411077174c8c028037dfcd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Topic_ViewTopic), @"mvc.1.0.view", @"/Views/Topic/ViewTopic.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5eeef1ac0c60924b1d411077174c8c028037dfcd", @"/Views/Topic/ViewTopic.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5bcc5aa94de854f258aa10409c3707396d8154b", @"/Views/_ViewImports.cshtml")]
    public class Views_Topic_ViewTopic : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Forum.Application.DTO.CommentsDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/topic/topicview.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Topic", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Reply", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
   ViewData["Title"] = @ViewBag.TopicTitle; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5eeef1ac0c60924b1d411077174c8c028037dfcd7716", async() => {
                WriteLiteral("\n    <link rel=\"stylesheet\" href=\"/richtexteditor/rte_theme_default.css\" />\n    <link rel=\"stylesheet\" href=\"/richtexteditor/runtime/richtexteditor_preview.css\" />\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5eeef1ac0c60924b1d411077174c8c028037dfcd8149", async() => {
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
                WriteLiteral("\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n<div class=\"col-md-6\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5eeef1ac0c60924b1d411077174c8c028037dfcd10061", async() => {
                WriteLiteral("&nbsp; Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                                                                        WriteLiteral(ViewBag.SectionId);

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
            WriteLiteral("\n</div>\n\n<div class=\"container-fluid mt-100\">\n\n\n    <div class=\"ibox-content m-b-sm\">\n        <div class=\"p-xs\">\n            <h2> ");
#nullable restore
#line 21 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
            Write(ViewBag.TopicTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n        </div>\n    </div>\n\n    <br />\n");
#nullable restore
#line 26 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
       
        foreach (var comment in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card mb-4"">
                    <div class=""card-header"">
                        <div class=""media flex-wrap w-100 align-items-center"">
                            <img src=""https://i.imgur.com/iNmBizf.jpg"" class=""d-block ui-w-40 rounded-circle""");
            BeginWriteAttribute("alt", " alt=\"", 1074, "\"", 1080, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                            <div class=\"media-body ml-3\">\n                                <a href=\"javascript:void(0)\" data-abc=\"true\">");
#nullable restore
#line 37 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                                                                        Write(comment.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n                                <div class=\"text-muted small\">");
#nullable restore
#line 38 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                                                         Write(comment.TimeAgo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                            </div>\n                            <div class=\"text-muted small ml-3\">\n                                <div>Member since <strong>");
#nullable restore
#line 41 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                                                     Write(comment.User.CreationDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\n                                <div id=\"post-id\"><strong>#</strong>");
#nullable restore
#line 42 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                                                               Write(comment.CommentId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\n                            </div>\n                        </div>\n                    </div>\n                    <div class=\"card-body\">\n                        ");
#nullable restore
#line 47 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                    Write(Html.Raw(@comment.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </div>
                    <div class=""card-footer d-flex flex-wrap justify-content-between align-items-center px-0 pt-0 pb-3"">
                        <div class=""px-4 pt-3""> <a href=""javascript:void(0)"" class=""text-muted d-inline-flex align-items-center align-middle"" data-abc=""true""> <i class=""fa fa-heart text-danger""></i>&nbsp; <span class=""align-middle"">445</span> </a> <span class=""text-muted d-inline-flex align-items-center align-middle ml-4""> </span> </div>
                        <div class=""px-4 pt-3"">
");
#nullable restore
#line 53 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                             if (@comment.CanEdit)
                            {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5eeef1ac0c60924b1d411077174c8c028037dfcd16883", async() => {
                WriteLiteral("&nbsp; Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                                                                                  WriteLiteral(comment.Id);

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
#nullable restore
#line 54 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                                                                                                                          } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\n                    </div>\n                </div>\n            </div>\n        </div> ");
#nullable restore
#line 59 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
               } 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
#nullable restore
#line 62 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
     if (true.Equals(ViewData["IsPosted"]))
    {



#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\n    <h1 class=\"display-4\">PreView</h1>\n\n    <div style=\"width: 960px;margin:0 auto;text-align:left;border:solid 1px gray;padding:8px;\">\n        ");
#nullable restore
#line 70 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
    Write(Html.Raw(ViewData["PostedValue"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n\n</div> ");
#nullable restore
#line 73 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
       }
else
{



#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5eeef1ac0c60924b1d411077174c8c028037dfcd20994", async() => {
                WriteLiteral("\n\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5eeef1ac0c60924b1d411077174c8c028037dfcd21257", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 80 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n\n    <input name=\"sectionId\"");
                BeginWriteAttribute("value", " value=\"", 3112, "\"", 3138, 1);
#nullable restore
#line 82 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
WriteAttributeValue("", 3120, ViewBag.SectionId, 3120, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"hidden\" />\n    <input name=\"topicId\"");
                BeginWriteAttribute("value", " value=\"", 3182, "\"", 3206, 1);
#nullable restore
#line 83 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
WriteAttributeValue("", 3190, ViewBag.TopicId, 3190, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""hidden"" />
    <input name=""htmlcode"" id=""inp_htmlcode"" type=""hidden"" />

    <!-- html text -->
    <div class=""form-outline col-md-6"">
        <div id=""div_editor1"" class=""richtexteditor"" style=""width: 960px;margin:0 auto;"">
        </div>
    </div>
    <br />

    <div class=""form-outline form-buttons col-md-6"">
        <!-- Submit button -->
        <button type=""submit"" class=""btn btn-primary"">Post Quick Reply</button>
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5eeef1ac0c60924b1d411077174c8c028037dfcd24344", async() => {
                    WriteLiteral("Back");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
                                                                                                  WriteLiteral(ViewBag.SectionId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    </div>\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 99 "F:\Projetos ASP.NET\forum-do-programador\Forum\Forum_Programador\src\Forum.Presentation\Views\Topic\ViewTopic.cshtml"
       }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n</div>\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"


    <script type=""text/javascript"" src=""/richtexteditor/rte.js""></script>
    <script type=""text/javascript"" src='/richtexteditor/plugins/all_plugins.js'></script>
    <script type=""text/javascript"" src=""/rte-upload.js""></script>

    <script>
        var editor1 = new RichTextEditor(document.getElementById(""div_editor1""));
        editor1.attachEvent(""change"", function () {
            document.getElementById(""inp_htmlcode"").value = editor1.getHTMLCode();
        });
    </script>


");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Forum.Application.DTO.CommentsDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591