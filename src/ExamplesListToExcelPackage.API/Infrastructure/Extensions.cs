using ListToExcelPackage.Enums;
using ListToExcelPackage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplesListToExcelPackage.API.Infrastructure
{
    public static class Extensions
    {
        public static List<StyleOption> GetStyleOptions(int listCount)
        {
            var _options = new List<StyleOption>();

            //First Row FontBold
            _options.Add(new StyleOption() { row1 = 1, col1 = 1, row2 = 1, col2 = 3, style = StyleOptionEnum.fontBold });

            //First Row AutoFilter
            _options.Add(new StyleOption() { row1 = 1, col1 = 1, row2 = 1, col2 = 3, style = StyleOptionEnum.autoFilter });

            //First Column set width
            _options.Add(new StyleOption() { col1 = 1, style = StyleOptionEnum.width, value = 23.0 });

            //First Row freezePanes
            _options.Add(new StyleOption() { style = StyleOptionEnum.freezePanes });

            //First Row Set Background
            _options.Add(new StyleOption() { row1 = 1, col1 = 1, row2 = 1, col2 = 3, style = StyleOptionEnum.backgroundColor, value = "#c9f5dd" });

            //First Column Set Background
            _options.Add(new StyleOption() { row1 = 2, col1 = 1, row2 = listCount + 1, col2 = 1, style = StyleOptionEnum.backgroundColor, value = "#f5ebc9" });


            return _options;
        }

    }
}
