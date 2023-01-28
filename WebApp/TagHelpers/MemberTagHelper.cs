using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WebApp.Models.Domain;

namespace WebApp.TagHelpers
{
    public class MemberTagHelper : TagHelper
    {

        public List<Member> Members { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder html= new StringBuilder("<ul>");

            foreach(var member in Members)
            {
                html.Append("<li>");
                html.Append(member.Name + " Nazwiskod: " + member.Surname);
                html.Append("</li>");
            }

            html.Append("</ul>");

            output.Content.SetContent(html.ToString()); 

        }
    }
}
