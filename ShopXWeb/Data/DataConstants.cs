namespace ShopXWeb.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataConstants
    {
        // Title
        public const int PostTitleMaxLength = 50;
        public const int PostTitleMinLength = 2;
        // Price
        public const int PostPriceMinValue = 0;
        public const int PostPriceMaxValue = 10000000;
        // Description
        public const int PostDescriptionMaxLength = 500;
        public const int PostDescriptionMinLength = 10;
    }
}
