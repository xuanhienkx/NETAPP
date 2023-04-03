using System.Text.RegularExpressions;
using CS.SwiftParser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using xUnit.CSCommon;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CS.SwiftParser
{
    public class LatinEncoderTest : TestBase<SwiftParserFixtureSetup>
    {
        public LatinEncoderTest(SwiftParserFixtureSetup fixture, ITestOutputHelper output) 
            : base(fixture, output)
        {
        }

        private readonly Regex unicode =new Regex("[_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]");

        [Theory]
        //[InlineData("Bão Talas hiện cách bờ biển Thanh Hóa - Hà Tĩnh 160 km, các phương án ứng phó đã hoàn thành trước 17h hôm nay")]
       // [InlineData("Mất cả đống thời gian ngồi search, chẳng tìm được cách nào cho ra hồn, đành phải làm cách mì ăn liền ")]
        [InlineData("Giống các cuộc chiến hiện đại, cuộc chiến Trung - Ấn sẽ diễn ra cả trên bộ, trên biển và trên không. Biên giới trên bộ với địa hình rừng núi hiểm trở sẽ hạn chế đáng kể việc sử dụng các loại khí tài bộ binh, trong khi cuộc chiến trên không sẽ gây thiệt hại lớn nhất. Át chủ bài duy nhất giúp Ấn Độ chiếm lợi thế là hải chiến, vì điều này sẽ gây hậu quả nghiêm trọng cho nền kinh tế Trung Quốc")]
        [InlineData("Ỷ thiên đồ long ký")]
        [InlineData("phapht@gmail.com")]
        [InlineData("16 Đoàn Trần Nghiệp")]
        public void TranslationLatinTest(string message)
        {
            // Arrange
            this.Logger.WriteLine(message);
            
            // Act
            var result = LatinEncoder.VniEscape(message); 
            this.Logger.WriteLine(result);

            // Assert
            Assert.DoesNotMatch(unicode,result);

            var upperKey = message.ToUpper();
            this.Logger.WriteLine(upperKey);

            
            result = LatinEncoder.VniEscape(upperKey);
            this.Logger.WriteLine(result);

            // Assert
            Assert.DoesNotMatch(unicode, result);
        }

        [Theory]
        [InlineData("B?ar?o Talas hi?eej?n c?as?ch b?owf? bi?eer?n Thanh H?os?a - H?af? T?ix?nh 160 km, c?as?c ph?uw??ow?ng ?as?n ?uws?ng ph?os? ?dd??ar? ho?af?n th?af?nh tr?uw??ows?c 17h h?oo?m nay")]
        [InlineData("M?aas?t c?ar? ?dd??oos?ng th?owf?i gian ng?oof?i search, ch?awr?ng t?if?m ?dd??uw??owj?c c?as?ch n?af?o cho ra h?oof?n, ?dd??af?nh ph?ar? l?af?m c?as?ch m?if? ?aw?n li?eef?n")]
        public void TranslationVnTest(string message)
        {
            // Arrange
            this.Logger.WriteLine(message);
            // Act
            var result = LatinEncoder.VniEncode(message);
            this.Logger.WriteLine(result);

            // Assert
            Assert.Matches(unicode, result);

            var upperKey = message.ToUpper();
            this.Logger.WriteLine(upperKey);
            result = LatinEncoder.VniEncode(upperKey);
            this.Logger.WriteLine(result);

            // Assert
            Assert.Matches(unicode, result);
        }
    }
}
