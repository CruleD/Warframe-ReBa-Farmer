using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Tesseract;

namespace Warframe_ReBa_Farmer
{
    class Module_OCR
    {
        private static List<string> PrimeItems = new List<string>();

        public static void OCR_Initialize()
        {
            //Force load needed stuff on start
            TesseractEngine OCREngine = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractOnly);
            OCREngine.Dispose();
        }

        static Module_OCR()
        {
            PrimeItems = Module_Data.PrimeItemsData.Keys.ToList();
        }

        public static string OCR_Image(Bitmap PassedBitmap)
        {
            string OCRd_Text;
            using (TesseractEngine OCREngine = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndLstm))
            {
                OCREngine.DefaultPageSegMode = PageSegMode.SingleBlock;
                OCREngine.SetVariable("tessedit_char_whitelist", "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz&");
                OCREngine.SetVariable("textord_space_size_is_variable", 1); //If true, word delimiter spaces are assumed to have variable width, even though characters have fixed pitch.
                OCREngine.SetVariable("tosp_min_sane_kn_sp", 3); //Don't trust spaces less than this
                OCRd_Text = OCREngine.Process(PassedBitmap).GetText().Trim().Replace("\n"," ");
            }

            if (!PrimeItems.Contains(OCRd_Text)) { OCRTextFixer(ref OCRd_Text); }
            return OCRd_Text;
        }

        private static void OCRTextFixer(ref string OCRd_Text)
        {
            //https://stackoverflow.com/a/13793600/8810532
            Dictionary<string, int> ResultSet = new Dictionary<string, int>();
            foreach (string stringtoTest in PrimeItems) //Doing all is faster than only similar
            {
                ResultSet.Add(stringtoTest, Module_Dictionary.Compute(OCRd_Text, stringtoTest));
            }
            int MinimumModifications = ResultSet.Min(c => c.Value);
            string ClosestNameFromList = ResultSet.Where(c => c.Value == MinimumModifications).FirstOrDefault().Key;
            OCRd_Text = ClosestNameFromList;
        }

        public static int OCR_Timer(Bitmap PassedBitmap)
        {
            int OCRd_Number;
            using (TesseractEngine OCREngine = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndLstm))
            {
                OCREngine.DefaultPageSegMode = PageSegMode.SingleLine;
                OCREngine.SetVariable("tessedit_char_whitelist", "0123456789");
                OCRd_Number = int.TryParse(OCREngine.Process(PassedBitmap).GetText().Trim(), out OCRd_Number) ? OCRd_Number : 10;
            }
            return OCRd_Number;
        }
    }
}
