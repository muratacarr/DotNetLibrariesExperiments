using System.Drawing;

namespace HangfireApp.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWaterMarkJob(string fileName,string watermarkText)
        {
            return Hangfire.BackgroundJob.Schedule(()=>ApplyWatermark(fileName,watermarkText),TimeSpan.FromSeconds(10));
        }

        public static void ApplyWatermark(string filename,string watermarkText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", filename);

            //Burada olan metot lar microsofta özgü olduğu için

            using (var bitmap=Bitmap.FromFile(path))
            {
                using (Bitmap tempBitmap= new Bitmap(bitmap.Width,bitmap.Height))
                {
                    using (Graphics grp=Graphics.FromImage(tempBitmap))
                    {
                        grp.DrawImage(bitmap, 0, 0);

                        var font = new Font(FontFamily.GenericMonospace, 25, FontStyle.Italic);

                        var color = Color.Red;

                        var brush=new SolidBrush(color);

                        var point = new Point(20,bitmap.Height-50);

                        grp.DrawString(watermarkText, font, brush, point);

                        tempBitmap.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/watermarks", filename));
                    }
                }
            }

        }
    }
}
