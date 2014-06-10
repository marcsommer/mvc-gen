using System.Text.RegularExpressions;

namespace DbGenLibrary.Text
{
    public static class TextUtility
    {
        public static string WithIndent(this string caller, int indentLevel)
        {
            string s = caller;
            for (int i = 0; i < indentLevel; i++)
                s = "\t" + s;
            return s;
        }

        public static string RemoveVietnameseSign(this string input)
        {
            string output = input;
            string[] ip = { "[éèẻẽẹêếềểễệ]", "[ýỳỷỹỵ]", "[úùủũụưứừửữự]", "[íìỉĩị]", "[óòỏõọôốồổỗộơớờởỡợ]", "[áàảãạăắằẳẵặâấầẩẫậ]", "[đ]", "[ÉÈẺẼẸÊẾỀỂỄỆ]", "[ÝỲỶỸỴ]", "[ÚÙỦŨỤƯỨỪỬỮỰ]", "[ÍÌỈĨỊ]", "[ÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢ]", "[ÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬ]", "[Đ]" };
            string[] op = { "e", "y", "u", "i", "o", "a", "d", "E", "Y", "U", "I", "O", "A", "D" };
            for (int i = 0; i < 13; i++)
                output = Regex.Replace(output, ip[i], op[i]);
            return output;
        }

        public static string SimpleString(this string input)
        {
            return input
                .Replace(" ", "")
                .Replace(".", "")
                .RemoveVietnameseSign();
        }
    }
}