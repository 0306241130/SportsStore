using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SportsStore.WebUI.Infarstructure
{
    public class PageLinkTagHelper:TagHelper
    {
        public string?  AspController { get; set; }

        public string?  AspAction { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div";

            for (int i = 1; i <= TotalPages; i++)
            {
                output.Content.AppendHtml(
                    $"<a href='/{AspController}/{AspAction}?page={i}'>{i}</a>"
                );
            }

        }
    }
}
