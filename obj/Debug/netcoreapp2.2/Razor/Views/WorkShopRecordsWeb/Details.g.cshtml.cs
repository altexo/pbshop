#pragma checksum "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a8a6baf2ec1c8d61ded01a126d8372b135501ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkShopRecordsWeb_Details), @"mvc.1.0.view", @"/Views/WorkShopRecordsWeb/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WorkShopRecordsWeb/Details.cshtml", typeof(AspNetCore.Views_WorkShopRecordsWeb_Details))]
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
#line 1 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/_ViewImports.cshtml"
using pbshop_web;

#line default
#line hidden
#line 2 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/_ViewImports.cshtml"
using pbshop_web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a8a6baf2ec1c8d61ded01a126d8372b135501ec", @"/Views/WorkShopRecordsWeb/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3264bb61dc74f9491a258777caf42c4a305320bb", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkShopRecordsWeb_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<pbshop_web.Models.WorkshopRecordModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default align-middle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
  
    ViewData["Title"] = "Details";
    int workshop_id = @Model.id;

#line default
#line hidden
            BeginContext(125, 44, true);
            WriteLiteral("\r\n<h2 class=\"pbshop-secundary-text-color\">  ");
            EndContext();
            BeginContext(169, 114, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a8a6baf2ec1c8d61ded01a126d8372b135501ec4280", async() => {
                BeginContext(228, 51, true);
                WriteLiteral("<div data-icon=\"ei-arrow-left\" data-size=\"m\"></div>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(283, 19, true);
            WriteLiteral("Detalles de Folio: ");
            EndContext();
            BeginContext(303, 34, false);
#line 8 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
                                                                                                                                                                          Write(Html.DisplayFor(model => model.id));

#line default
#line hidden
            EndContext();
            BeginContext(337, 71, true);
            WriteLiteral("</h2>\r\n\r\n    <div>\r\n        <h4 class=\"text-secondary\">Estado General: ");
            EndContext();
            BeginContext(409, 58, false);
#line 11 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
                                              Write(Html.DisplayFor(model => model.workshop_record_sate.state));

#line default
#line hidden
            EndContext();
            BeginContext(467, 262, true);
            WriteLiteral(@" </h4>
        <hr />
        <div class=""col-md-12 row card-columns"">
           <div class=""col-md-6 card"">
                <div class=""card-body"">
                    <label class=""font-weight-bold pbshop-secundary-text-color"">Fecha de entrada: </label> ");
            EndContext();
            BeginContext(730, 50, false);
#line 16 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
                                                                                                      Write(Html.DisplayFor(model => model.vehicle.created_at));

#line default
#line hidden
            EndContext();
            BeginContext(780, 109, true);
            WriteLiteral("<br>\r\n                    <label class=\"font-weight-bold pbshop-secundary-text-color\">No. de Serie: </label> ");
            EndContext();
            BeginContext(890, 46, false);
#line 17 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
                                                                                                  Write(Html.DisplayFor(model => model.vehicle.serial));

#line default
#line hidden
            EndContext();
            BeginContext(936, 103, true);
            WriteLiteral("<br>\r\n                    <label class=\"font-weight-bold pbshop-secundary-text-color\" >Modelo:</label> ");
            EndContext();
            BeginContext(1040, 44, false);
#line 18 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
                                                                                            Write(Html.DisplayFor(model=> model.vehicle.model));

#line default
#line hidden
            EndContext();
            BeginContext(1084, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1086, 43, false);
#line 18 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
                                                                                                                                          Write(Html.DisplayFor(model=> model.vehicle.year));

#line default
#line hidden
            EndContext();
            BeginContext(1129, 102, true);
            WriteLiteral("<br>\r\n                    <label class=\"font-weight-bold pbshop-secundary-text-color\">Marca: </label> ");
            EndContext();
            BeginContext(1232, 45, false);
#line 19 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
                                                                                           Write(Html.DisplayFor(model => model.vehicle.brand));

#line default
#line hidden
            EndContext();
            BeginContext(1277, 2301, true);
            WriteLiteral(@" <br>

                </div>
            </div>
            <div class=""col-md-6 card"">
                <div class=""card-body "">
                    <h5 class=""card-title pbshop-secundary-text-color"">Detalle especial de la restauración:</h5>
                    <h6 class=""text-secondary"">Ninguno</h6>
                </div>
            </div>
            <div class=""col-md-6 card"">
                <div class=""card-body"" >
                    <h5 class=""card-title pbshop-secundary-text-color"">Actividades:</h5>
                    <div id=""loading-activities"" class=""col-md-12"">
                         <div class=""justify-content-md-center""  data-icon=""ei-spinner-3"" data-size=""l""></div>
                    </div>
                    <table id=""activities"" class=""table table-hover hidden"">
                        <thead>
                            <tr>
                            <th scope=""col"">Descripción</th>
                            <th scope=""col"">Estado</th>
                       ");
            WriteLiteral(@"     <th></th>
                            </tr>
                        </thead>
                        <tbody id=""activities-list"">
                           
                        </tbody>
                        </table>
                </div>
            </div>
    </div>
    <div>

    <div class=""modal fade"" id=""exampleModalCenter"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalCenterTitle"">Modal title</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ...
            </div>
            <div class=""modal-footer"">
                <");
            WriteLiteral("button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Cerrar</button>\r\n                <button type=\"button\" class=\"btn btn-primary\">Save changes</button>\r\n            </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    \r\n    <!-- ");
            EndContext();
            BeginContext(3579, 68, false);
#line 72 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
    Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(3647, 21, true);
            WriteLiteral(" | -->\r\n   \r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3686, 109, true);
                WriteLiteral("\r\n     <script type=\"text/javascript\">\r\n        $(document).ready(function(){\r\n            var workshop_id = ");
                EndContext();
                BeginContext(3796, 11, false);
#line 78 "/Users/altexo94/Documents/dev/ing-web/pbshop/pbshop_web/Views/WorkShopRecordsWeb/Details.cshtml"
                         Write(workshop_id);

#line default
#line hidden
                EndContext();
                BeginContext(3807, 1010, true);
                WriteLiteral(@";
            $(""#loading-activities"").addClass(""hidden"");
            $(""#activities"").removeClass(""hidden"");
            
            $.ajax({ 
                type:'GET', 
                url: ""https://localhost:5001/api/tasks/workshop/""+workshop_id,
                success:function(response){
                    console.log(response);
                    $.each(response, function(index, value){
                        var tasks = ""<tr><td>""+value.description+""</td>""+
                                    ""<td>""+value.task_state+""</td>""+
                                    ""<td><a data-toggle='modal' data-target='#exampleModalCenter'><input type='hidden' value=""+value.id+""><div data-icon='ei-gear' data-size='s'></div></a></td></tr>"";
                        $(""#activities-list"").append(tasks);
                    });
                },
                error:function(error){
                    console.log(error);
                }
            });
        })
     </script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<pbshop_web.Models.WorkshopRecordModel> Html { get; private set; }
    }
}
#pragma warning restore 1591