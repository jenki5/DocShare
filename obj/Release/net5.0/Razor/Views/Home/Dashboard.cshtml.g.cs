#pragma checksum "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea27cdc33c9fe5c39e0a3d02904bf85b876f8745"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
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
#line 1 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\_ViewImports.cshtml"
using DocShare;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\_ViewImports.cshtml"
using DocShare.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea27cdc33c9fe5c39e0a3d02904bf85b876f8745", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6e25737d63d8128d2d56954f9886948ddd9bfe3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery/dist/jquery.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery/dist/jquery-ui-1.12.1.custom/jquery-ui.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/zipFileUpload.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
  
ViewData["Title"] = "DocShare Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<header class=\"dashboard-header\">\r\n    <div class=\"h1-div\">\r\n        <h1>Contact</h1>\r\n    </div>\r\n    <div class=\"lab-options-div\">\r\n        <select id=\"lab-options\" class=\"lab-options\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea27cdc33c9fe5c39e0a3d02904bf85b876f87456034", async() => {
                WriteLiteral("All...");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
             for(int i = 0; i < Model.Company.Friends.Count(); i++)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                 if(Model.Company.Friends[i].CompanyID == 3){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea27cdc33c9fe5c39e0a3d02904bf85b876f87457735", async() => {
#nullable restore
#line 17 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                                                                            Write(Model.Company.Friends[i].CompanyName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                                WriteLiteral(Model.Company.Friends[i].CompanyID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                }
                else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea27cdc33c9fe5c39e0a3d02904bf85b876f874510192", async() => {
#nullable restore
#line 20 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                                                                   Write(Model.Company.Friends[i].CompanyName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                       WriteLiteral(Model.Company.Friends[i].CompanyID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n    </div>\r\n    <div class=\"selected-lab\">\r\n        <div class=\"lab-box\">\r\n            <h2 id=\"lab-name\">");
#nullable restore
#line 27 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                         Write(Model.Company.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<i class=""fa fa-user-circle logout-dropdown"" aria-hidden=""true""></i></h2>
            <div class=""logout-box"">
                <a href=""Logout"" id=""logout-btn"">Logout</a>
            </div>    
        </div>
    </div>
</header>
<div class=""overlay center"" id=""new-case-modal"">
    <div class=""case-creator modal"">
        <div class=""header"">
            <h2>New Case</h2>
            <span class=""close-x"" id=""case-creator-close-x"">&#215;</span>
        </div>
        <div class=""add-new-supplier-div"">
            <a class=""add-new-supplier-btn"">Add New Supplier</a>
        </div>
        <div class=""data-points"" id=""new-cases-data-points""></div>
        <button");
            BeginWriteAttribute("class", " class=\"", 1611, "\"", 1619, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""submit-new-cases"">Save New Cases</button>
    </div>
</div>
<div class=""overlay center"" id=""confirm-delete-case-modal"">
    <div class=""modal confirm-case-delete"">
        <div class=""header"">
            <h2>Confirm Delete</h2>
            <span class=""close-x"" id=""case-creator-close-x"">&#215;</span>
        </div>
        <div class=""body"">
            <p>Are you sure you would like to delete the case <b id=""confirm-delete-case-name""></b>?</p>
            <div class=""buttons"">
                <button class=""confirm-delete-btn"" id=""confirm-delete-btn"">Confirm</button>
                <button class=""close-x"">Cancel</button>
            </div>
        </div>
    </div>
</div>
<div class=""overlay center"" id=""confirm-hold-case-modal"">
    <div class=""modal confirm-case-hold"">
        <div class=""header"">
            <h2 id=""hold-header"">Confirm Hold</h2>
            <span class=""close-x"" id=""case-creator-close-x"">&#215;</span>
        </div>
        <div class=""body"">
            <p");
            WriteLiteral(">Are you sure you would like <span id=\"hold-explanation\">place a hold</span> on the case <b id=\"confirm-hold-case-name\"></b>?</p>\r\n            <p>Please leave a note explanation.</p>\r\n            <div class=\"new-note\">\r\n                <h4>");
#nullable restore
#line 72 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
               Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 72 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                                Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                <div class=""note-area"">
                    <i class=""fa fa-user-md"" aria-hidden=""true""></i>
                    <textarea id=""new-hold-note""></textarea>
                </div>
            </div>
            <div class=""buttons"">
                <button class=""confirm-hold-btn"" id=""confirm-hold-btn"">Confirm</button>
                <button class=""close-x"">Cancel</button>
            </div>
        </div>
    </div>
</div>
<div class=""overlay center"" id=""add-new-supplier-modal"">
    <div class=""modal add-new-supplier"">
        <div class=""header"">
            <h2>Add New Supplier</h2>
            <span class=""close-x"" id=""new-supplier-close-x"">&#215;</span>
        </div>
        <div class=""body"">
            <p>Would you like to add a new supplier to your list of suppliers? Just give us their email and we'll handle the rest.</p>
            <div class=""data-point"">
                <label>Email:</label>
                <input type=""email"" id=""new-supplier-email"">
");
            WriteLiteral(@"            </div>
            <div class=""buttons"">
                <button class=""confirm-hold-btn"" id=""confirm-add-supplier-btn"">Add Supplier</button>
                <button class=""close-x"">Cancel</button>
            </div>
        </div>
    </div>
</div>
<section class=""main-content"">
    <div class=""cases-section"">
        <div class=""section-header"">
            <div class=""search-div"">
                <input type=""text"" class=""search-input"" id=""search-input"">
                <i class=""fa fa-search"" aria-hidden=""true""></i>
            </div>
            <div class=""date-section"">
                <div class=""date-range"">
                    <b>DATE:</b>
                    <input type=""text"" id=""datepickerStart"" class=""datepickerInput"">
                    <b>/</b>
                    <input type=""text"" id=""datepickerEnd"" class=""datepickerInput"">
                    <i class=""fa fa-calendar-alt"" id=""datepicker"" aria-hidden=""true""></i>
                </div>
                <div ");
            WriteLiteral(@"class=""icons"">
                    <i class=""fa fa-download"" aria-hidden=""true""></i>
                    <i class=""fa fa-upload"" aria-hidden=""true""></i>
                    <i class=""fa fa-sync"" aria-hidden=""true""></i>
                    <i class=""fa fa-times"" aria-hidden=""true""></i>
                </div>
            </div>
        </div>
        <div class=""section-body"">
            <div class=""cards"" id=""patient-cards""></div>
            <div class=""section-footer body-footer"">
                <div class=""drop-zone"">
                    <span class=""drop-zone__prompt"">Drop zip file or image here or click to upload</span>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea27cdc33c9fe5c39e0a3d02904bf85b876f874518455", async() => {
                WriteLiteral("\r\n                        <input type=\"file\" class=\"drop-zone__input\" id=\"zip-upload-input\" multiple>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
    <div class=""case-info-section"">
        <div class=""section-header"">
            <ul class=""btn-section"">
                <li class=""btn current"" id=""case-info-btn"">Case Info</li>
                <li class=""btn"" id=""case-history-btn"">Case History</li>
            </ul>
            <h3 class=""date-section hold-border-identifier"" id=""current-case-name""></h3>
        </div>
        <div class=""section-body pictures"">
            <div class=""displayed-image"" id=""display-image-box""></div>
            <div class=""body-footer"">
                <div class=""carousel"">
                    <i class=""fa fa-chevron-left chevron"" aria-hidden=""true""></i>
                    <div class=""other-images"" id=""other-images""></div>
                    <i class=""fa fa-chevron-right chevron"" aria-hidden=""true""></i>
                </div>
                <div class=""camera-box"">
                    <div class=""camera"">
                     ");
            WriteLiteral(@"   <i class=""fa fa-camera"" aria-hidden=""true""></i>
                        <i class=""fa fa-plus"" aria-hidden=""true""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""case-notes-section"">
        <div class=""section-header"">
            <div class=""buttons-section""></div>
            <div class=""hold-info hold-border-identifier"">
                <button class=""btn btn-hold"" id=""hold-btn"">HOLD</button>
                <div class=""case-details"">
                    <b>Case Submitted: <span class=""info"" id=""current-case-date""></span></b>
                    <b>Designer: <span class=""info"" id=""current-case-designer"">");
#nullable restore
#line 171 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                                                                          Write(Model.Company.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></b>
                </div>
            </div>
        </div>
        <div class=""section-body"">
            <div class=""notes"" id=""notes""></div>
            <div class=""body-footer new-note"">
                <div class=""note-div"">
                    <h4>");
#nullable restore
#line 179 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                   Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 179 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                                    Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <div class=\"note-area\">\r\n");
#nullable restore
#line 181 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                         if(Model.Company.CompanyTypeID == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fa fa-user-md\" aria-hidden=\"true\"></i>\r\n");
#nullable restore
#line 184 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fa fa-user\" aria-hidden=\"true\"></i>\r\n");
#nullable restore
#line 188 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <textarea id=\"new-note\"></textarea>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n<script>\r\n    var user = ");
#nullable restore
#line 198 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
          Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n</script>\r\n<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea27cdc33c9fe5c39e0a3d02904bf85b876f874524593", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 201 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea27cdc33c9fe5c39e0a3d02904bf85b876f874526479", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 202 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script>\r\n    $(\"#datepickerStart\").datepicker()\r\n    $(\"#datepickerEnd\").datepicker()\r\n</script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea27cdc33c9fe5c39e0a3d02904bf85b876f874528476", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 207 "C:\Users\tjenk\OneDrive\Documents\CSProjects\DocShare\Views\Home\Dashboard.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591