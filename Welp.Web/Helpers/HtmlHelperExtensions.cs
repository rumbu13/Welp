using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Welp.Web.Helpers
{
    public static class HtmlHelperExtensions
    {

        public static IHtmlContent ProgressBarFor<TModelItem, TResult>(this IHtmlHelper<TModelItem> htmlHelper, 
            Expression<Func<TModelItem, TResult>> expression,
            int minValue, int maxValue)
        {
            var value = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider).Model;
            return new HtmlString($"<div class='progress'>" +
                    $"<div class='progress-bar' role='progressbar' aria-valuenow=\'{value}' aria-valuemin='{minValue}' aria-valuemax='{maxValue}' style='width: {value}%;'>{value}%</div>" +
                    $"</div>");
        }

        public static IHtmlContent SliderFor<TModelItem, TResult>(this IHtmlHelper<TModelItem> htmlHelper,
            Expression<Func<TModelItem, TResult>> expression,
            int minValue, int maxValue)
        {
            var id = htmlHelper.IdFor(expression);
            var value = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider).Model;
            return new HtmlString($"<input id='{id}' data-slider-id='{id}Slider' type='text' data-slider-min='{minValue}' data-slider-max='{maxValue}' data-slider-value='{value}'><script> var slider = new Slider('{id}', {{ formatter: function(value) {{ return 'Current value: ' + value; }} }});</script>");
        }
    }
}
