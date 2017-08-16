using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace FACE_DynamicComparison.Converter
{
    public class ImageZoomConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result = 0.0;

            try
            {
                double _multiple = 0.0;
                if (parameter != null && !string.IsNullOrEmpty(parameter.ToString()))
                {
                    if (double.TryParse(parameter.ToString(), out _multiple))
                    {
                        if (_multiple > 0)
                        {
                            //double val = (double) value;
                            //if (val > 0)
                            //{
                            //    result = val * _multiple;
                            //} 
                            if (values[0] != null && !string.IsNullOrEmpty(values[0].ToString()))
                            {
                                string identify = values[0] as string;
                                Image self = (Image)values[1];
                                if (self == null || self.Source == null)
                                    return result;
                                if (identify == "Width")
                                {
                                    result = self.Source.Width * _multiple;
                                }
                                else
                                {
                                    result = self.Source.Height * _multiple;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return new[] { value };
        }
        #endregion
    }
}
