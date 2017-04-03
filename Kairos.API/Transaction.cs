namespace Kairos.API
{
    /// <summary>
    ///     Transaction details after an enrollment
    /// </summary>
    public class Transaction
    {
        public string status { get; set; }
        public string subject { get; set; }
        public string face_id { get; set; }
        public string subject_id { get; set; }
        public string confidence { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int topLeftX { get; set; }
        public int topLeftY { get; set; }
        public string image_id { get; set; }
        public string timestamp { get; set; }
        public string gallery_name { get; set; }
    }
}