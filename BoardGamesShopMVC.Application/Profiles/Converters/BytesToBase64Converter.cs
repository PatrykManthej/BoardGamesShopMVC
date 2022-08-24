using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Profiles.Converters
{
    public class BytesToBase64Converter : ITypeConverter<byte[], string>
    {
        public string Convert(byte[] source, string destination, ResolutionContext context)
        {
            var imgSrc = "";
            if (source != null)
            {
                var base64 = System.Convert.ToBase64String(source);
                imgSrc = String.Format("data:image/png;base64,{0}", base64);
            }
            return imgSrc;
        }
    }
}
