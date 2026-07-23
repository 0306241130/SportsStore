using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SportsStore.WebUI.Infarstructure
{
    public class PageLinkTagHelper:TagHelper
    {
        public string?  AspController { get; set; }

        public string?  AspAction { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string? PageClass { get; set; }

        public string? PageClassSelected { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div class=\"page-item d-flex\"";

            for (int i = 1; i <= TotalPages; i++)
            {   if (i == CurrentPage)
                {
                    output.Content.AppendHtml(
                        $"<a href='/{AspController}/{AspAction}?page={i}' class=\"page-link {PageClass} {PageClassSelected}\">{i}</a>"
                    );
                }
                else
                {
                    output.Content.AppendHtml(
                        $"<a href='/{AspController}/{AspAction}?page={i}' class=\"page-link\">{i}</a>"
                    );
                }
            }

        }
    }
}
