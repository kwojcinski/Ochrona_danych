#pragma checksum "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df245af5bf15406a9a68e40f17da37370aab4572"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EditNote), @"mvc.1.0.view", @"/Views/Home/EditNote.cshtml")]
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
#line 1 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\_ViewImports.cshtml"
using OchronaDanych_291118;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\_ViewImports.cshtml"
using OchronaDanych_291118.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df245af5bf15406a9a68e40f17da37370aab4572", @"/Views/Home/EditNote.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b400f8f1d52b5ce02aca39303ef45ac9c824741f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EditNote : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OchronaDanych_291118.Models.NoteViewModel>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE HTML>\r\n<html lang=pl>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df245af5bf15406a9a68e40f17da37370aab45723359", async() => {
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js""></script>
    <script src=""https://ajax.aspnetcdn.com/ajax/jquery.validate/1.16.0/jquery.validate.min.js""></script>
    <script src=""https://ajax.aspnetcdn.com/ajax/jquery.validation.unobtrusive/3.2.6/jquery.validate.unobtrusive.min.js""></script>

    <link href=""https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.css"" rel=""stylesheet"">
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote.js"" defer></script>
    <title>Edytuj notatkę</title>
");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df245af5bf15406a9a68e40f17da37370aab45724915", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
      
        ViewData["Title"] = "Edytuj notatkę";
    

#line default
#line hidden
#nullable disable
                WriteLiteral("    <h2 style=\"margin-bottom: 20px;\">");
#nullable restore
#line 17 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
                                Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n\r\n");
#nullable restore
#line 19 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
     using (Html.BeginForm("EditNote", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
   Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div id=\"Title\" class=\"col-12 form-group\">\r\n            <div>\r\n                <label>Tytuł</label><p style=\"display:inline; color:red\">*</p>\r\n            </div>\r\n            ");
#nullable restore
#line 27 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
       Write(Html.EditorFor(m => m.Title, new { htmlAttributes = new { @class = "form-control", @maxlength = "120", @minlength = "4" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div>\r\n                ");
#nullable restore
#line 29 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
           Write(Html.ValidationMessageFor(m => m.Title, "", new { @style = "color: red; font-weight: bold;" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div id=\"Description\" class=\"col-12 form-group\">\r\n            <label>Notatka</label><p style=\"display:inline; color:red\">*</p>\r\n            ");
#nullable restore
#line 34 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
       Write(Html.TextAreaFor(m => m.Description, new { @class = "form-control", rows = "5", id = "summernote" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 35 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
       Write(Html.ValidationMessageFor(m => m.Description, "", new { @style = "color: red; font-weight: bold;" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div id=\"IsForEveryoneDiv\" class=\"col-12 form-group\">\r\n            <label>Czy plik ma być dostępny dla wszystkich?</label><p style=\"display:inline; color:red\">*</p>\r\n            <br />\r\n            ");
#nullable restore
#line 40 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
       Write(Html.CheckBoxFor(m => m.IsForEveryone, new { @onclick = "onCheckboxClick()" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(" Tak\r\n            ");
#nullable restore
#line 41 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
       Write(Html.ValidationMessageFor(m => m.IsForEveryone, "", new { @style = "color: red; font-weight: bold;" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div id=\"Emails\" class=\"col-12 form-group\" style=\"display: none;\">\r\n            <label>Adresy email użytkowników</label><p style=\"display:inline; color:red\">*</p>\r\n            <br />\r\n            ");
#nullable restore
#line 46 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
       Write(Html.EditorFor(m => m.Emails, new { htmlAttributes = new { @class = "form-control", @placeholder = "Każdy wpisany email oddziel znakiem ';'. Np.: example@example.pl; example2@example.pl " } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 47 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
       Write(Html.ValidationMessageFor(m => m.Emails, "", new { @style = "color: red; font-weight: bold;" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <input id=\"submit\" type=\"submit\" class=\"btn btn-primary\" />\r\n        </div>\r\n");
#nullable restore
#line 52 "C:\Users\kwojc\source\repos\OchronaDanych_291118\OchronaDanych_291118\Views\Home\EditNote.cshtml"
    }

#line default
#line hidden
#nullable disable
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
            WriteLiteral(@"
</html>
<script>
$(document).ready(function() {
    $('#summernote').summernote();
    onCheckboxClick();
});

    function onCheckboxClick() {
        if ($(""#IsForEveryone"").prop(""checked"") == true) {
            $(""#Emails"").hide();
        }
        else {
            $(""#Emails"").show();
        }
    }

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OchronaDanych_291118.Models.NoteViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
